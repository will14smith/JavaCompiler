using System;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Compilers.Methods.Statements
{
    public class ContinueCompiler
    {
        private readonly ContinueNode node;

        public ContinueCompiler(ContinueNode node)
        {
            this.node = node;
        }

        public Item Compile()
        {
            throw new NotImplementedException();
        }
    }
}