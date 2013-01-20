using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class AdditiveTranslator
    {
        private readonly ITree node;
        public AdditiveTranslator(ITree node)
        {
            Debug.Assert(node.IsAdditiveExpression());

            this.node = node;
        }

        public AdditiveNode Walk()
        {
            AdditiveNode additiveNode;

            switch (node.Type)
            {
                case (int)JavaNodeType.PLUS:
                    additiveNode = new AdditiveNode.AdditivePlusNode();
                    break;
                case (int)JavaNodeType.MINUS:
                    additiveNode = new AdditiveNode.AdditiveMinusNode();
                    break;
                default:
                    throw new NotImplementedException();
            }

            additiveNode.LeftChild = new ExpressionTranslator(node.GetChild(0)).Walk();
            additiveNode.RightChild = new ExpressionTranslator(node.GetChild(1)).Walk();

            return additiveNode;
        }
    }
}
