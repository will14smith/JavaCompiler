using System;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;

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
            DefinedType type = program.Type;

            var manager = new CompileManager();

            manager.Imports.Add(new Package { Name = type.Package == null || string.IsNullOrEmpty(type.Package.Name) ? "*" : type.Package.Name + ".*" });

            manager.Imports.AddRange(program.Imports);

            if (type is Class)
            {
                new ClassCompiler(type as Class).Compile(manager);
            }
            else
            {
                throw new NotImplementedException();
            }

            return manager.GetBytes();
        }
    }
}