using JavaCompiler.Reflection;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    abstract class MultiplicativeNode : ExpressionNode
    {
        public ExpressionNode LeftChild { get; set; }
        public ExpressionNode RightChild { get; set; }

        public override void ValidateType()
        {
            LeftChild.ValidateType();
            RightChild.ValidateType();

            if (LeftChild.ReturnType != RightChild.ReturnType)
            {
                ReturnType = LeftChild.ReturnType.FindCommonType(RightChild.ReturnType);
            }
            else
            {
                ReturnType = LeftChild.ReturnType;
            }
        }

        public class MultiplicativeMultiplyNode : MultiplicativeNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " * " + RightChild + ")";
            }
        }
        public class MultiplicativeDivideNode : MultiplicativeNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " / " + RightChild + ")";
            }
        }
        public class MultiplicativeModNode : MultiplicativeNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " % " + RightChild + ")";
            }
        }
    }
}
