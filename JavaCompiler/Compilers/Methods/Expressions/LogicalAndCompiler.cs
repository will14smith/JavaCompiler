using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilers.Items;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class LogicalAndCompiler
    {
        private readonly LogicalAndNode node;
        public LogicalAndCompiler(LogicalAndNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
