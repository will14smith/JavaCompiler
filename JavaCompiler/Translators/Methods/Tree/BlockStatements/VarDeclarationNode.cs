using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Tree.BlockStatements
{
    public class VarDeclarationNode : BlockStatementNode
    {
        public Modifier Modifiers { get; set; }

        public string Name { get; set; }
        public Type Type { get; set; }

        public ExpressionNode Initialiser { get; set; }

        public override void ValidateType()
        {
            ReturnType = PrimativeTypes.Void;

            Initialiser.ValidateType();

            if(!Initialiser.ReturnType.IsAssignableTo(Type))
            {
                //TODO: Exception!
            }
        }
    }
}
