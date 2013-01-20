using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Translators.Methods.Statements
{
    public class ReturnTranslator
    {
        private readonly ITree node;
        public ReturnTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.RETURN);

            this.node = node;
        }

        public ReturnNode Walk()
        {
            var returnNode = new ReturnNode();

            if(node.ChildCount > 0)
            {
                returnNode.Value = new ExpressionTranslator(node.GetChild(0)).Walk();
            }

            return returnNode;
        }
    }
}
