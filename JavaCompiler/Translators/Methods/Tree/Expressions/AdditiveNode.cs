using System;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class AdditiveNode : ExpressionNode
    {
        public ExpressionNode LeftChild { get; set; }
        public ExpressionNode RightChild { get; set; }

        public override void ValidateType()
        {
            if (LeftChild.ReturnType == null)
                LeftChild.ValidateType();
            if (RightChild.ReturnType == null)
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

        public class AdditivePlusNode : AdditiveNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " + " + RightChild + ")";
            }
        }
        public class AdditiveMinusNode : AdditiveNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " - " + RightChild + ")";
            }
        }
    }
}
