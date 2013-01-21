using System;
using System.Linq;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection;

namespace JavaCompiler.Compilers
{
    public class ProgramCompiler
    {
        private readonly Program program;
        public ProgramCompiler(Program program)
        {
            this.program = program;
        }

        public byte[] Compile()
        {
            var type = program.Type;

            var manager = new CompileManager();

            if (type is Class)
            {
                new ClassCompiler(type as Class).Compile(manager);
            }
            else
            {
                throw new NotImplementedException();
            }

            manager.AddAttribute(new CompileAttributeSourceFile { SourceFile = manager.AddConstantUtf8("Exercise1.java") });

            return manager.GetBytes();
        }
    }
}
