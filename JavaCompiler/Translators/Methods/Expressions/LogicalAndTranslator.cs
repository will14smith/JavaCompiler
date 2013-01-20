using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class LogicalAndTranslator
    {
        private readonly ITree node;
        public LogicalAndTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.LOGICAL_AND);

            this.node = node;
        }

        public AssignmentNode Walk()
        {
            throw new NotImplementedException();
        }

    }
}
