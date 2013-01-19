using Antlr.Runtime.Tree;

namespace JavaCompiler.Utilities
{
    // TODO: Make sure these are correct!
    public static class TreeExtensions
    {
        public static bool IsStatement(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.BLOCK_SCOPE ||
                child.Type == (int)JavaNodeType.ASSERT ||
                child.Type == (int)JavaNodeType.IF ||
                child.Type == (int)JavaNodeType.FOR ||
                child.Type == (int)JavaNodeType.FOR_EACH ||
                child.Type == (int)JavaNodeType.WHILE ||
                child.Type == (int)JavaNodeType.DO ||
                child.Type == (int)JavaNodeType.TRY ||
                child.Type == (int)JavaNodeType.SWITCH ||
                child.Type == (int)JavaNodeType.SYNCHRONIZED ||
                child.Type == (int)JavaNodeType.RETURN ||
                child.Type == (int)JavaNodeType.THROW ||
                child.Type == (int)JavaNodeType.BREAK ||
                child.Type == (int)JavaNodeType.CONTINUE ||
                child.Type == (int)JavaNodeType.LABELED_STATEMENT ||
                IsExpression(child);
        }

        public static bool IsExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.EXPR ||
                child.Type == (int)JavaNodeType.INSTANCEOF ||
                child.Type == (int)JavaNodeType.QUESTION ||
                child.Type == (int)JavaNodeType.LOGICAL_OR ||
                child.Type == (int)JavaNodeType.LOGICAL_AND ||
                child.Type == (int)JavaNodeType.OR ||
                child.Type == (int)JavaNodeType.XOR ||
                child.Type == (int)JavaNodeType.AND ||
                IsAssignExpression(child) ||
                IsEqualityExpression(child) ||
                IsRelationalExpression(child) ||
                IsShiftExpression(child) ||
                IsAdditiveExpression(child) ||
                IsMultiplicativeExpression(child) ||
                IsUnaryExpression(child) ||
                IsUnaryOtherExpression(child) ||
                IsPostfixedExpression(child) ||
                IsPrimaryExpression(child) ||
                IsQualifiedExpression(child) ||
                IsNewExpression(child) ||
                IsNewInnerExpression(child) ||
                IsArrayInitialiserExpression(child);
        }

        public static bool IsAssignExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.ASSIGN ||
                child.Type == (int)JavaNodeType.PLUS_ASSIGN ||
                child.Type == (int)JavaNodeType.MINUS_ASSIGN ||
                child.Type == (int)JavaNodeType.STAR_ASSIGN ||
                child.Type == (int)JavaNodeType.DIV_ASSIGN ||
                child.Type == (int)JavaNodeType.AND_ASSIGN ||
                child.Type == (int)JavaNodeType.OR_ASSIGN ||
                child.Type == (int)JavaNodeType.XOR_ASSIGN ||
                child.Type == (int)JavaNodeType.MOD_ASSIGN ||
                child.Type == (int)JavaNodeType.SHIFT_LEFT_ASSIGN ||
                child.Type == (int)JavaNodeType.SHIFT_RIGHT_ASSIGN ||
                child.Type == (int)JavaNodeType.BIT_SHIFT_RIGHT_ASSIGN;

        }
        public static bool IsEqualityExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.EQUAL ||
                child.Type == (int)JavaNodeType.NOT_EQUAL;
        }
        public static bool IsRelationalExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.LESS_OR_EQUAL ||
                child.Type == (int)JavaNodeType.GREATER_OR_EQUAL ||
                child.Type == (int)JavaNodeType.LESS_THAN ||
                child.Type == (int)JavaNodeType.GREATER_THAN;
        }
        public static bool IsShiftExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.BIT_SHIFT_RIGHT ||
                child.Type == (int)JavaNodeType.SHIFT_RIGHT ||
                child.Type == (int)JavaNodeType.SHIFT_LEFT;
        }
        public static bool IsAdditiveExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.PLUS ||
                child.Type == (int)JavaNodeType.MINUS;
        }
        public static bool IsMultiplicativeExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.STAR ||
                child.Type == (int)JavaNodeType.DIV ||
                child.Type == (int)JavaNodeType.MOD;
        }
        public static bool IsUnaryExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.UNARY_PLUS ||
                child.Type == (int)JavaNodeType.UNARY_MINUS ||
                child.Type == (int)JavaNodeType.PRE_INC ||
                child.Type == (int)JavaNodeType.PRE_DEC;
        }
        public static bool IsUnaryOtherExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.NOT ||
                child.Type == (int)JavaNodeType.LOGICAL_NOT ||
                child.Type == (int)JavaNodeType.CAST_EXPR;
        }
        public static bool IsPostfixedExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.DOT || // TODO: Check this
                child.Type == (int)JavaNodeType.METHOD_CALL ||
                child.Type == (int)JavaNodeType.ARRAY_ELEMENT_ACCESS ||
                child.Type == (int)JavaNodeType.POST_INC ||
                child.Type == (int)JavaNodeType.POST_DEC;
        }
        public static bool IsPrimaryExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.PARENTESIZED_EXPR ||
                child.Type == (int)JavaNodeType.SUPER_CONSTRUCTOR_CALL ||
                child.Type == (int)JavaNodeType.METHOD_CALL ||
                child.Type == (int)JavaNodeType.THIS_CONSTRUCTOR_CALL ||
                child.Type == (int)JavaNodeType.DOT || //TODO: Check this
                child.Type == (int)JavaNodeType.ARRAY_DECLARATOR ||
                IsLiteral(child);
        }
        public static bool IsQualifiedExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.ARRAY_DECLARATOR ||
                child.Type == (int)JavaNodeType.DOT || //TODO: Check this
                child.Type == (int)JavaNodeType.METHOD_CALL ||
                child.Type == (int)JavaNodeType.SUPER_CONSTRUCTOR_CALL;
        }
        public static bool IsNewExpression(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.STATIC_ARRAY_CREATOR ||
                child.Type == (int)JavaNodeType.CLASS_CONSTRUCTOR_CALL;
        }
        public static bool IsNewInnerExpression(this ITree child)
        {
            return child.Type == (int)JavaNodeType.CLASS_CONSTRUCTOR_CALL;
        }
        public static bool IsArrayInitialiserExpression(this ITree child)
        {
            return child.Type == (int)JavaNodeType.ARRAY_DECLARATOR_LIST;
        }

        public static bool IsLiteral(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.HEX_LITERAL ||
                child.Type == (int)JavaNodeType.OCTAL_LITERAL ||
                child.Type == (int)JavaNodeType.DECIMAL_LITERAL ||
                child.Type == (int)JavaNodeType.FLOATING_POINT_LITERAL ||
                child.Type == (int)JavaNodeType.CHARACTER_LITERAL ||
                child.Type == (int)JavaNodeType.STRING_LITERAL ||
                child.Type == (int)JavaNodeType.TRUE ||
                child.Type == (int)JavaNodeType.FALSE ||
                child.Type == (int)JavaNodeType.NULL;
        }

        public static bool IsVarDeclaration(this ITree child)
        {
            return child.Type == (int)JavaNodeType.VAR_DECLARATION;
        }

        public static bool IsTypeDeclaration(this ITree child)
        {
            return
                child.Type == (int)JavaNodeType.CLASS ||
                child.Type == (int)JavaNodeType.INTERFACE ||
                child.Type == (int)JavaNodeType.ENUM ||
                child.Type == (int)JavaNodeType.AT
                ;
        }

        public static bool IsBlock(this ITree child)
        {
            return child.Type == (int)JavaNodeType.BLOCK_SCOPE;
        }
    }
}
