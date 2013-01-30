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
            PrimaryNode key = new PrimaryTranslator(node.GetChild(0)).Walk();
            TranslateNode value;

            ITree child = node.GetChild(1);
            switch ((JavaNodeType) node.Type)
            {
                case JavaNodeType.ASSIGN:
                    value = new TranslationTranslator(child).Walk();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new AssignmentNode
                       {
                           Left = key,
                           Right = value
                       };
        }
    }
}