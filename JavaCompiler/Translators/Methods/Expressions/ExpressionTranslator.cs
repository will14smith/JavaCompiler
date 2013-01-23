using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class ExpressionTranslator
    {
        private readonly ITree node;

        public ExpressionTranslator(ITree node)
        {
            if (node.Type == (int) JavaNodeType.PARENTESIZED_EXPR)
            {
                node = node.GetChild(0);
            }

            Debug.Assert(node.IsExpression());

            this.node = node;
        }

        public ExpressionNode Walk()
        {
            ITree child = node.Type == (int) JavaNodeType.EXPR ? node.GetChild(0) : node;

            if (child.IsAssignExpression())
            {
                return new AssignmentTranslator(child).Walk();
            }
            if (child.Type == (int) JavaNodeType.QUESTION)
            {
                return new ConditionalTranslator(child).Walk();
            }
            if (child.Type == (int) JavaNodeType.LOGICAL_OR)
            {
                return new LogicalOrTranslator(child).Walk();
            }
            if (child.Type == (int) JavaNodeType.LOGICAL_AND)
            {
                return new LogicalAndTranslator(child).Walk();
            }
            if (child.Type == (int) JavaNodeType.OR)
            {
                return new OrTranslator(child).Walk();
            }
            if (child.Type == (int) JavaNodeType.XOR)
            {
                return new XorTranslator(child).Walk();
            }
            if (child.Type == (int) JavaNodeType.AND)
            {
                return new AndTranslator(child).Walk();
            }
            if (child.IsEqualityExpression())
            {
                return new EqualityTranslator(child).Walk();
            }
            if (child.Type == (int) JavaNodeType.INSTANCEOF)
            {
                throw new NotImplementedException();
            }
            if (child.IsRelationalExpression())
            {
                return new RelationTranslator(child).Walk();
            }
            if (child.IsShiftExpression())
            {
                return new ShiftTranslator(child).Walk();
            }
            if (child.IsAdditiveExpression())
            {
                return new AdditiveTranslator(child).Walk();
            }
            if (child.IsMultiplicativeExpression())
            {
                return new MultiplicativeTranslator(child).Walk();
            }
            if (child.IsUnaryExpression())
            {
                return new UnaryTranslator(child).Walk();
            }
            if (child.IsUnaryOtherExpression())
            {
                return new UnaryOtherTranslator(child).Walk();
            }
            if (child.IsPrimaryExpression())
            {
                return new PrimaryTranslator(child).Walk();
            }
            // TODO: QUALIFIED
            // TODO: NEW
            // TODO: INNER NEW
            // TODO: NEW ARRAY

            throw new NotImplementedException();
        }
    }
}