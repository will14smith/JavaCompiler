namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class AssignmentNode : ExpressionNode
    {
        public PrimaryNode Key { get; set; }
        public ExpressionNode Value { get; set; }

        public override void ValidateType()
        {
            Key.ValidateType();
            Value.ValidateType();

            ReturnType = Value.ReturnType;
        }
    }
}
