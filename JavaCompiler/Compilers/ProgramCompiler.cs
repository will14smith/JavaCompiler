using System;
using JavaCompiler.Reflection;

namespace JavaCompiler.Compilers
{
    class ProgramCompiler
    {
        private readonly JavaProgram program;
        public ProgramCompiler(JavaProgram program)
        {
            this.program = program;
        }

        public byte[] Compile()
        {
            foreach(var type in program.Types)
            {
                new TypeCompiler(type).Compile();
            }

            return null;
        }
    }
}
