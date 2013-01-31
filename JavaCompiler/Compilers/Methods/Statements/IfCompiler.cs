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

        public void Compile(ByteCodeGenerator generator)
        {
            var item = new ConditionCompiler(node.Condition).Compile(generator);
            var elseChain = item.JumpFalse();

            Chain thenExit = null;
            if (!item.IsFalse())
            {
                generator.ResolveChain(item.TrueJumps);

                generator.PushScope();

                new StatementCompiler(node.TrueBranch).Compile(generator);
                thenExit = generator.Branch(OpCodeValue.@goto);

                generator.PopScope();
            }
            if (elseChain != null)
            {
                generator.ResolveChain(elseChain);

                generator.PushScope();
                new StatementCompiler(node.FalseBranch).Compile(generator);
                generator.PopScope();
            }

            generator.ResolveChain(thenExit);
        }
    }
}