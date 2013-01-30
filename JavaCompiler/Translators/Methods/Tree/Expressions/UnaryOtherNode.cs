using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class UnaryOtherNode : ExpressionNode
    {
        #region Nested type: UnaryCastNode

        public class UnaryCastNode : UnaryOtherNode
        {
            public Type Type { get; set; }
            public TranslateNode Expression { get; set; }
        }

        #endregion

        public class UnaryNotNode : UnaryOtherNode
        {
            public TranslateNode Expression { get; set; }
        }
    }
}