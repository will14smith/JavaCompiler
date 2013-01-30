using System.Collections.Generic;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Tree.Statements
{
    public class ForNode : StatementNode
    {
        public MethodTree Initialiser { get; set; }
        public TranslateNode Condition { get; set; }
        public MethodTree Updater { get; set; }

        public MethodTreeNode Statement { get; set; }
    }
}