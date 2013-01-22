using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class UnaryCompiler
    {
        private readonly UnaryNode node;
        public UnaryCompiler(UnaryNode node)
        {
            this.node = node;
        }

        public Type Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
