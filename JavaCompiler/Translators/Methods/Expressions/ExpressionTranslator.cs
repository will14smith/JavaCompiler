using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    class ExpressionTranslator
    {
        private readonly ITree node;
        public ExpressionTranslator(ITree node)
        {
            Debug.Assert(node.IsExpression());

            this.node = node;
        }
        
        public ExpressionNode Walk()
        {
            throw new NotImplementedException();
        }
    }
}
