using System.Collections.Generic;
using System.Linq;
using Antlr.Runtime.Tree;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class PrimaryNode : ExpressionNode
    {
        // Valid types are below classes and AllocationNode
        public PrimaryNode Child { get; set; }

        public override string ToString()
        {
            return Child.ToString();
        }

        #region Nested type: TermBoolLiteralExpression

        public class TermBoolLiteralExpression : PrimaryNode
        {
            public bool Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        #endregion

        #region Nested type: TermCharLiteralExpression

        public class TermCharLiteralExpression : PrimaryNode
        {
            public char Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        #endregion

        #region Nested type: TermClassLiteralExpression

        public class TermClassLiteralExpression : PrimaryNode
        {
        }

        #endregion

        #region Nested type: TermConstructorCallExpression

        public class TermConstructorCallExpression : PrimaryNode
        {
            public bool IsSuper { get; set; }
            public List<ExpressionNode> Arguments { get; set; }

            public override string ToString()
            {
                var arguments = "";

                for (var i = 0; i < Arguments.Count(); i++)
                {
                    if (i > 0)
                    {
                        arguments += ", ";
                    }

                    arguments += Arguments[i];
                }

                return (IsSuper ? "super" : "this") + "(" + arguments + ")";
            }
        }

        #endregion

        #region Nested type: TermDecimalLiteralExpression

        public class TermDecimalLiteralExpression : PrimaryNode
        {
            public int Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        #endregion

        #region Nested type: TermFieldExpression

        public class TermFieldExpression : PrimaryNode
        {
            public PrimaryNode SecondChild { get; set; }

            public override string ToString()
            {
                return Child + "." + SecondChild;
            }
        }

        #endregion

        #region Nested type: TermFloatLiteralExpression

        public class TermFloatLiteralExpression : PrimaryNode
        {
            public float Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        #endregion

        #region Nested type: TermIdentifierExpression

        public class TermIdentifierExpression : PrimaryNode
        {
            public TermIdentifierExpression()
            {
            }

            public TermIdentifierExpression(ITree node)
            {
                Identifier = node.Text;
            }

            public string Identifier { get; set; }

            public override string ToString()
            {
                return Identifier;
            }
        }

        #endregion

        #region Nested type: TermArrayExpression

        public class TermArrayExpression : PrimaryNode
        {
            public ExpressionNode Index { get; set; }

            public override string ToString()
            {
                return string.Format("{0}[{1}]", Child, Index);
            }
        }

        #endregion

        #region Nested type: TermMethodCallExpression

        public class TermMethodCallExpression : PrimaryNode
        {
            public List<ExpressionNode> Arguments { get; set; }

            public override string ToString()
            {
                string arguments = "";

                for (int i = 0; i < Arguments.Count(); i++)
                {
                    if (i > 0)
                    {
                        arguments += ", ";
                    }

                    arguments += Arguments[i];
                }

                return Child + "(" + arguments + ")";
            }
        }

        #endregion

        #region Nested type: TermNullExpression

        public class TermNullExpression : PrimaryNode
        {
            public override string ToString()
            {
                return "null";
            }
        }

        #endregion

        #region Nested type: TermStringLiteralExpression

        public class TermStringLiteralExpression : PrimaryNode
        {
            public string Value { get; set; }

            public override string ToString()
            {
                return Value;
            }
        }

        #endregion

        #region Nested type: TermSuperExpression

        public class TermSuperExpression : PrimaryNode
        {
            public override string ToString()
            {
                return "super";
            }
        }

        #endregion

        #region Nested type: TermThisExpression

        public class TermThisExpression : PrimaryNode
        {
            public override string ToString()
            {
                return "this";
            }
        }

        #endregion
    }
}