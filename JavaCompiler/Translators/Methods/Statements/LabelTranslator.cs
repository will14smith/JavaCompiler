using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators.Methods.Statements
{
    public class LabelTranslator
    {
        private readonly ITree node;
        public LabelTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.LABELED_STATEMENT);

            this.node = node;
        }

        public MethodTree Walk()
        {
            throw new NotImplementedException();
        }
    }
}
