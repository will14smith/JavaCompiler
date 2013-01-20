using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class XorTranslator
    {
        private readonly ITree node;
        public XorTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.XOR);

            this.node = node;
        }

        public XorNode Walk()
        {
            throw new NotImplementedException();
        }
    }
}
