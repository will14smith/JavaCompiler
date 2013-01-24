namespace JavaCompiler.Reflection.Types
{
    public class Array : Type
    {
        public Array()
        {
        }

        public Array(Type arrayType)
        {
            ArrayType = arrayType;
        }

        public Type ArrayType { get; set; }

        public override string GetDescriptor(bool shortDescriptor = false)
        {
            return "[" + ArrayType.GetDescriptor(shortDescriptor);
        }
    }
}
