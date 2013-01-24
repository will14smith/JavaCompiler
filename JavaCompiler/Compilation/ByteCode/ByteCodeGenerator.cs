using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilation.ByteCode
{
    public class ByteCodeGenerator
    {
        private bool alive = true;

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
            labelRefs = new Dictionary<int, List<Tuple<int, int>>>();

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

            stack = new TypeStack();
        }

        #region Labels

        private int labelCount;
        private int[] labelList;
        private readonly Dictionary<int, List<Tuple<int, int>>> labelRefs;

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

            labelRefs.Add(labelCount, new List<Tuple<int, int>>());

            return new Label(labelCount++);
        }

        public Label MarkLabel()
        {
            var loc = DefineLabel();

            MarkLabel(loc);

            return loc;
        }
        public void MarkLabel(Label loc)
        {
            if (loc == null) return;

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

            ResolveLabel(labelValue);
            labelRefs.Remove(labelValue);
        }

        private void ResolveLabel(int labelValue)
        {
            var refs = labelRefs[labelValue];

            foreach (var l in refs)
            {
                var pos = l.Item1;
                var i = labelList[labelValue] - pos;

                if (l.Item2 == 4)
                {
                    byteCodeStream[pos++] = (byte)((i >> 24) & 0xff);
                    byteCodeStream[pos++] = (byte)((i >> 16) & 0xff);
                }
                byteCodeStream[pos++] = (byte)((i >> 8) & 0xff);
                byteCodeStream[pos] = (byte)(i & 0xff);

            }
        }

        #endregion

        #region Variables

        public short MaxVariables { get; private set; }

        private readonly Stack<Tuple<short, Variable[]>> variableListStack;
        private short variableCount;
        private Variable[] variableList;

        private void PushVariables()
        {
            variableListStack.Push(new Tuple<short, Variable[]>(variableCount, variableList));

            variableList = (Variable[])variableList.Clone();
        }
        private void PopVariables()
        {
            //TODO: Undeclare variables
            var vars = variableListStack.Pop();

            variableCount = vars.Item1;
            variableList = vars.Item2;
        }

        public Variable GetVariable(string name)
        {
            return variableList.FirstOrDefault(x => x != null && x.Name == name);
        }
        public Variable GetVariable(int index)
        {
            return variableList[index];
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

        #region Scope

        private readonly Stack<bool> aliveScope = new Stack<bool>();

        public void PushScope()
        {
            aliveScope.Push(alive);
            stack.PushScope();

            PushVariables();
        }
        public void PopScope()
        {
            alive = aliveScope.Pop();
            stack.PopScope();

            PopVariables();
        }

        #endregion

        #region Emit

        public void Emit(OpCodeValue opcode)
        {
            EnsureCapacity(1);

            EmitOp(opcode);

            if (!alive) return;
            UpdateStack0(opcode);

            PostOp();
        }
        public void Emit(OpCodeValue opcode, byte b)
        {
            EnsureCapacity(2);

            EmitOp(opcode);
            if (!alive) return;
            EmitByte(b);

            UpdateStack1(opcode, b);

            PostOp();
        }
        public void Emit(OpCodeValue opcode, short s)
        {
            EmitOp(opcode);

            if (!alive) return;
            EmitShort(s);

            UpdateStack2(opcode, s);
        }
        public void Emit(OpCodeValue opcode, Label l)
        {
            var capacity = opcode == OpCodeValue.goto_w || opcode == OpCodeValue.jsr_w ? 5 : 3;

            EnsureCapacity(capacity);

            var labelValue = l.GetLabelValue();
            var i = labelList[labelValue] - length;

            EmitOp(opcode);

            if (!alive) return;
            if (labelList[labelValue] == -1)
            {
                labelRefs[labelValue].Add(new Tuple<int, int>(length, capacity - 1));

                i = int.MaxValue;
            }

            if (capacity == 5)
            {
                EmitInt(i);
            }
            else
            {
                EmitShort((short)i);
            }

            UpdateStackBranch(opcode, i);

            pendingStackMap = true;
        }

        public void EmitWide(OpCodeValue opcode, short s)
        {
            if (s > 0xFF)
            {
                EnsureCapacity(4);

                EmitOp(OpCodeValue.wide);
                EmitOp(opcode);
                EmitShort(s);
            }
            else
            {
                EnsureCapacity(2);

                EmitOp(opcode);
                EmitByte((byte)s);
            }

            if (!alive) return;
            UpdateStackWide(opcode, s);

            PostOp();
        }
        public void EmitWide(OpCodeValue opcode, short s1, short s2)
        {
            EnsureCapacity(6);

            if (s1 > 0xFF || s2 < -128 || s2 > 127)
            {
                EmitOp(OpCodeValue.wide);
                EmitOp(opcode);
                EmitShort(s1);
                EmitShort(s2);
            }
            else
            {
                EmitOp(opcode);
                EmitByte((byte)s1);
                EmitByte((byte)s2);
            }
        }

        public void EmitMultianewarray(byte ndims, short type, Type arrayType)
        {
            EmitOp(OpCodeValue.multianewarray);
            if (!alive) return;

            EmitShort(type);
            EmitByte(ndims);

            stack.Pop(ndims);
            stack.Push(arrayType);
        }
        public void EmitNewarray(byte elemcode, Type arrayType)
        {
            EmitOp(OpCodeValue.newarray);
            if (!alive) return;

            EmitByte(elemcode);

            stack.Pop(1); // count
            stack.Push(arrayType);
        }
        public void EmitAnewarray(short od, Type arrayType)
        {
            EmitOp(OpCodeValue.anewarray);
            if (!alive) return;

            EmitShort(od);

            stack.Pop(1);
            stack.Push(arrayType);
        }

        public void EmitGetstatic(short f, Field field)
        {
            EmitOp(OpCodeValue.getstatic);

            if (!alive) return;
            EmitShort(f);

            stack.Push(field.ReturnType);
        }
        public void EmitPutstatic(short f, Field field)
        {
            EmitOp(OpCodeValue.putstatic);

            if (!alive) return;
            EmitShort(f);

            stack.Pop(field.ReturnType);
        }
        public void EmitGetfield(short f, Field field)
        {
            EmitOp(OpCodeValue.getfield);

            if (!alive) return;
            EmitShort(f);

            stack.Pop(1); // object ref
            stack.Push(field.ReturnType);
        }
        public void EmitPutfield(short f, Field field)
        {
            EmitOp(OpCodeValue.putfield);

            if (!alive) return;
            EmitShort(f);

            stack.Pop(field.ReturnType);
            stack.Pop(1); // object ref
        }

        public void EmitNew(short cp, Type type)
        {
            EmitOp(OpCodeValue.@new);

            if (!alive) return;
            EmitShort(cp);

            stack.Push(UninitializedType.UninitializedObject(type, length - 3));
        }
        public void EmitCheckcast(short f, Type type)
        {
            EmitOp(OpCodeValue.checkcast);

            if (!alive) return;
            EmitShort(f);

            stack.Pop(1); // object ref
            stack.Push(type);
        }


        public void EmitInvokeinterface(short meth, Method method)
        {
            var argsize = (short)TypeCodeHelper.Width(method.Parameters.Select(x => x.Type));

            EmitOp(OpCodeValue.invokeinterface);
            if (!alive) return;

            EmitShort(meth);
            EmitByte((byte)(argsize + 1));
            EmitByte(0);

            stack.Pop(argsize + 1);
            stack.Push(method.ReturnType);
        }
        public void EmitInvokespecial(short meth, Method method)
        {
            var argsize = (short)TypeCodeHelper.Width(method.Parameters.Select(x => x.Type));

            EmitOp(OpCodeValue.invokespecial);
            if (!alive) return;

            EmitShort(meth);

            stack.Pop(argsize);

            //TODO: if (method.Name == "<init>")
            //    state.markInitialized((UninitializedType)state.peek());

            stack.Pop(1);
            stack.Push(method.ReturnType);
        }
        public void EmitInvokestatic(short meth, Method method)
        {
            var argsize = (short)TypeCodeHelper.Width(method.Parameters.Select(x => x.Type));

            EmitOp(OpCodeValue.invokestatic);
            if (!alive) return;

            EmitShort(meth);

            stack.Pop(argsize);
            stack.Push(method.ReturnType);
        }
        public void EmitInvokevirtual(short meth, Method method)
        {
            var argsize = (short)TypeCodeHelper.Width(method.Parameters.Select(x => x.Type));

            EmitOp(OpCodeValue.invokevirtual);
            if (!alive) return;

            EmitShort(meth);

            stack.Pop(argsize + 1);
            stack.Push(method.ReturnType);
        }
        public void EmitInvokedynamic(short desc, Method method)
        {
            // N.B. this format is under consideration by the JSR 292 EG
            var argsize = (short)TypeCodeHelper.Width(method.Parameters.Select(x => x.Type));

            EmitOp(OpCodeValue.invokedynamic);

            if (!alive) return;

            EmitShort(desc);
            EmitShort(0);

            stack.Pop(argsize);
            stack.Push(method.ReturnType);
        }

        private void EmitOp(OpCodeValue opcode)
        {
            if (!alive) return;

            if (pendingStackMap)
            {
                pendingStackMap = false;
                EmitStackMapFrame();
            }

            EmitByte((byte)opcode);
        }
        private void EmitByte(byte b)
        {
            if (!alive) return;

            EnsureCapacity(1);

            byteCodeStream[length++] = b;
        }
        private void EmitShort(short s)
        {
            if (!alive) return;

            EnsureCapacity(2);

            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);
        }
        private void EmitInt(int s)
        {
            if (!alive) return;

            EnsureCapacity(4);

            byteCodeStream[length++] = (byte)((s >> 24) & 0xff);
            byteCodeStream[length++] = (byte)((s >> 16) & 0xff);
            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);
        }

        private void PostOp()
        {
            Debug.Assert(alive || stack.Count == 0);
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

        public CompileAttributeStackMapTable StackMapTable
        {
            get
            {
                if (stackMapTableBuffer == null || stackMapTableBuffer.Length == 0 || stackMapTableBuffer.All(x => x == null))
                {
                    return null;
                }

                return new CompileAttributeStackMapTable { Entries = stackMapTableBuffer.Where(x => x != null).ToList() };
            }
        }

        private bool pendingStackMap = false;
        public short MaxStack { get { return (short)stack.MaxStack; } }
        private TypeStack stack;

        private void UpdateStack0(OpCodeValue opcode)
        {
            switch (opcode)
            {
                case OpCodeValue.aaload:
                    {
                        stack.Pop(1);// index

                        var a = stack[stack.Count - 1];

                        stack.Pop(1);

                        //sometimes 'null type' is treated as a one-dimensional array type
                        //see Gen.visitLiteral - we should handle this case OpCodeValue.OpCodeValue.accordingly
                        var stackType = a == PrimativeTypes.Void ? new PlaceholderType { Name = "java.lang.Object" } : a;
                        stack.Push(stackType);
                    }
                    break;
                case OpCodeValue.@goto:
                    MarkDead();
                    break;
                case OpCodeValue.nop:
                case OpCodeValue.ineg:
                case OpCodeValue.lneg:
                case OpCodeValue.fneg:
                case OpCodeValue.dneg:
                    break;
                case OpCodeValue.aconst_null:
                    stack.Push(PrimativeTypes.Void);
                    break;
                case OpCodeValue.iconst_m1:
                case OpCodeValue.iconst_0:
                case OpCodeValue.iconst_1:
                case OpCodeValue.iconst_2:
                case OpCodeValue.iconst_3:
                case OpCodeValue.iconst_4:
                case OpCodeValue.iconst_5:
                case OpCodeValue.iload_0:
                case OpCodeValue.iload_1:
                case OpCodeValue.iload_2:
                case OpCodeValue.iload_3:
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.lconst_0:
                case OpCodeValue.lconst_1:
                case OpCodeValue.lload_0:
                case OpCodeValue.lload_1:
                case OpCodeValue.lload_2:
                case OpCodeValue.lload_3:
                    stack.Push(PrimativeTypes.Long);
                    break;
                case OpCodeValue.fconst_0:
                case OpCodeValue.fconst_1:
                case OpCodeValue.fconst_2:
                case OpCodeValue.fload_0:
                case OpCodeValue.fload_1:
                case OpCodeValue.fload_2:
                case OpCodeValue.fload_3:
                    stack.Push(PrimativeTypes.Float);
                    break;
                case OpCodeValue.dconst_0:
                case OpCodeValue.dconst_1:
                case OpCodeValue.dload_0:
                case OpCodeValue.dload_1:
                case OpCodeValue.dload_2:
                case OpCodeValue.dload_3:
                    stack.Push(PrimativeTypes.Double);
                    break;
                case OpCodeValue.aload_0:
                    stack.Push(GetVariable(0).Type);
                    break;
                case OpCodeValue.aload_1:
                    stack.Push(GetVariable(1).Type);
                    break;
                case OpCodeValue.aload_2:
                    stack.Push(GetVariable(2).Type);
                    break;
                case OpCodeValue.aload_3:
                    stack.Push(GetVariable(3).Type);
                    break;
                case OpCodeValue.iaload:
                case OpCodeValue.baload:
                case OpCodeValue.caload:
                case OpCodeValue.saload:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.laload:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Long);
                    break;
                case OpCodeValue.faload:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Float);
                    break;
                case OpCodeValue.daload:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Double);
                    break;
                case OpCodeValue.istore_0:
                case OpCodeValue.istore_1:
                case OpCodeValue.istore_2:
                case OpCodeValue.istore_3:
                case OpCodeValue.fstore_0:
                case OpCodeValue.fstore_1:
                case OpCodeValue.fstore_2:
                case OpCodeValue.fstore_3:
                case OpCodeValue.astore_0:
                case OpCodeValue.astore_1:
                case OpCodeValue.astore_2:
                case OpCodeValue.astore_3:
                case OpCodeValue.pop:
                case OpCodeValue.lshr:
                case OpCodeValue.lshl:
                case OpCodeValue.lushr:
                    stack.Pop(1);
                    break;
                case OpCodeValue.areturn:
                case OpCodeValue.ireturn:
                case OpCodeValue.freturn:
                    //TODO: Assert.check(state.nlocks == 0);
                    stack.Pop(1);
                    MarkDead();
                    break;
                case OpCodeValue.athrow:
                    stack.Pop(1);
                    MarkDead();
                    break;
                case OpCodeValue.lstore_0:
                case OpCodeValue.lstore_1:
                case OpCodeValue.lstore_2:
                case OpCodeValue.lstore_3:
                case OpCodeValue.dstore_0:
                case OpCodeValue.dstore_1:
                case OpCodeValue.dstore_2:
                case OpCodeValue.dstore_3:
                case OpCodeValue.pop2:
                    stack.Pop(2);
                    break;
                case OpCodeValue.lreturn:
                case OpCodeValue.dreturn:
                    //TODO: Assert.check(state.nlocks == 0);
                    stack.Pop(2);
                    MarkDead();
                    break;
                case OpCodeValue.dup:
                    stack.Push(stack[stack.Count - 1]);
                    break;
                case OpCodeValue.@return:
                    //TODO: Assert.check(state.nlocks == 0);
                    MarkDead();
                    break;
                case OpCodeValue.arraylength:
                    stack.Pop(1);
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.isub:
                case OpCodeValue.iadd:
                case OpCodeValue.imul:
                case OpCodeValue.idiv:
                case OpCodeValue.irem:
                case OpCodeValue.ishl:
                case OpCodeValue.ishr:
                case OpCodeValue.iushr:
                case OpCodeValue.iand:
                case OpCodeValue.ior:
                case OpCodeValue.ixor:
                    stack.Pop(1);
                    break;
                case OpCodeValue.aastore:
                    stack.Pop(3);
                    break;
                case OpCodeValue.land:
                case OpCodeValue.lor:
                case OpCodeValue.lxor:
                case OpCodeValue.lrem:
                case OpCodeValue.ldiv:
                case OpCodeValue.lmul:
                case OpCodeValue.lsub:
                case OpCodeValue.ladd:
                    stack.Pop(2);
                    break;
                case OpCodeValue.lcmp:
                    stack.Pop(4);
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.l2i:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.i2l:
                    stack.Pop(1);
                    stack.Push(PrimativeTypes.Long);
                    break;
                case OpCodeValue.i2f:
                    stack.Pop(1);
                    stack.Push(PrimativeTypes.Float);
                    break;
                case OpCodeValue.i2d:
                    stack.Pop(1);
                    stack.Push(PrimativeTypes.Double);
                    break;
                case OpCodeValue.l2f:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Float);
                    break;
                case OpCodeValue.l2d:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Double);
                    break;
                case OpCodeValue.f2i:
                    stack.Pop(1);
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.f2l:
                    stack.Pop(1);
                    stack.Push(PrimativeTypes.Long);
                    break;
                case OpCodeValue.f2d:
                    stack.Pop(1);
                    stack.Push(PrimativeTypes.Double);
                    break;
                case OpCodeValue.d2i:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.d2l:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Long);
                    break;
                case OpCodeValue.d2f:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Float);
                    break;
                case OpCodeValue.tableswitch:
                case OpCodeValue.lookupswitch:
                    stack.Pop(1);
                    // the caller is responsible for patching up the state
                    break;
                case OpCodeValue.dup_x1:
                    {
                        Type val1 = stack.Pop1();
                        Type val2 = stack.Pop1();
                        stack.Push(val1);
                        stack.Push(val2);
                        stack.Push(val1);
                        break;
                    }
                case OpCodeValue.bastore:
                    stack.Pop(3);
                    break;
                case OpCodeValue.i2b:
                case OpCodeValue.i2c:
                case OpCodeValue.i2s:
                    break;
                case OpCodeValue.fmul:
                case OpCodeValue.fadd:
                case OpCodeValue.fsub:
                case OpCodeValue.fdiv:
                case OpCodeValue.frem:
                    stack.Pop(1);
                    break;
                case OpCodeValue.castore:
                case OpCodeValue.iastore:
                case OpCodeValue.fastore:
                case OpCodeValue.sastore:
                    stack.Pop(3);
                    break;
                case OpCodeValue.lastore:
                case OpCodeValue.dastore:
                    stack.Pop(4);
                    break;
                case OpCodeValue.dup2:
                    if (stack[stack.Count - 1] != null)
                    {
                        var value1 = stack.Pop1();
                        var value2 = stack.Pop1();

                        stack.Push(value2);
                        stack.Push(value1);
                        stack.Push(value2);
                        stack.Push(value1);
                    }
                    else
                    {
                        var value = stack.Pop2();

                        stack.Push(value);
                        stack.Push(value);
                    }
                    break;
                case OpCodeValue.dup2_x1:
                    if (stack[stack.Count - 1] != null)
                    {
                        var value1 = stack.Pop1();
                        var value2 = stack.Pop1();
                        var value3 = stack.Pop1();

                        stack.Push(value2);
                        stack.Push(value1);
                        stack.Push(value3);
                        stack.Push(value2);
                        stack.Push(value1);
                    }
                    else
                    {
                        var value1 = stack.Pop2();
                        var value2 = stack.Pop1();

                        stack.Push(value1);
                        stack.Push(value2);
                        stack.Push(value1);
                    }
                    break;
                case OpCodeValue.dup2_x2:
                    if (stack[stack.Count - 1] != null)
                    {
                        var value1 = stack.Pop1();
                        var value2 = stack.Pop1();

                        if (stack[stack.Count - 1] != null)
                        {
                            // form 1
                            var value3 = stack.Pop1();
                            var value4 = stack.Pop1();

                            stack.Push(value2);
                            stack.Push(value1);
                            stack.Push(value4);
                            stack.Push(value3);
                            stack.Push(value2);
                            stack.Push(value1);
                        }
                        else
                        {
                            // form 3
                            var value3 = stack.Pop2();

                            stack.Push(value2);
                            stack.Push(value1);
                            stack.Push(value3);
                            stack.Push(value2);
                            stack.Push(value1);
                        }
                    }
                    else
                    {
                        var value1 = stack.Pop2();

                        if (stack[stack.Count - 1] != null)
                        {
                            // form 2
                            var value2 = stack.Pop1();
                            var value3 = stack.Pop1();

                            stack.Push(value1);
                            stack.Push(value3);
                            stack.Push(value2);
                            stack.Push(value1);
                        }
                        else
                        {
                            // form 4
                            var value2 = stack.Pop2();

                            stack.Push(value1);
                            stack.Push(value2);
                            stack.Push(value1);
                        }
                    }
                    break;
                case OpCodeValue.dup_x2:
                    {
                        var value1 = stack.Pop1();

                        if (stack[stack.Count - 1] != null)
                        {
                            // form 1
                            var value2 = stack.Pop1();
                            var value3 = stack.Pop1();

                            stack.Push(value1);
                            stack.Push(value3);
                            stack.Push(value2);
                            stack.Push(value1);
                        }
                        else
                        {
                            // form 2
                            var value2 = stack.Pop2();

                            stack.Push(value1);
                            stack.Push(value2);
                            stack.Push(value1);
                        }
                    }
                    break;
                case OpCodeValue.fcmpl:
                case OpCodeValue.fcmpg:
                    stack.Pop(2);
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.dcmpl:
                case OpCodeValue.dcmpg:
                    stack.Pop(4);
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.swap:
                    {
                        Type value1 = stack.Pop1();
                        Type value2 = stack.Pop1();
                        stack.Push(value1);
                        stack.Push(value2);
                        break;
                    }
                case OpCodeValue.dadd:
                case OpCodeValue.dsub:
                case OpCodeValue.dmul:
                case OpCodeValue.ddiv:
                case OpCodeValue.drem:
                    stack.Pop(2);
                    break;
                case OpCodeValue.ret:
                    MarkDead();
                    break;
                case OpCodeValue.wide:
                    // must be handled by the caller.
                    return;
                case OpCodeValue.monitorenter:
                case OpCodeValue.monitorexit:
                    stack.Pop(1);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private void UpdateStack1(OpCodeValue opcode, byte s)
        {
            switch (opcode)
            {
                case OpCodeValue.bipush:
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.ldc:
                    stack.Push(TypeForConstant(Manager.ConstantPool[s - 1]));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private void UpdateStack2(OpCodeValue opcode, short s)
        {
            switch (opcode)
            {
                case OpCodeValue.@new:
                case OpCodeValue.sipush:
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.ldc2_w:
                    stack.Push(TypeForConstant(Manager.ConstantPool[s - 1]));
                    break;
                case OpCodeValue.instanceof:
                    stack.Pop(1);
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.ldc_w:
                    stack.Push(TypeForConstant(Manager.ConstantPool[s - 1]));
                    break;
                default:
                    throw new NotImplementedException();
            }

        }

        private void UpdateStackBranch(OpCodeValue opcode, int b)
        {
            switch (opcode)
            {
                case OpCodeValue.@goto:
                case OpCodeValue.goto_w:
                    MarkDead();
                    break;
                case OpCodeValue.jsr:
                case OpCodeValue.jsr_w:
                    break;
                case OpCodeValue.ifnull:
                case OpCodeValue.ifnonnull:
                case OpCodeValue.ifeq:
                case OpCodeValue.ifne:
                case OpCodeValue.iflt:
                case OpCodeValue.ifge:
                case OpCodeValue.ifgt:
                case OpCodeValue.ifle:
                    stack.Pop(1);
                    break;
                case OpCodeValue.if_icmpeq:
                case OpCodeValue.if_icmpne:
                case OpCodeValue.if_icmplt:
                case OpCodeValue.if_icmpge:
                case OpCodeValue.if_icmpgt:
                case OpCodeValue.if_icmple:
                case OpCodeValue.if_acmpeq:
                case OpCodeValue.if_acmpne:
                    stack.Pop(2);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private void UpdateStackWide(OpCodeValue opcode, int s)
        {
            switch (opcode)
            {
                case OpCodeValue.iload:
                    stack.Push(PrimativeTypes.Int);
                    break;
                case OpCodeValue.lload:
                    stack.Push(PrimativeTypes.Long);
                    break;
                case OpCodeValue.fload:
                    stack.Push(PrimativeTypes.Float);
                    break;
                case OpCodeValue.dload:
                    stack.Push(PrimativeTypes.Double);
                    break;
                case OpCodeValue.aload:
                    stack.Push(GetVariable(s).Type);
                    break;
                case OpCodeValue.lstore:
                case OpCodeValue.dstore:
                    stack.Pop(2);
                    break;
                case OpCodeValue.istore:
                case OpCodeValue.fstore:
                case OpCodeValue.astore:
                    stack.Pop(1);
                    break;
                case OpCodeValue.ret:
                    MarkDead();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void MarkDead()
        {
            alive = false;
        }
        private static Type TypeForConstant(CompileConstant constant)
        {
            if (constant is CompileConstantInteger) return PrimativeTypes.Int;
            if (constant is CompileConstantFloat) return PrimativeTypes.Float;
            if (constant is CompileConstantString) return new PlaceholderType { Name = "java.lang.String" };
            if (constant is CompileConstantLong) return PrimativeTypes.Long;
            if (constant is CompileConstantDouble) return PrimativeTypes.Double;

            throw new NotImplementedException();
        }

        CompileAttributeStackMapTable.StackMapFrame[] stackMapTableBuffer;
        int stackMapBufferSize;

        internal class StackMapFrame
        {
            public int PC;
            public Type[] Locals;
            public Type[] Stack;
        }

        StackMapFrame lastFrame;
        StackMapFrame frameBeforeLast;

        private void EmitStackMapFrame()
        {
            if (lastFrame == null)
            {
                // first frame
                lastFrame = GetInitialFrame();
            }
            else if (lastFrame.PC == length)
            {
                // drop existing stackmap at this offset
                stackMapTableBuffer[--stackMapBufferSize] = null;
                lastFrame = frameBeforeLast;
                frameBeforeLast = null;
            }

            var frame = new StackMapFrame { PC = length };

            var localCount = 0;
            var locals = new Type[variableCount];
            for (var i = 0; i < variableCount; i++, localCount++)
            {
                var variable = GetVariable(i);

                if (variable == null || !variable.IsDefined) continue;

                var vtype = variable.Type;

                locals[i] = vtype;
                if (TypeCodeHelper.Width(vtype) > 1) i++;
            }

            frame.Locals = new Type[localCount];
            for (int i = 0, j = 0; i < variableCount; i++, j++)
            {
                Debug.Assert(j < localCount);
                frame.Locals[j] = locals[i];
                if (TypeCodeHelper.Width(locals[i]) > 1) i++;
            }

            var stackCount = 0;
            for (var i = 0; i < stackCount; i++)
            {
                if (stack[i] != null)
                {
                    stackCount++;
                }
            }

            frame.Stack = new Type[stackCount];
            stackCount = 0;
            for (var i = 0; i < stackCount; i++)
            {
                if (stack[i] != null)
                {
                    frame.Stack[stackCount++] = stack[i];
                }
            }

            if (stackMapTableBuffer == null)
            {
                stackMapTableBuffer = new CompileAttributeStackMapTable.StackMapFrame[20];
            }
            else if (stackMapTableBuffer.Length == stackMapBufferSize)
            {
                var newStackMapTableBuffer = new CompileAttributeStackMapTable.StackMapFrame[stackMapBufferSize << 1];

                Array.Copy(stackMapTableBuffer, 0, newStackMapTableBuffer, 0, stackMapBufferSize);

                stackMapTableBuffer = newStackMapTableBuffer;
            }
            stackMapTableBuffer[stackMapBufferSize++] = CompileAttributeStackMapTable.StackMapFrame.GetInstance(this, frame, lastFrame.PC, lastFrame.Locals);

            frameBeforeLast = lastFrame;
            lastFrame = frame;
        }
        private StackMapFrame GetInitialFrame()
        {
            var frame = new StackMapFrame();

            var argTypes = Method.Parameters.Select(x => x.Type).ToList();

            var len = argTypes.Count;
            var count = 0;

            if (!Method.Modifiers.HasFlag(Modifier.Static))
            {
                Type thisType = Method.DeclaringType;

                frame.Locals = new Type[len + 1];
                if (Method.Name == "<init>" && thisType.GetDescriptor(true) != "java/lang/Object")
                {
                    frame.Locals[count++] = UninitializedType.UninitializedThis(thisType);
                }
                else
                {
                    frame.Locals[count++] = thisType;
                }
            }
            else
            {
                frame.Locals = new Type[len];
            }

            foreach (var argType in argTypes)
            {
                frame.Locals[count++] = argType;
            }

            frame.PC = -1;
            frame.Stack = null;

            return frame;
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