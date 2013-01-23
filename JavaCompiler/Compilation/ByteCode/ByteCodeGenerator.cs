using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilation.ByteCode
{
    public class ByteCodeGenerator
    {
        public CompileManager Manager { get; private set; }
        public Method Method { get; private set; }

        public Item[] StackItem { get; private set; }

        private int length;
        private byte[] byteCodeStream;

        public ByteCodeGenerator(CompileManager manager, Method method)
        {
            Manager = manager;
            Method = method;

            byteCodeStream = new byte[64];
            length = 0;

            labelCount = 0;
            labelList = null;

            variableCount = 0;
            variableList = new Variable[256];
            variableListStack = new Stack<Tuple<int, Variable[]>>();

            StackItem = new Item[(int)ItemTypeCode.TypeCodeCount];
            for (var i = 0; i < (int)ItemTypeCode.Void; i++) StackItem[i] = new StackItem(this, TypeCodeHelper.Type((ItemTypeCode)i));
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
            var labelValue = loc.GetLabelValue();

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
        private int variableCount;
        private Variable[] variableList;
        private Stack<Tuple<int, Variable[]>> variableListStack;

        public void PushVariables()
        {
            variableListStack.Push(new Tuple<int, Variable[]>(variableCount, variableList));

            variableList = (Variable[])variableList.Clone();
        }
        public void PopVariables()
        {
            var vars = variableListStack.Pop();

            variableCount = vars.Item1;
            variableList = vars.Item2;
        }

        public Variable GetVariable(string name)
        {
            return variableList.FirstOrDefault(x => x != null && x.Name == name);
        }

        public Variable DefineVariable(string name, Type type)
        {
            if (variableCount >= variableList.Length) throw new StackOverflowException("Cannot define any more local variables!");

            var index = FindFreeVariableIndex();

            variableList[index] = new Variable(index, name, type);
            variableCount++;

            return variableList[index];
        }
        private short FindFreeVariableIndex()
        {
            // starts at 1 because variable 0 is usually "this"
            for (short i = 1; i < variableList.Length; i++)
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
            if (index < 0 && index > variableList.Length) throw new ArgumentException("index is greater than max", "index");

            variableList[index] = null;

            variableCount--;
        }
        #endregion

        #region Emit
        public virtual void Emit(OpCode opcode)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Unused ||
                opcode.Mode == OpCodeMode.Simple);

            EnsureCapacity(1);

            InternalEmit(opcode.Value);
        }
        public virtual void Emit(OpCode opcode, byte b)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Constant_1 ||
                opcode.Mode == OpCodeMode.Immediate_1 ||
                opcode.Mode == OpCodeMode.Local_1);

            EnsureCapacity(2);

            InternalEmit(opcode.Value);
            byteCodeStream[length++] = b;
        }
        public virtual void Emit(OpCode opcode, byte b1, byte b2)
        {
            Debug.Assert(opcode.Mode == OpCodeMode.Local_1_Immediate_1);

            EnsureCapacity(3);

            InternalEmit(opcode.Value);
            byteCodeStream[length++] = b1;
            byteCodeStream[length++] = b2;
        }
        public virtual void Emit(OpCode opcode, short s)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Constant_2 ||
                opcode.Mode == OpCodeMode.Immediate_2);

            EnsureCapacity(3);

            InternalEmit(opcode.Value);
            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);
        }
        public virtual void Emit(OpCode opcode, short s, byte b)
        {
            Debug.Assert(opcode.Mode == OpCodeMode.Constant_2_Immediate_1);

            EnsureCapacity(4);

            InternalEmit(opcode.Value);
            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);
            byteCodeStream[length++] = b;
        }
        public virtual void Emit(OpCode opcode, short s, byte b1, byte b2)
        {
            Debug.Assert(opcode.Mode == OpCodeMode.Constant_2_1_1);

            EnsureCapacity(5);

            InternalEmit(opcode.Value);
            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);
            byteCodeStream[length++] = b1;
            byteCodeStream[length++] = b2;
        }
        public virtual void Emit(OpCode opcode, Label l)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Branch_2 ||
                opcode.Mode == OpCodeMode.Branch_4);

            EnsureCapacity(opcode.Mode == OpCodeMode.Branch_2 ? 3 : 5);

            var labelValue = l.GetLabelValue();
            var i = labelList[labelValue];

            InternalEmit(opcode.Value);
            if (opcode.Mode == OpCodeMode.Branch_4)
            {
                byteCodeStream[length++] = (byte)((i >> 24) & 0xff);
                byteCodeStream[length++] = (byte)((i >> 16) & 0xff);
            }
            byteCodeStream[length++] = (byte)((i >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(i & 0xff);
        }

        public virtual void EmitWide(OpCode opcode, short s)
        {
            Debug.Assert(opcode.WideMode == OpCodeModeWide.Local_2);

            EnsureCapacity(4);

            InternalEmit(OpCodes.wide.Value);
            InternalEmit(opcode.Value);
            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);

        }
        public virtual void EmitWide(OpCode opcode, short s1, short s2)
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

        internal void InternalEmit(OpCodeValue opcode)
        {
            EnsureCapacity(1);

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
        private int maxStackSize;
        private int maxMidStack;
        private int maxMidStackCur;

        internal void UpdateStackSize(OpCode opcode, int stackchange)
        {
            maxMidStackCur += stackchange;
            if (maxMidStackCur > maxMidStack)
            {
                maxMidStack = maxMidStackCur;
            }
            else
            {
                if (maxMidStackCur < 0)
                {
                    maxMidStackCur = 0;
                }
            }
            //TODO: if (opcode.EndsUncondJmpBlk())
            //{
            //    maxStackSize += maxMidStack;
            //    maxMidStack = 0;
            //    maxMidStackCur = 0;
            //}
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
    }
}
