using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class UnaryTranslator
    {
        private readonly ITree node;
        public UnaryTranslator(ITree node)
        {
            Debug.Assert(node.IsUnaryExpression());

            this.node = node;
        }

        public UnaryNode Walk()
        {
            throw new NotImplementedException();
        }
    }
}
