﻿namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class AssignmentNode : ExpressionNode
    {
        public PrimaryNode Left { get; set; }
        public ExpressionNode Right { get; set; }

        public override void ValidateType()
        {
            Left.ValidateType();
            Right.ValidateType();

            ReturnType = Right.ReturnType;
        }
    }
}