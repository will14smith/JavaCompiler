using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class ConditionalNode : ExpressionNode
    {
        public TranslateNode Condition { get; set; }
        public ExpressionNode ThenExpression { get; set; }
        public ExpressionNode ElseExpression { get; set; }

        public override Type GetType(ByteCodeGenerator manager)
        {
            return ThenExpression.GetType(manager).FindCommonType(ElseExpression.GetType(manager));
        }
    }
}