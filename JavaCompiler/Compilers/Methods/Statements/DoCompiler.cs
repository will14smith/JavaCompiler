using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Compilers.Methods.Statements
{
    public class DoCompiler
    {
        private readonly DoNode node;
        public DoCompiler(DoNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}