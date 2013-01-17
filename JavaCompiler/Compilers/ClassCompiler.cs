using JavaCompiler.Reflection;

namespace JavaCompiler.Compilers
{
    class ClassCompiler
    {
        private readonly JavaClass @class;
        public ClassCompiler(JavaClass @class)
        {
            this.@class = @class;
        }

        public byte[] Compile()
        {
            return null;
        }
    }
}
