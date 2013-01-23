using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class RelationTranslator
    {
        private readonly ITree node;

        public RelationTranslator(ITree node)
        {
            Debug.Assert(node.IsRelationalExpression());

            this.node = node;
        }

        public RelationNode Walk()
        {
            throw new NotImplementedException();
        }
    }
}