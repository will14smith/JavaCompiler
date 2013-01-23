using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilers.Items;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class EqualityCompiler
    {
        private readonly EqualityNode node;
        public EqualityCompiler(EqualityNode node)
        {
            this.node = node;
        }

        public Item  Compile(ByteCodeGenerator generator)
        {
            throw new NotImplementedException();
        }
    }
}
