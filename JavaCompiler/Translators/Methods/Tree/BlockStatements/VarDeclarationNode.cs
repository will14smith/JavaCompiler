using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Tree.BlockStatements
{
    public class VarDeclarationNode : BlockStatementNode
    {
        public Modifier Modifiers { get; set; }

        public string Name { get; set; }
        public Type Type { get; set; }

        public ExpressionNode Initialiser { get; set; }
    }
}