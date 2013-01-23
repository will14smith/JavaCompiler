using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
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

        public Item Compile(ByteCodeGenerator generator)
        {
            if (node is ExpressionNode)
            {
                return new ExpressionCompiler(node as ExpressionNode).Compile(generator);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}