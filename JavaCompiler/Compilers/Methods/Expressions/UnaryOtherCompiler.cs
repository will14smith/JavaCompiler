using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class UnaryOtherCompiler
    {
        private readonly UnaryOtherNode node;

        public UnaryOtherCompiler(UnaryOtherNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            if(node is UnaryOtherNode.UnaryCastNode)
            {
                var cast = node as UnaryOtherNode.UnaryCastNode;

                return new ExpressionCompiler(cast.Expression).Compile(generator).Coerce(cast.Type).Load();
            }

            throw new NotImplementedException();
        }
    }
}