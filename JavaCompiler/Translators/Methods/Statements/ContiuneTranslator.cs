using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    public class ContiuneTranslator
    {
        private readonly ITree node;

        public ContiuneTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int) JavaNodeType.CONTINUE);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}