using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    class TryTranslator
    {
        private readonly ITree node;
        public TryTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.TRY);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
