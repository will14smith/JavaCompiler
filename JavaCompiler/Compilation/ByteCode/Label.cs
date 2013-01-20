using System;

namespace JavaCompiler.Compilation.ByteCode
{
    [Serializable]
    public struct Label
    {
        internal int label;

        internal Label(int label)
        {
            this.label = label;
        }

        public int GetLabelValue()
        {
            return label;
        }

        public override int GetHashCode()
        {
            return label;
        }
        public override bool Equals(object obj)
        {
            return obj is Label && Equals((Label)obj);
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
