using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class MultiplicativeTranslator
    {
        private readonly ITree node;

        public MultiplicativeTranslator(ITree node)
        {
            Debug.Assert(node.IsMultiplicativeExpression());

            this.node = node;
        }

        public MultiplicativeNode Walk()
        {
            MultiplicativeNode multiplicativeNode;

            switch (node.Type)
            {
                case (int) JavaNodeType.STAR:
                    multiplicativeNode = new MultiplicativeNode.MultiplicativeMultiplyNode();
                    break;
                case (int) JavaNodeType.DIV:
                    multiplicativeNode = new MultiplicativeNode.MultiplicativeDivideNode();
                    break;
                case (int) JavaNodeType.MOD:
                    multiplicativeNode = new MultiplicativeNode.MultiplicativeModNode();
                    break;
                default:
                    throw new NotImplementedException();
            }

            multiplicativeNode.LeftChild = new ExpressionTranslator(node.GetChild(0)).Walk();
            multiplicativeNode.RightChild = new ExpressionTranslator(node.GetChild(1)).Walk();

            return multiplicativeNode;
        }
    }
}