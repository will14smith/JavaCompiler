using System.Collections.Generic;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Tree.BlockStatements
{
    public class VarDeclarationNode : BlockStatementNode
    {
        public VarDeclarationNode()
        {
            Modifiers = new List<LocalModifier>();
        }

        public List<LocalModifier> Modifiers { get; private set; }

        public string Name { get; set; }
        public Class Type { get; set; }

        public VariableInitialiserNode Initialiser { get; set; }
    }
}
