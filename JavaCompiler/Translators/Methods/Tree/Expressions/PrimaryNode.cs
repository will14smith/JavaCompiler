using System;
using System.Collections.Generic;
using Antlr.Runtime.Tree;
using System.Linq;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    abstract class PrimaryNode : ExpressionNode
    {
        // Valid types are below classes and AllocationNode
        public ExpressionNode Child { get; set; }

        public override string ToString()
        {
            return Child.ToString();
        }

        public class TermThisExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.CompileTime;
            }

            public override string ToString()
            {
                return "this";
            }
        }
        public class TermSuperExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.CompileTime;
            }

            public override string ToString()
            {
                return "super";
            }
        }
        public class TermNullExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.CompileTime;
            }

            public override string ToString()
            {
                return "null";
            }
        }
        public class TermDecimalLiteralExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.Int;
            }

            public int Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
        public class TermFloatLiteralExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.Float;
            }

            public float Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
        public class TermCharLiteralExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.Char;
            }

            public char Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
        public class TermStringLiteralExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                throw new NotImplementedException();
            }

            public string Value { get; set; }

            public override string ToString()
            {
                return Value;
            }
        }
        public class TermBoolLiteralExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.Boolean;
            }

            public bool Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
        public class TermFieldExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.CompileTime;
            }

            public ExpressionNode SecondChild { get; set; }

            public override string ToString()
            {
                return Child + "." + SecondChild;
            }
        }
        public class TermIdentifierExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.CompileTime;
            }

            public string Identifier { get; set; }

            public TermIdentifierExpression()
            {
            }
            public TermIdentifierExpression(ITree node)
            {
                Identifier = node.Text;
            }

            public override string ToString()
            {
                return Identifier;
            }
        }
        public class TermMethodCallExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeClasses.CompileTime;
            }

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

                return Child + "(" + arguments + ")";
            }
        }
        public class TermClassLiteralExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                throw new NotImplementedException();
            }
        }
    }
}
