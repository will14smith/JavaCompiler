﻿using System;
using System.Collections.Generic;
using Antlr.Runtime.Tree;
using System.Linq;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;

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

        public class TermThisExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeTypes.CompileTime;
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
                ReturnType = PrimativeTypes.CompileTime;
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
                ReturnType = PrimativeTypes.CompileTime;
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
                ReturnType = PrimativeTypes.Int;
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
                ReturnType = PrimativeTypes.Float;
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
                ReturnType = PrimativeTypes.Char;
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
                ReturnType = PrimativeTypes.Boolean;
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
                ReturnType = PrimativeTypes.CompileTime;
            }

            public PrimaryNode SecondChild { get; set; }

            public override string ToString()
            {
                return Child + "." + SecondChild;
            }
        }
        public class TermIdentifierExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeTypes.CompileTime;
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
                ReturnType = PrimativeTypes.CompileTime;
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
        public class TermConstructorCallExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                ReturnType = PrimativeTypes.Void;
            }

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
        public class TermClassLiteralExpression : PrimaryNode
        {
            public override void ValidateType()
            {
                throw new NotImplementedException();
            }
        }
    }
}