using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Tree.Statements
{
    public class WhileNode : StatementNode
    {
        public TranslateNode Expression { get; set; }
        public MethodTreeNode Statement { get; set; }
    }
}