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
            RelationNode relationNode;

            switch((JavaNodeType)node.Type)
            {
                case JavaNodeType.LESS_OR_EQUAL:
                    relationNode = new RelationNode.LessThanEqNode();
                    break;
                case JavaNodeType.GREATER_OR_EQUAL:
                    relationNode = new RelationNode.GreaterThanEqNode();
                    break;
                case JavaNodeType.LESS_THAN:
                    relationNode = new RelationNode.LessThanNode();
                    break;
                case JavaNodeType.GREATER_THAN:
                    relationNode = new RelationNode.GreaterThanNode();
                    break;
                default:
                    throw new NotImplementedException();
            }

            relationNode.LeftChild = new TranslationTranslator(node.GetChild(0)).Walk();
            relationNode.RightChild = new TranslationTranslator(node.GetChild(1)).Walk();

            return relationNode;
        }
    }
}