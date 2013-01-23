using System.Diagnostics;
using Antlr.Runtime.Tree;

namespace JavaCompiler.Translators
{
    public class IdentifierTranslator
    {
        private readonly ITree node;

        public IdentifierTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int) JavaNodeType.IDENT);

            this.node = node;
        }

        public string Walk()
        {
            return node.Text;
        }
    }
}