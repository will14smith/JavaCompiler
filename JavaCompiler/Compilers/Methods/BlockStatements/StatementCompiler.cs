using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Compilers.Methods.Statements;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Translators.Methods.Tree.Statements;

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
            
            if (node is WhileNode)
            {
                return new WhileCompiler(node as WhileNode).Compile(generator);
            }


            throw new NotImplementedException();
        }
    }
}