using System;
using System.Linq;
using JavaCompiler.Compilation;
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
            var type = program.Types.First();

            var manager = new CompileManager();

            if (type is JavaClass)
            {
                new ClassCompiler(type as JavaClass).Compile(manager);
            }
            else
            {
                throw new NotImplementedException();
            }

            return manager.GetBytes();
        }
    }
}
