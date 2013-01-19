using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    class SwitchTranslator
    {
        private readonly ITree node;
        public SwitchTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.SWITCH);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
