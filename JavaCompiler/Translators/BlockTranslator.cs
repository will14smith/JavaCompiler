using System.Diagnostics;
using Antlr.Runtime.Tree;

namespace JavaCompiler.Translators
{
    class BlockTranslator
    {
        private readonly ITree node;
        public BlockTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.BLOCK_SCOPE);

            this.node = node;
        }

        public ITree Walk()
        {
            return node;
        }
    }
}
