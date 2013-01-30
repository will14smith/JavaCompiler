using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods
{
    class TranslationTranslator
    {
        private readonly ITree node;
        public TranslationTranslator(ITree node)
        {
            this.node = node;
        }

        public TranslateNode Walk()
        {
            return new TranslateNode
            {
                Child = new ExpressionTranslator(node).Walk()
            };
        }
    }
}
