using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.BlockStatements;
using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Compilers.Methods.Statements
{
    public class WhileCompiler
    {
        private readonly WhileNode node;
        public WhileCompiler(WhileNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            var startOfWhile = generator.DefineLabel();

            generator.MarkLabel(startOfWhile);
            // Test Condition
            var condItem = new ConditionCompiler(node.Expression).Compile(generator);
            var endOfWhile = condItem.JumpFalse();

            // Run Body
            generator.PushScope();

            if (node.Statement is MethodTree)
            {
                new BlockCompiler(node.Statement as MethodTree).Compile(generator);
            }
            else if (node.Statement is StatementNode)
            {
                new StatementCompiler(node.Statement as StatementNode).Compile(generator);
            }
            else
            {
                throw new NotImplementedException();
            }

            generator.PopScope();
            generator.Emit(OpCodes.@goto, startOfWhile);

            // End
            generator.MarkLabel(endOfWhile);

            return new VoidItem(generator);
        }
    }
}