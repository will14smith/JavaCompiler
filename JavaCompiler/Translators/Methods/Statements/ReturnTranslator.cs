using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    class ReturnTranslator
    {
        private readonly ITree node;
        public ReturnTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.RETURN);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
