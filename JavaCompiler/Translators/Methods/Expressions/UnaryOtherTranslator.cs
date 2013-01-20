using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class UnaryOtherTranslator
    {
        private readonly ITree node;
        public UnaryOtherTranslator(ITree node)
        {
            Debug.Assert(node.IsUnaryOtherExpression());

            this.node = node;
        }

        public UnaryOtherNode Walk()
        {
            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.CAST_EXPR:
                    return new UnaryOtherNode.UnaryCastNode
                    {
                        Type = new TypeTranslator(node.GetChild(0)).Walk(),
                        Expression = new ExpressionTranslator(node.GetChild(1)).Walk()
                    };
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
