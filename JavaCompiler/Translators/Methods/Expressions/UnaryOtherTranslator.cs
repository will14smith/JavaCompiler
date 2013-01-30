using System;
using System.Diagnostics;
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
                        Expression = new TranslationTranslator(node.GetChild(1)).Walk()
                    };
                case JavaNodeType.LOGICAL_NOT:
                    return new UnaryOtherNode.UnaryNotNode
                    {
                        Expression = new TranslationTranslator(node.GetChild(0)).Walk()
                    };
                default:
                    throw new NotImplementedException();
            }
        }
    }
}