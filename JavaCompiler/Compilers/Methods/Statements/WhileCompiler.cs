using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.BlockStatements;
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
            var startOfWhile = generator.MarkLabel();

            // Test Condition
            var condItem = new ConditionCompiler(node.Expression).Compile(generator);
            var endOfWhile = condItem.JumpFalse();

            // Run Body
            generator.PushScope();

            new StatementCompiler(node.Statement).Compile(generator);

            generator.PopScope();
            generator.Emit(OpCodeValue.@goto, startOfWhile);

            // End
            generator.MarkLabel(endOfWhile);

            return new VoidItem(generator);
        }
    }
}