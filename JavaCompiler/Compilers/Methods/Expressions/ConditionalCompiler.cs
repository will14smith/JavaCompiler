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
            var endOfIf = generator.DefineLabel();

            var item = new ConditionCompiler(node.Condition).Compile(generator);
            var falseLabel = item.JumpFalse();

            generator.PushScope();
            var tb = new ExpressionCompiler(node.ThenExpression).Compile(generator);
            tb.Load();
            generator.Emit(OpCodeValue.@goto, endOfIf);
            generator.PopScope();

            generator.MarkLabel(falseLabel);

            generator.PushScope();
            var fb = new ExpressionCompiler(node.ElseExpression).Compile(generator);
            fb.Load();
            generator.PopScope();

            generator.MarkLabel(endOfIf);

            var type = tb.Type.FindCommonType(fb.Type);

            return new StackItem(generator, type);
        }
    }
}