namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class RelationNode : ExpressionNode
    {
        public TranslateNode LeftChild { get; set; }
        public TranslateNode RightChild { get; set; }

        public class LessThanEqNode : RelationNode
        {
            public override string ToString()
            {
                return string.Format("{0} <= {1}", LeftChild, RightChild);
            }
        }
        public class GreaterThanEqNode : RelationNode
        {
            public override string ToString()
            {
                return string.Format("{0} >= {1}", LeftChild, RightChild);
            }
        }
        public class LessThanNode : RelationNode
        {
            public override string ToString()
            {
                return string.Format("{0} < {1}", LeftChild, RightChild);
            }
        }
        public class GreaterThanNode : RelationNode
        {
            public override string ToString()
            {
                return string.Format("{0} > {1}", LeftChild, RightChild);
            }
        }
    }
}