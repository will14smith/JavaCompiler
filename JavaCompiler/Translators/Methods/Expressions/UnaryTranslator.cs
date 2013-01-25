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
            UnaryNode unaryNode;

            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.UNARY_PLUS:
                    unaryNode = new UnaryNode.PlusNode();
                    break;
                case JavaNodeType.UNARY_MINUS:
                    unaryNode = new UnaryNode.MinusNode();
                    break;
                case JavaNodeType.PRE_INC:
                    unaryNode = new UnaryNode.PreIncNode();
                    break;
                case JavaNodeType.PRE_DEC:
                    unaryNode = new UnaryNode.PreDecNode();
                    break;
                case JavaNodeType.POST_INC:
                    unaryNode = new UnaryNode.PostIncNode();
                    break;
                case JavaNodeType.POST_DEC:
                    unaryNode = new UnaryNode.PostDecNode();
                    break;
                default:
                    throw new NotImplementedException();
            }

            unaryNode.Child = new ExpressionTranslator(node.GetChild(0)).Walk();

            return unaryNode;
        }
    }
}