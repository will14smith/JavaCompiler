using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class UnaryCompiler
    {
        private readonly UnaryNode node;
        public UnaryCompiler(UnaryNode node)
        {
            this.node = node;
        }

        public Class Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
