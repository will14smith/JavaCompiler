using System;
using System.Collections.Generic;
using System.Linq;
using Antlr.Runtime.Tree;
using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using Type = JavaCompiler.Reflection.Types.Type;

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

            public override Type GetType(ByteCodeGenerator manager)
            {
                return PrimativeTypes.Boolean;
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

            public override Type GetType(ByteCodeGenerator manager)
            {
                return PrimativeTypes.Char;
            }
        }

        #endregion

        #region Nested type: TermClassLiteralExpression

        public class TermClassLiteralExpression : PrimaryNode
        {
            public override Type GetType(ByteCodeGenerator manager)
            {
                throw new System.NotImplementedException();
            }
        }

        #endregion

        #region Nested type: TermConstructorCallExpression

        public class TermConstructorCallExpression : PrimaryNode
        {
            public bool IsSuper { get; set; }
            public List<TranslateNode> Arguments { get; set; }

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

            public override Type GetType(ByteCodeGenerator manager)
            {
                return PrimativeTypes.Void;
            }
        }

        #endregion

        #region Nested type: TermDecimalLiteralExpression

        //TODO: Is int correct??
        public class TermDecimalLiteralExpression : PrimaryNode
        {
            public int Value { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }

            public override Type GetType(ByteCodeGenerator manager)
            {
                return PrimativeTypes.Int;
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

            public override Type GetType(ByteCodeGenerator manager)
            {
                throw new System.NotImplementedException();
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

            public override Type GetType(ByteCodeGenerator manager)
            {
                return PrimativeTypes.Float;
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

            public override Type GetType(ByteCodeGenerator manager)
            {
                var variable = manager.GetVariable(Identifier);
                var field = manager.Method.DeclaringType.Fields.FirstOrDefault(x => x.Name == Identifier);

                if (variable == null && field == null)
                {
                    throw new InvalidOperationException();
                }

                return variable == null ? field.ReturnType : variable.Type;
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

            public override Type GetType(ByteCodeGenerator manager)
            {
                throw new System.NotImplementedException();
            }
        }

        #endregion

        #region Nested type: TermMethodExpression

        public class TermMethodExpression : PrimaryNode
        {
            public TermMethodExpression()
            {
            }

            public TermMethodExpression(ITree node)
            {
                Identifier = node.Text;
            }

            public string Identifier { get; set; }
            public List<TranslateNode> Arguments { get; set; }

            public override string ToString()
            {
                return Identifier;
            }

            public override Type GetType(ByteCodeGenerator manager)
            {
                throw new System.NotImplementedException();
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

            public override Type GetType(ByteCodeGenerator manager)
            {
                return BuiltinTypes.Null;
            }
        }

        #endregion

        #region Nested type: TermStringLiteralExpression

        public class TermStringLiteralExpression : PrimaryNode
        {
            public string Value { get; set; }

            public override string ToString()
            {
                return string.Format("\"{0}\"", Value);
            }

            public override Type GetType(ByteCodeGenerator manager)
            {
                return BuiltinTypes.String;
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

            public override Type GetType(ByteCodeGenerator manager)
            {
                return BuiltinTypes.Super;
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

            public override Type GetType(ByteCodeGenerator manager)
            {
                return BuiltinTypes.This;
            }
        }

        #endregion
    }
}