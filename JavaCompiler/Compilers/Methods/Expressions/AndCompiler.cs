using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class AndCompiler
    {
        private readonly AndNode node;
        public AndCompiler(AndNode node)
        {
            this.node = node;
        }

        public Type  Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
