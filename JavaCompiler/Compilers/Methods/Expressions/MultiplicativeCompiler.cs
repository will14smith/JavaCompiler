using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilers.Items;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class MultiplicativeCompiler
    {
        private readonly MultiplicativeNode node;
        public MultiplicativeCompiler(MultiplicativeNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
