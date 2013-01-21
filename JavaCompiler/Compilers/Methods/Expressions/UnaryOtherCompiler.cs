using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using Type = JavaCompiler.Reflection.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class UnaryOtherCompiler
    {
        private readonly UnaryOtherNode node;
        public UnaryOtherCompiler(UnaryOtherNode node)
        {
            this.node = node;
        }

        public Type Compile(ByteCodeGenerator generator)
        {
            if (node is UnaryOtherNode.UnaryCastNode)
            {
                var stackType = new ExpressionCompiler((node as UnaryOtherNode.UnaryCastNode).Expression).Compile(generator);
                Common.Cast(stackType, node.ReturnType, generator, true);

                return node.ReturnType;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
