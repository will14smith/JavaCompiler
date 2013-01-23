namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class EqualityNode : ExpressionNode
    {
        public ExpressionNode LeftChild { get; set; }
        public ExpressionNode RightChild { get; set; }

        #region Nested type: EqualityEqualNode

        public class EqualityEqualNode : EqualityNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " == " + RightChild + ")";
            }
        }

        #endregion

        #region Nested type: EqualityNotEqualNode

        public class EqualityNotEqualNode : EqualityNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " != " + RightChild + ")";
            }
        }

        #endregion
    }
}