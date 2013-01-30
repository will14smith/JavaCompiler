namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class TranslateNode : MethodTreeNode
    {
        public ExpressionNode Child { get; set; }

        public override string ToString()
        {
            return Child.ToString();
        }
    }
}
