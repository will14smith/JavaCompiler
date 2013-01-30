namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class ConditionalNode : ExpressionNode
    {
        public TranslateNode Condition { get; set; }
        public ExpressionNode ThenExpression { get; set; }
        public ExpressionNode ElseExpression { get; set; }

    }
}