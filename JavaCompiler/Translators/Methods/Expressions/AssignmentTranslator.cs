using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class AssignmentTranslator
    {
        private readonly ITree node;
        public AssignmentTranslator(ITree node)
        {
            Debug.Assert(node.IsAssignExpression());

            this.node = node;
        }

        public AssignmentNode Walk()
        {
            var key = new PrimaryTranslator(node.GetChild(0)).Walk();
            ExpressionNode value;

            var child = node.GetChild(1);
            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.ASSIGN:
                    value = new ExpressionTranslator(child).Walk();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new AssignmentNode
            {
                Left = key,
                Right = value
            };

        }
    }
}
