using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class XorCompiler
    {
        private readonly XorNode node;
        public XorCompiler(XorNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }

    }
}
