namespace JavaCompiler.Reflection
{
    public class JavaTypeRef
    {
        public string TypeName { get; set; }
        public JavaType Type { get; set; }

        public int ArrayLevels { get; set; }

        public static implicit operator JavaTypeRef(string name)
        {
            return new JavaTypeRef { TypeName = name };
        }
        public static implicit operator JavaTypeRef(JavaType type)
        {
            return new JavaTypeRef { Type = type };
        }
    }
}
