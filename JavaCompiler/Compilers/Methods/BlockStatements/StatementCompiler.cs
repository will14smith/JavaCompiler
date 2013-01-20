using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.BlockStatements
{
    public class StatementCompiler
    {
        private readonly StatementNode node;
        public StatementCompiler(StatementNode node)
        {
            this.node = node;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            if (node is ExpressionNode)
            {
                var returnType = new ExpressionCompiler(node as ExpressionNode).Compile(generator);
                Common.Cast(returnType, node.ReturnType, generator);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
