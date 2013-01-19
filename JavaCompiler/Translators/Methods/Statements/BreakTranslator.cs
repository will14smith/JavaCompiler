using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    class BreakTranslator
    {
        private readonly ITree node;
        public BreakTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.BREAK);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
