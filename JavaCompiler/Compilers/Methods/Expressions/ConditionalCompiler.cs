using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class ConditionalCompiler
    {
        private readonly ConditionalNode node;

        public ConditionalCompiler(ConditionalNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            Chain thenExit = null;

            var item = new ConditionCompiler(node.Condition).Compile(generator);
            var elseChain = item.JumpFalse();

            Item x = null;
            if (!item.IsFalse())
            {
                generator.ResolveChain(item.TrueJumps);

                x = new ExpressionCompiler(node.ThenExpression).Compile(generator).Load();

                thenExit = generator.Branch(OpCodeValue.@goto);
            }
            if (elseChain != null)
            {
                generator.ResolveChain(elseChain);

                x = new ExpressionCompiler(node.ElseExpression).Compile(generator).Load();
            }
            generator.ResolveChain(thenExit);

            //var type = tb.Type.FindCommonType(fb.Type);
            var type = x.Type;

            return new StackItem(generator, type);
        }
    }
}