using JavaCompiler.Compilation.ByteCode;
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

        public void Compile(ByteCodeGenerator generator)
        {
            var start = generator.EntryPoint();

            // Test Condition
            var item = new ConditionCompiler(node.Expression).Compile(generator);
            var loopDone = item.JumpFalse();

            generator.ResolveChain(item.TrueJumps);

            // Run Body
            generator.PushScope();

            new StatementCompiler(node.Statement).Compile(generator);
            generator.ResolveChain(generator.Branch(OpCodeValue.@goto), start);

            generator.PopScope();

            // End
            generator.ResolveChain(loopDone);
        }
    }
}