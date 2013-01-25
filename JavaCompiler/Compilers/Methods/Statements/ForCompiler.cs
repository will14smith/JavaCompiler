using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Compilers.Methods.Statements
{
    public class ForCompiler
    {
        private readonly ForNode node;
        public ForCompiler(ForNode node)
        {
            this.node = node;
        }

        public void Compile(ByteCodeGenerator generator)
        {

            generator.PushScope();
            new StatementCompiler(node.Initialiser).Compile(generator);

            var startOfFor = generator.MarkLabel();
            var condition = new ConditionCompiler(node.Condition).Compile(generator);
            var falseLabel = condition.JumpFalse();

            new StatementCompiler(node.Updater).Compile(generator);
            new StatementCompiler(node.Statement).Compile(generator);

            generator.Emit(OpCodeValue.@goto, startOfFor);
            generator.PopScope();

            generator.MarkLabel(falseLabel);
        }
    }
}