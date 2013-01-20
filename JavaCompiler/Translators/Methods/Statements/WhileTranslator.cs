using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.BlockStatements;
using JavaCompiler.Translators.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Translators.Methods.Statements
{
    public class WhileTranslator
    {
        private readonly ITree node;
        public WhileTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.WHILE);

            this.node = node;
        }

        public WhileNode Walk()
        {
            var condition = new ExpressionTranslator(node.GetChild(0)).Walk();
            var statement = new StatementTranslator(node.GetChild(1)).Walk();

            return new WhileNode
                       {
                           Expression = condition,
                           Statement = statement,
                       };
        }
    }
}
