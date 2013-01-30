using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods
{
    class ConditionCompiler
    {
        private readonly TranslateNode node;
        public ConditionCompiler(TranslateNode node)
        {
            this.node = node;
        }

        public ConditionalItem Compile(ByteCodeGenerator generator)
        {
            var item = new TranslationCompiler(node, PrimativeTypes.Boolean).Compile(generator);

            return item.Conditional();
        }
    }
}
