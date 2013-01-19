using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    class ForTranslator
    {
        private readonly ITree node;
        public ForTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.FOR);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
