using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Compilers.Methods.Statements
{
    public class AssertCompiler
    {
        private readonly AssertNode node;
        public AssertCompiler(AssertNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}