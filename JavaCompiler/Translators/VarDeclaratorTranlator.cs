using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators
{
    class VarDeclaratorTranlator
    {
        private readonly ITree node;
        public VarDeclaratorTranlator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.VAR_DECLARATOR);

            this.node = node;
        }

        public JavaMember Walk()
        {
            throw new NotImplementedException();
        }
    }
}
