using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.BlockStatements
{
    class ConstructorBlockTranslator
    {
        private readonly ITree node;
        public ConstructorBlockTranslator(ITree node)
        {
            Debug.Assert(node.IsBlock());

            this.node = node;
        }

        public MethodTree Walk()
        {
            return new BlockTranslator(node).Walk();
        }
    }
}
