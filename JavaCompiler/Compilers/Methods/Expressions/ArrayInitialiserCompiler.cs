using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class ArrayInitialiserCompiler
    {
        private readonly ArrayInitialiserNode node;

        public ArrayInitialiserCompiler(ArrayInitialiserNode node)
        {
            this.node = node;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}