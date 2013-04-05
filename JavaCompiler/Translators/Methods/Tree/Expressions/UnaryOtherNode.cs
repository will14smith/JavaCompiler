using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class UnaryOtherNode : ExpressionNode
    {
        #region Nested type: UnaryCastNode

        public class UnaryCastNode : UnaryOtherNode
        {
            public override Type GetType(ByteCodeGenerator manager)
            {
                return Type;
            }

            public TranslateNode Expression { get; set; }
            public Type Type { get; set; }
        }

        #endregion

        public class UnaryNotNode : UnaryOtherNode
        {
            public TranslateNode Expression { get; set; }

            public override Type GetType(ByteCodeGenerator manager)
            {
                return PrimativeTypes.Boolean;
            }
        }
    }
}