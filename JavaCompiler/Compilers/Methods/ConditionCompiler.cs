using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods
{
    class ConditionCompiler
    {
        private readonly ExpressionNode node;
        public ConditionCompiler(ExpressionNode node)
        {
            this.node = node;
        }

        public ConditionalItem Compile(ByteCodeGenerator generator)
        {
            var item = new ExpressionCompiler(node).Compile(generator);

            return item.Conditional();
        }
    }
}
