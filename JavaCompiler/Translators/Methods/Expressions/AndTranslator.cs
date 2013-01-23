using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class AndTranslator
    {
        private readonly ITree node;

        public AndTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int) JavaNodeType.AND);

            this.node = node;
        }

        public AndNode Walk()
        {
            throw new NotImplementedException();
        }
    }
}