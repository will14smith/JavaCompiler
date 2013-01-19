using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    class DoTranslator
    {
        private readonly ITree node;
        public DoTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.DO);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
