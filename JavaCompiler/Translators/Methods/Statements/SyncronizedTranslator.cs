using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    public class SyncronizedTranslator
    {
        private readonly ITree node;
        public SyncronizedTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.SYNCHRONIZED);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
