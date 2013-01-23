using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Expressions;
using JavaCompiler.Translators.Methods.Statements;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.BlockStatements
{
    public class StatementTranslator
    {
        private readonly ITree node;

        public StatementTranslator(ITree node)
        {
            Debug.Assert(node.IsStatement());

            this.node = node;
        }

        public MethodTreeNode Walk()
        {
            if (node.IsBlock())
            {
                return new BlockTranslator(node).Walk();
            }

            if (node.IsExpression())
            {
                return new ExpressionTranslator(node).Walk();
            }

            switch ((JavaNodeType) node.Type)
            {
                case JavaNodeType.ASSERT:
                    return new AssertTranslator(node).Walk();
                case JavaNodeType.IF:
                    return new IfTranslator(node).Walk();
                case JavaNodeType.FOR:
                    return new ForTranslator(node).Walk();
                case JavaNodeType.FOR_EACH:
                    return new ForEachTranslator(node).Walk();
                case JavaNodeType.WHILE:
                    return new WhileTranslator(node).Walk();
                case JavaNodeType.DO:
                    return new DoTranslator(node).Walk();
                case JavaNodeType.TRY:
                    return new TryTranslator(node).Walk();
                case JavaNodeType.SWITCH:
                    return new SwitchTranslator(node).Walk();
                case JavaNodeType.SYNCHRONIZED:
                    return new SyncronizedTranslator(node).Walk();
                case JavaNodeType.RETURN:
                    return new ReturnTranslator(node).Walk();
                case JavaNodeType.THROW:
                    return new ThrowTranslator(node).Walk();
                case JavaNodeType.BREAK:
                    return new BreakTranslator(node).Walk();
                case JavaNodeType.CONTINUE:
                    return new ContiuneTranslator(node).Walk();
                case JavaNodeType.LABELED_STATEMENT:
                    return new LabelTranslator(node).Walk();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}