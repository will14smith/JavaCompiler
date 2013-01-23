using System.Collections.Generic;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.BlockStatements
{
    public class VarDeclarationTranslator
    {
        private readonly ITree node;

        public VarDeclarationTranslator(ITree node)
        {
            Debug.Assert(node.IsVarDeclaration());

            this.node = node;
        }

        public List<VarDeclarationNode> Walk()
        {
            var varDecls = new List<VarDeclarationNode>();

            var modifiers = Modifier.None;
            ITree modifierNode = node.GetChild(0);
            if (modifierNode.Type == (int) JavaNodeType.MODIFIER_LIST)
            {
                modifiers = new ModifierListTranslator(modifierNode).Walk();
            }

            Type type = new TypeTranslator(node.GetChild(1)).Walk();

            ITree declaratorList = node.GetChild(2);

            for (int i = 0; i < declaratorList.ChildCount; i++)
            {
                ITree declarator = declaratorList.GetChild(i);

                var varDecl = new VarDeclarationNode
                                  {
                                      Modifiers = modifiers,
                                      Type = type,
                                      Name = declarator.GetChild(0).Text,
                                  };

                if (declarator.ChildCount > 1)
                {
                    varDecl.Initialiser = new ExpressionTranslator(declarator.GetChild(1)).Walk();
                }

                varDecls.Add(varDecl);
            }

            return varDecls;
        }
    }
}