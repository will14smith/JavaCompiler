using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class EqualityTranslator
    {
        private readonly ITree node;
        public EqualityTranslator(ITree node)
        {
            Debug.Assert(node.IsEqualityExpression());

            this.node = node;
        }

        public EqualityNode Walk()
        {
            EqualityNode equalityNode;

            switch (node.Type)
            {
                case (int)JavaNodeType.EQUAL:
                    equalityNode = new EqualityNode.EqualityEqualNode();
                    break;
                case (int)JavaNodeType.NOT_EQUAL:
                    equalityNode = new EqualityNode.EqualityNotEqualNode();
                    break;
                default:
                    throw new NotImplementedException();
            }

            equalityNode.LeftChild = new ExpressionTranslator(node.GetChild(0)).Walk();
            equalityNode.RightChild = new ExpressionTranslator(node.GetChild(1)).Walk();

            return equalityNode;
        }
    }
}
