using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    public class ThrowTranslator
    {
        private readonly ITree node;
        public ThrowTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.THROW);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
