using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    class ForEachTranslator
    {
        private readonly ITree node;
        public ForEachTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.FOR_EACH);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
