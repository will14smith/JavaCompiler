using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class AssignmentTranslator
    {
        private readonly ITree node;

        public AssignmentTranslator(ITree node)
        {
            Debug.Assert(node.IsAssignExpression());

            this.node = node;
        }

        public AssignmentNode Walk()
        {
            var key = new PrimaryTranslator(node.GetChild(0)).Walk();
            var value = new TranslationTranslator(node.GetChild(1)).Walk();

            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.ASSIGN:
                    return new AssignmentNode.NormalAssignNode { Left = key, Right = value };
                case JavaNodeType.PLUS_ASSIGN:
                    return new AssignmentNode.AddAssignNode { Left = key, Right = value };
                case JavaNodeType.MINUS_ASSIGN:
                    return new AssignmentNode.MinusAssignNode { Left = key, Right = value };
                case JavaNodeType.STAR_ASSIGN:
                    return new AssignmentNode.MultiplyAssignNode { Left = key, Right = value };
                case JavaNodeType.DIV_ASSIGN:
                    return new AssignmentNode.DivideAssignNode { Left = key, Right = value };
                case JavaNodeType.MOD_ASSIGN:
                    return new AssignmentNode.ModAssignNode { Left = key, Right = value };
                default:
                    throw new NotImplementedException();
            }
        }
    }
}