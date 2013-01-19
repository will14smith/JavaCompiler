using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    class WhileTranslator
    {
        private readonly ITree node;
        public WhileTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.WHILE);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
