using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class OrTranslator
    {
        private readonly ITree node;
        public OrTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.OR);

            this.node = node;
        }

        public OrNode Walk()
        {
            throw new NotImplementedException();
        }
    }
}
