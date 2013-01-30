namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class AdditiveNode : ExpressionNode
    {
        public TranslateNode LeftChild { get; set; }
        public TranslateNode RightChild { get; set; }

        #region Nested type: AdditiveMinusNode

        public class AdditiveMinusNode : AdditiveNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " - " + RightChild + ")";
            }
        }

        #endregion

        #region Nested type: AdditivePlusNode

        public class AdditivePlusNode : AdditiveNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " + " + RightChild + ")";
            }
        }

        #endregion
    }
}