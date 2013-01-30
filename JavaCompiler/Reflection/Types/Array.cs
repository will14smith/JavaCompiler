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

        public override bool IsAssignableTo(Type c)
        {
            var array = c as Array;

            return array != null && ArrayType.IsAssignableTo(array.ArrayType);
        }

        public override string GetDescriptor(bool shortDescriptor = false)
        {
            return "[" + ArrayType.GetDescriptor(shortDescriptor);
        }

        public override string ToString()
        {
            return GetDescriptor();
        }
    }
}
