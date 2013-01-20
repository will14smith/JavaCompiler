using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class NewCompiler
    {
        private readonly NewNode node;
        public NewCompiler(NewNode node)
        {
            this.node = node;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
