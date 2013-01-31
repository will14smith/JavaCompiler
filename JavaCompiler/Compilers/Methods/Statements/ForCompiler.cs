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

            var start = generator.CurrentPC();
            new StatementCompiler(node.Initialiser).Compile(generator);

            var item = new ConditionCompiler(node.Condition).Compile(generator);
            var loopDone = item.JumpFalse();

            generator.ResolveChain(item.TrueJumps);

            new StatementCompiler(node.Body).Compile(generator);
            new StatementCompiler(node.Updater).Compile(generator);

            generator.ResolveChain(generator.Branch(OpCodeValue.@goto), start);

            generator.PopScope();

            generator.ResolveChain(loopDone);
        }
    }
}