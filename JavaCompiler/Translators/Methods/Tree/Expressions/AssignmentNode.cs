namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class AssignmentNode : ExpressionNode
    {
        public PrimaryNode Left { get; set; }
        public TranslateNode Right { get; set; }
    }
}