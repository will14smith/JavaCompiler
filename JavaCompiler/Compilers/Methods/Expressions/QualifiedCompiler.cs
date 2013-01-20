using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class QualifiedCompiler
    {
        private readonly QualifiedNode node;
        public QualifiedCompiler(QualifiedNode node)
        {
            this.node = node;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
