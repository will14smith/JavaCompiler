using JavaCompiler.Reflection;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class UnaryOtherNode : ExpressionNode
    {

        public class UnaryCastNode : UnaryOtherNode
        {
            public Class Type { get; set; }
            public ExpressionNode Expression { get; set; }

            public override void ValidateType()
            {
                ReturnType = Type;
            }
        }
    }
}
