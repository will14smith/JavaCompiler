using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class LogicalOrTranslator
    {
        private readonly ITree node;
        public LogicalOrTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.LOGICAL_OR);

            this.node = node;
        }

        public LogicalOrNode Walk()
        {
            throw new NotImplementedException();
        }

    }
}
