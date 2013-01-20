using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class LogicalOrCompiler
    {
        private readonly LogicalOrNode node;
        public LogicalOrCompiler(LogicalOrNode node)
        {
            this.node = node;
        }

        public Class Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
