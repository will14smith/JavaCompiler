using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class VariableInitialiserCompiler
    {
        private readonly VariableInitialiserNode node;
        public VariableInitialiserCompiler(VariableInitialiserNode node)
        {
            this.node = node;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
