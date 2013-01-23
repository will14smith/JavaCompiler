using System;

namespace JavaCompiler.Compilation.ByteCode
{
    [Serializable]
    public struct Label
    {
        internal readonly int Index;

        internal Label(int index)
        {
            Index = index;
        }

        public int GetLabelValue()
        {
            return Index;
        }

        public override int GetHashCode()
        {
            return Index;
        }

        public override bool Equals(object obj)
        {
            return obj is Label && Equals((Label) obj);
        }

        public static bool operator ==(Label a, Label b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Label a, Label b)
        {
            return !(a == b);
        }
    }
}