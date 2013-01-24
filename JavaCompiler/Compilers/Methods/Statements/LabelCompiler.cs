using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Compilers.Methods.Statements
{
    public class LabelCompiler
    {
        private readonly LabelNode node;

        public LabelCompiler(LabelNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}