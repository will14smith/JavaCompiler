using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.BlockStatements;
using JavaCompiler.Translators.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Translators.Methods.Statements
{
    public class ForTranslator
    {
        private readonly ITree node;

        public ForTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.FOR);

            this.node = node;
        }

        public ForNode Walk()
        {
            return new ForNode
            {
                Initialiser = WalkInit(node.GetChild(0)),
                Condition = WalkCond(node.GetChild(1)),
                Updater = WalkUpdater(node.GetChild(2)),

                Statement = new StatementTranslator(node.GetChild(3)).Walk()
            };

        }

        private static MethodTree WalkInit(ITree initNode)
        {
            Debug.Assert(initNode.Type == (int)JavaNodeType.FOR_INIT);

            if (initNode.ChildCount == 0)
            {
                return null;
            }

            var child = initNode.GetChild(0);

            var exprs = new MethodTree();
            if (child.Type == (int)JavaNodeType.VAR_DECLARATION)
            {
                new VarDeclarationTranslator(child).Walk().ForEach(exprs.Add);
            }
            else
            {

                for (var i = 0; i < initNode.ChildCount; i++)
                {
                    exprs.Add(new ExpressionTranslator(initNode.GetChild(i)).Walk());
                }

            }
            return exprs;
        }
        private static TranslateNode WalkCond(ITree condNode)
        {
            Debug.Assert(condNode.Type == (int)JavaNodeType.FOR_CONDITION);

            return condNode.ChildCount == 1
                ? new TranslationTranslator(condNode.GetChild(0)).Walk()
                : null;
        }
        private static MethodTree WalkUpdater(ITree updaterNode)
        {
            Debug.Assert(updaterNode.Type == (int)JavaNodeType.FOR_UPDATE);

            var exprs = new MethodTree();

            for (var i = 0; i < updaterNode.ChildCount; i++)
            {
                exprs.Add(new ExpressionTranslator(updaterNode.GetChild(i)).Walk());
            }

            return exprs;
        }
    }
}