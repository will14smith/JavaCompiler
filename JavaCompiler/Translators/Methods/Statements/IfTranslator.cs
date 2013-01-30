using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.BlockStatements;
using JavaCompiler.Translators.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Translators.Methods.Statements
{
    public class IfTranslator
    {
        private readonly ITree node;

        public IfTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int) JavaNodeType.IF);

            this.node = node;
        }

        public IfNode Walk()
        {
            var ifNode = new IfNode
                             {
                                 Condition = new TranslationTranslator(node.GetChild(0)).Walk(),
                                 TrueBranch = new StatementTranslator(node.GetChild(1)).Walk()
                             };

            if (node.ChildCount > 2)
            {
                ifNode.FalseBranch = new StatementTranslator(node.GetChild(2)).Walk();
            }

            return ifNode;
        }
    }
}