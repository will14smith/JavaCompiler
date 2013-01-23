using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    public class AssertTranslator
    {
        private readonly ITree node;

        public AssertTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int) JavaNodeType.ASSERT);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}