using System;
using System.Diagnostics;

namespace JavaCompiler.Compilation.ByteCode
{
    public class ByteCodeGenerator
    {
        private int length;
        private byte[] byteCodeStream;

        public ByteCodeGenerator()
        {
            byteCodeStream = new byte[64];
            length = 0;

            labelCount = 0;
            labelList = null;
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

        #region Emit
        public virtual void Emit(OpCode opcode)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Unused ||
                opcode.Mode == OpCodeMode.Simple);

            EnsureCapacity(1);

            InternalEmit(opcode);
        }
        public virtual void Emit(OpCode opcode, byte b)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Constant_1 ||
                opcode.Mode == OpCodeMode.Immediate_1 ||
                opcode.Mode == OpCodeMode.Local_1);

            EnsureCapacity(2);

            InternalEmit(opcode);
            byteCodeStream[length++] = b;
        }
        public virtual void Emit(OpCode opcode, byte b1, byte b2)
        {
            Debug.Assert(opcode.Mode == OpCodeMode.Local_1_Immediate_1);

            EnsureCapacity(3);

            InternalEmit(opcode);
            byteCodeStream[length++] = b1;
            byteCodeStream[length++] = b2;
        }
        public virtual void Emit(OpCode opcode, short s)
        {
            Debug.Assert(
                opcode.Mode == OpCodeMode.Constant_2 ||
                opcode.Mode == OpCodeMode.Immediate_2);

            EnsureCapacity(3);

            InternalEmit(opcode);
            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);
        }
        public virtual void Emit(OpCode opcode, short s, byte b)
        {
            Debug.Assert(opcode.Mode == OpCodeMode.Constant_2_Immediate_1);

            EnsureCapacity(4);

            InternalEmit(opcode);
            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);
            byteCodeStream[length++] = b;
        }
        public virtual void Emit(OpCode opcode, short s, byte b1, byte b2)
        {
            Debug.Assert(opcode.Mode == OpCodeMode.Constant_2_1_1);

            EnsureCapacity(5);

            InternalEmit(opcode);
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

            InternalEmit(opcode);
            if (opcode.Mode == OpCodeMode.Branch_4)
            {
                byteCodeStream[length++] = (byte) ((i >> 24) & 0xff);
                byteCodeStream[length++] = (byte) ((i >> 16) & 0xff);
            }
            byteCodeStream[length++] = (byte)((i >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(i & 0xff);
        }

        public virtual void EmitWide(OpCode opcode, short s)
        {
            Debug.Assert(opcode.WideMode == OpCodeModeWide.Local_2);

            EnsureCapacity(4);

            InternalEmit(OpCodes.wide);
            InternalEmit(opcode);
            byteCodeStream[length++] = (byte)((s >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s & 0xff);

        }
        public virtual void EmitWide(OpCode opcode, short s1, short s2)
        {
            Debug.Assert(opcode.WideMode == OpCodeModeWide.Local_2_Immediate_2);

            EnsureCapacity(6);

            InternalEmit(OpCodes.wide);
            InternalEmit(opcode);
            byteCodeStream[length++] = (byte)((s1 >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s1 & 0xff);
            byteCodeStream[length++] = (byte)((s2 >> 8) & 0xff);
            byteCodeStream[length++] = (byte)(s2 & 0xff);
        }
        
        internal void InternalEmit(OpCode opcode)
        {
            byteCodeStream[length++] = (byte)opcode.Value;

            //TODO: UpdateStackSize(opcode, opcode.StackChange());
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
