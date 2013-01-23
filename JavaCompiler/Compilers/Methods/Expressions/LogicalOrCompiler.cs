using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilers.Items;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class LogicalOrCompiler
    {
        private readonly LogicalOrNode node;
        public LogicalOrCompiler(LogicalOrNode node)
        {
            this.node = node;
        }

        public Item  Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
