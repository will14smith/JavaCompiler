using System;
using JavaCompiler.Reflection;

namespace JavaCompiler.Compilers
{
    class TypeCompiler
    {
        private readonly JavaType type;
        public TypeCompiler(JavaType type)
        {
            this.type = type;
        }

        public byte[] Compile()
        {
            var compilerManager = new CompilerManager();

            if(type is JavaClass)
            {
                return new ClassCompiler(type as JavaClass).Compile(compilerManager);
            }

            throw new NotImplementedException();
        }
    }
}
