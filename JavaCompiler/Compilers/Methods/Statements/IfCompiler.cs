using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Compilers.Methods.Statements
{
    public class IfCompiler
    {
        private readonly IfNode node;
        public IfCompiler(IfNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            var endOfIf = generator.DefineLabel();

            var item = new ConditionCompiler(node.Condition).Compile(generator);
            var falseLabel = item.JumpFalse();

            generator.PushScope();
            new StatementCompiler(node.TrueBranch).Compile(generator);
            generator.Emit(OpCodeValue.@goto, endOfIf);
            generator.PopScope();

            generator.MarkLabel(falseLabel);

            if (node.FalseBranch != null)
            {
                generator.PushScope();
                new StatementCompiler(node.FalseBranch).Compile(generator);
                generator.PopScope();
            }

            generator.MarkLabel(endOfIf);

            return null;
        }
    }
}