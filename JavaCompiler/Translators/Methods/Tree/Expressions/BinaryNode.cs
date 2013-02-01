namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class BinaryNode : ExpressionNode
    {
        public TranslateNode LeftChild { get; set; }
        public TranslateNode RightChild { get; set; }
    }
}
