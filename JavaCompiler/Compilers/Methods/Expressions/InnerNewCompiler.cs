using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class InnerNewCompiler
    {
        private readonly InnerNewNode node;
        public InnerNewCompiler(InnerNewNode node)
        {
            this.node = node;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
