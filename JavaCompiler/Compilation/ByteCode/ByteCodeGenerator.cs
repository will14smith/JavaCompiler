using System;

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
            EnsureCapacity(3);
            InternalEmit(opcode);
        }


        internal void InternalEmit(OpCode opcode)
        {
            if (opcode.Size != 1)
            {
                byteCodeStream[length++] = (byte)(opcode.Value >> 8);
            }

            byteCodeStream[length++] = (byte)opcode.Value;

            UpdateStackSize(opcode, opcode.StackChange());
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
            if (opcode.EndsUncondJmpBlk())
            {
                maxStackSize += maxMidStack;
                maxMidStack = 0;
                maxMidStackCur = 0;
            }
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
            if (length + size >= byteCodeStream.Length)
            {
                if (length + size >= 2 * byteCodeStream.Length)
                {
                    byteCodeStream = EnlargeArray(byteCodeStream, length + size);
                    return;
                }

                byteCodeStream = EnlargeArray(byteCodeStream);
            }
        }

        #endregion

    }
}
