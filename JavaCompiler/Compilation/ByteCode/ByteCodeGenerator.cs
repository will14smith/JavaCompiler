using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilation.ByteCode
{
    public class ByteCodeGenerator
    {
        private byte[] byteCodeStream;
        private int length;

        public ByteCodeGenerator(CompileManager manager, Method method)
        {
            Manager = manager;
            Method = method;

            byteCodeStream = new byte[64];
            length = 0;

            labelCount = 0;
            labelList = null;

            variableList = new Variable[256];
            if (method.Modifiers.HasFlag(Modifier.Static))
            {
                variableCount = 0;
                MaxVariables = 0;
            }
            else
            {
                variableCount = 1;
                MaxVariables = 1;

                variableList[0] = new Variable(0, "this", method.DeclaringType);
            }
            variableListStack = new Stack<Tuple<short, Variable[]>>();

            stackSize = 0;
            MaxStack = 0;

            StackItem = new Item[(int)ItemTypeCode.TypeCodeCount];
            for (int i = 0; i < (int)ItemTypeCode.Void; i++)
                StackItem[i] = new StackItem(this, TypeCodeHelper.Type((ItemTypeCode)i));
            StackItem[(int)ItemTypeCode.Void] = new VoidItem(this);
        }

        #region Labels

        private int labelCount;
        private int[] labelList;

        public Label DefineLabel()
        {
            if (labelList == null)
            {
                labelList = new int[4];
            }
            if (labelCount >= labelList.Length)
            {
                labelList = EnlargeArray(labelList);
            }

            labelList[labelCount] = -1;

            return new Label(labelCount++);
        }

        public virtual void MarkLabel(Label loc)
        {
            int labelValue = loc.GetLabelValue();

            if (labelValue < 0 || labelValue >= labelList.Length)
            {
                throw new ArgumentException("Argument_InvalidLabel");
            }
            if (labelList[labelValue] != -1)
            {
                throw new ArgumentException("Argument_RedefinedLabel");
            }

            labelList[labelValue] = length;
        }

        #endregion

        #region Variables

        public short MaxVariables { get; private set; }

        private readonly Stack<Tuple<short, Variable[]>> variableListStack;
        private short variableCount;
        private Variable[] variableList;

        public void PushVariables()
        {
            variableListStack.Push(new Tuple<short, Variable[]>(variableCount, variableList));

            variableList = (Variable[])variableList.Clone();
        }

        public void PopVariables()
        {
            Tuple<short, Variable[]> vars = variableListStack.Pop();

            variableCount = vars.Item1;
            variableList = vars.Item2;
        }

        public Variable GetVariable(string name)
        {
            return variableList.FirstOrDefault(x => x != null && x.Name == name);
        }

        public Variable DefineVariable(string name, Type type)
        {
            if (variableCount >= variableList.Length)
                throw new StackOverflowException("Cannot define any more local variables!");

            short index = FindFreeVariableIndex();

            variableList[index] = new Variable(index, name, type);
            variableCount++;

            MaxVariables = Math.Max(MaxVariables, variableCount);

            return variableList[index];
        }

        private short FindFreeVariableIndex()
        {
            for (short i = 0; i < variableList.Length; i++)
            {
                if (variableList[i] != null) continue;

                return i;
            }

            throw new StackOverflowException("Cannot find a free variable index!");
        }

        public void UndefineVariable(string name)
        {
            UndefineVariable(GetVariable(name).Index);
        }

        public void UndefineVariable(Variable variable)
        {
            UndefineVariable(variable.Index);
        }

        public void UndefineVariable(int index)
        {
            if (index < 0 && index > variableList.Length)
                throw new ArgumentException("index is greater than max", "index");

            variableList[index] = null;

            variableCount--;
        }

        #endregion

        #region Emit

        public void Emit(OpCode opcode)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Unused ||
                opcode.Mode == OpCodeMode.Simple);

            EnsureCapacity(1);

            InternalEmit(opcode.Value);
        }
        public void Emit(OpCode opcode, byte b)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Constant_1 ||
                opcode.Mode == OpCodeMode.Immediate_1 ||
                opcode.Mode == OpCodeMode.Local_1);

            EnsureCapacity(2);

            InternalEmit(opcode.Value);
            InternalEmitByte(b);
        }
        public void Emit(OpCode opcode, byte b1, byte b2)
        {
            Debug.Assert(opcode.Mode == OpCodeMode.Local_1_Immediate_1);

            EnsureCapacity(3);

            InternalEmit(opcode.Value);
            InternalEmitByte(b1);
            InternalEmitByte(b2);
        }
        public void Emit(OpCode opcode, short s)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Constant_2 ||
                opcode.Mode == OpCodeMode.Immediate_2);

            EnsureCapacity(3);

            InternalEmit(opcode.Value);
            InternalEmitShort(s);
        }
        public void Emit(OpCode opcode, short s, byte b)
        {
            Debug.Assert(opcode.Mode == OpCodeMode.Constant_2_Immediate_1);

            EnsureCapacity(4);

            InternalEmit(opcode.Value);
            InternalEmitShort(s);
            InternalEmitByte(b);
        }
        public void Emit(OpCode opcode, short s, byte b1, byte b2)
        {
            Debug.Assert(opcode.Mode == OpCodeMode.Constant_2_1_1);

            EnsureCapacity(5);

            InternalEmit(opcode.Value);
            InternalEmitShort(s);
            InternalEmitByte(b1);
            InternalEmitByte(b2);
        }
        public void Emit(OpCode opcode, Label l)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Branch_2 ||
                opcode.Mode == OpCodeMode.Branch_4);

            EnsureCapacity(opcode.Mode == OpCodeMode.Branch_2 ? 3 : 5);

            int labelValue = l.GetLabelValue();
            int i = labelList[labelValue];

            InternalEmit(opcode.Value);
            if (opcode.Mode == OpCodeMode.Branch_4)
            {
                byteCodeStream[length++] = (byte)((i >> 24) & 0xff);
                byteCodeStream[length++] = (byte)((i >> 16) & 0xff);
            }
            byteCodeStream[length++] = (byte)((i >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(i & 0xff);
        }

        public void EmitWide(OpCode opcode, short s)
        {
            Debug.Assert(opcode.WideMode == OpCodeModeWide.Local_2);

            EnsureCapacity(4);

            InternalEmit(OpCodes.wide.Value);
            InternalEmit(opcode.Value);
            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);
        }
        public void EmitWide(OpCode opcode, short s1, short s2)
        {
            Debug.Assert(opcode.WideMode == OpCodeModeWide.Local_2_Immediate_2);

            EnsureCapacity(6);

            InternalEmit(OpCodes.wide.Value);
            InternalEmit(opcode.Value);
            byteCodeStream[length++] = (byte)((s1 >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s1 & 0xff);
            byteCodeStream[length++] = (byte)((s2 >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s2 & 0xff);
        }

        public void EmitInvoke(OpCode opcode, short argCount, short s)
        {
            Debug.Assert(opcode.Value >= OpCodeValue.invokevirtual && opcode.Value <= OpCodeValue.invokedynamic);
            Debug.Assert(opcode.Mode == OpCodeMode.Constant_2 ||
                         opcode.Mode == OpCodeMode.Immediate_2);

            EnsureCapacity(3);

            InternalEmitByte((byte)opcode.Value);
            InternalEmitShort(s);

            if (opcode.Value == OpCodeValue.invokevirtual ||
                opcode.Value == OpCodeValue.invokespecial)
            {
                stackSize -= 1;
            }

            stackSize -= argCount;
            MaxStack = Math.Max(MaxStack, stackSize);
        }
        public void EmitInvoke(OpCode opcode, short argCount, short s, byte b1, byte b2)
        {
            Debug.Assert(opcode.Value >= OpCodeValue.invokevirtual && opcode.Value <= OpCodeValue.invokedynamic);
            Debug.Assert(opcode.Mode == OpCodeMode.Constant_2_1_1);

            EnsureCapacity(5);

            InternalEmit(opcode.Value);
            InternalEmitShort(s);
            InternalEmitByte(b1);
            InternalEmitByte(b2);

            if (opcode.Value == OpCodeValue.invokeinterface)
            {
                stackSize -= 1;
            }

            stackSize -= argCount;
            MaxStack = Math.Max(MaxStack, stackSize);
        }


        internal void InternalEmit(OpCodeValue opcode)
        {
            EnsureCapacity(1);

            UpdateStack(opcode);

            byteCodeStream[length++] = (byte)opcode;
        }

        internal void InternalEmitByte(byte b)
        {
            EnsureCapacity(1);

            byteCodeStream[length++] = b;
        }
        internal void InternalEmitShort(short s)
        {
            EnsureCapacity(2);

            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);
        }

        #endregion

        #region Output

        public byte[] GetBytes()
        {
            var bytes = new byte[length];

            Array.Copy(byteCodeStream, bytes, length);

            return bytes;
        }

        #endregion

        #region Stack

        public Item[] StackItem { get; private set; }
        public short MaxStack { get; private set; }

        private short stackSize;
        private void UpdateStack(OpCodeValue opcode)
        {
            if (opcode >= OpCodeValue.aconst_null && opcode <= OpCodeValue.aload_3 ||
                opcode >= OpCodeValue.dup && opcode <= OpCodeValue.dup_x2 ||
                opcode == OpCodeValue.getstatic ||
                opcode == OpCodeValue.@new ||
                opcode == OpCodeValue.jsr_w)
            {
                stackSize += 1;
            }
            else if (opcode >= OpCodeValue.iaload && opcode <= OpCodeValue.astore_3 ||
                     opcode == OpCodeValue.pop ||
                     opcode >= OpCodeValue.iadd && opcode <= OpCodeValue.drem ||
                     opcode >= OpCodeValue.ishl && opcode <= OpCodeValue.lxor ||
                     opcode >= OpCodeValue.lcmp && opcode <= OpCodeValue.ifle ||
                     opcode == OpCodeValue.jsr ||
                     opcode >= OpCodeValue.tableswitch && opcode <= OpCodeValue.areturn ||
                     opcode == OpCodeValue.putstatic ||
                     opcode >= OpCodeValue.monitorenter && opcode <= OpCodeValue.monitorexit ||
                     opcode >= OpCodeValue.ifnull && opcode <= OpCodeValue.ifnonnull)
            {
                stackSize -= 1;
            }
            else if (opcode >= OpCodeValue.dup2 && opcode <= OpCodeValue.dup2_x2)
            {
                stackSize += 2;
            }
            else if (opcode == OpCodeValue.pop2 ||
                     opcode >= OpCodeValue.if_icmpeq && opcode <= OpCodeValue.if_acmpne ||
                     opcode == OpCodeValue.putfield)
            {
                stackSize -= 2;
            }
            else if (opcode >= OpCodeValue.iastore && opcode <= OpCodeValue.sastore)
            {
                stackSize -= 3;
            }
            else if (opcode >= OpCodeValue.invokevirtual && opcode <= OpCodeValue.invokedynamic ||
                     opcode == OpCodeValue.multianewarray)
            {
                throw new NotImplementedException();
            }

            MaxStack = Math.Max(MaxStack, stackSize);
        }

        #endregion

        #region Helpers

        internal static int[] EnlargeArray(int[] incoming)
        {
            var array = new int[incoming.Length * 2];

            Array.Copy(incoming, array, incoming.Length);

            return array;
        }

        internal static byte[] EnlargeArray(byte[] incoming)
        {
            var array = new byte[incoming.Length * 2];

            Array.Copy(incoming, array, incoming.Length);

            return array;
        }

        internal static byte[] EnlargeArray(byte[] incoming, int requiredSize)
        {
            var array = new byte[requiredSize];

            Array.Copy(incoming, array, incoming.Length);

            return array;
        }

        internal void EnsureCapacity(int size)
        {
            if (length + size < byteCodeStream.Length) return;

            if (length + size >= 2 * byteCodeStream.Length)
            {
                byteCodeStream = EnlargeArray(byteCodeStream, length + size);
                return;
            }

            byteCodeStream = EnlargeArray(byteCodeStream);
        }

        #endregion

        public CompileManager Manager { get; private set; }
        public Method Method { get; private set; }
    }
}