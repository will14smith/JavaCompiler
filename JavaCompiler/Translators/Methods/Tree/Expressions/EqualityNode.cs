using System;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class EqualityNode : ExpressionNode
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

        public class EqualityEqualNode : EqualityNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " == " + RightChild + ")";
            }
        }
        public class EqualityNotEqualNode : EqualityNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " != " + RightChild + ")";
            }
        }
    }
}
