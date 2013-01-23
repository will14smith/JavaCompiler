using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilers.Items;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class AndCompiler
    {
        private readonly AndNode node;
        public AndCompiler(AndNode node)
        {
            this.node = node;
        }

        public Item  Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
