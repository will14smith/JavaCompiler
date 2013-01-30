using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class ConditionalTranslator
    {
        private readonly ITree node;

        public ConditionalTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.QUESTION);

            this.node = node;
        }

        public ConditionalNode Walk()
        {
            return new ConditionalNode
            {
                Condition = new TranslationTranslator(node.GetChild(0)).Walk(),

                ThenExpression = new ExpressionTranslator(node.GetChild(1)).Walk(),
                ElseExpression = new ExpressionTranslator(node.GetChild(2)).Walk()
            };
        }
    }
}