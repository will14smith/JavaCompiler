using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class UnaryOtherNode : ExpressionNode
    {
        #region Nested type: UnaryCastNode

        public class UnaryCastNode : UnaryOtherNode
        {
            public Type Type { get; set; }
            public ExpressionNode Expression { get; set; }
        }

        #endregion
    }
}