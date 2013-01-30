using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class PrimaryTranslator
    {
        private readonly ITree node;

        public PrimaryTranslator(ITree node)
        {
            Debug.Assert(node.IsPrimaryExpression());

            this.node = node;
        }

        public PrimaryNode Walk()
        {
            if (node.IsLiteral())
            {
                return WalkLiteral();
            }

            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.THIS:
                    return new PrimaryNode.TermThisExpression();
                case JavaNodeType.IDENT:
                    return new PrimaryNode.TermIdentifierExpression(node);
                case JavaNodeType.DOT:
                    return new PrimaryNode.TermFieldExpression
                               {
                                   Child = new PrimaryTranslator(node.GetChild(0)).Walk(),
                                   SecondChild = new PrimaryTranslator(node.GetChild(1)).Walk()
                               };
                case JavaNodeType.METHOD_CALL:
                    return WalkMethodCall();
                case JavaNodeType.ARRAY_ELEMENT_ACCESS:
                    return WalkArrayAccess();
                case JavaNodeType.SUPER_CONSTRUCTOR_CALL:
                case JavaNodeType.THIS_CONSTRUCTOR_CALL:
                    return WalkConstructorCall();
                default:
                    throw new NotImplementedException();
            }
        }

        private PrimaryNode WalkLiteral()
        {
            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.HEX_LITERAL:
                    return new PrimaryNode.TermDecimalLiteralExpression { Value = Convert.ToInt32(node.Text.Substring(2), 16) };
                case JavaNodeType.OCTAL_LITERAL:
                    return new PrimaryNode.TermDecimalLiteralExpression { Value = Convert.ToInt32(node.Text, 8) };
                case JavaNodeType.DECIMAL_LITERAL:
                    return new PrimaryNode.TermDecimalLiteralExpression { Value = int.Parse(node.Text) };
                case JavaNodeType.FLOATING_POINT_LITERAL:
                    return new PrimaryNode.TermFloatLiteralExpression { Value = float.Parse(node.Text) };
                case JavaNodeType.CHARACTER_LITERAL:
                    return new PrimaryNode.TermCharLiteralExpression { Value = char.Parse(node.Text) };
                case JavaNodeType.STRING_LITERAL:
                    return new PrimaryNode.TermStringLiteralExpression { Value = node.Text.Substring(1, node.Text.Length - 2) };
                case JavaNodeType.TRUE:
                    return new PrimaryNode.TermBoolLiteralExpression { Value = true };
                case JavaNodeType.FALSE:
                    return new PrimaryNode.TermBoolLiteralExpression { Value = false };
                case JavaNodeType.NULL:
                    return new PrimaryNode.TermNullExpression();
                default:
                    throw new NotImplementedException();
            }
        }

        private PrimaryNode WalkMethodCall()
        {
            PrimaryNode key = new PrimaryTranslator(node.GetChild(0)).Walk();
            var arguments = new List<TranslateNode>();

            ITree argumentList = node.GetChild(1);
            for (int i = 0; i < argumentList.ChildCount; i++)
            {
                arguments.Add(new TranslationTranslator(argumentList.GetChild(i)).Walk());
            }

            PrimaryNode.TermMethodExpression meth;
            if (key is PrimaryNode.TermIdentifierExpression)
            {
                var id = key as PrimaryNode.TermIdentifierExpression;

                meth = new PrimaryNode.TermMethodExpression { Identifier = id.Identifier };

                key = meth;
            }
            else if (key is PrimaryNode.TermFieldExpression)
            {
                var field = key as PrimaryNode.TermFieldExpression;
                var id = field.SecondChild as PrimaryNode.TermIdentifierExpression;

                meth = new PrimaryNode.TermMethodExpression { Identifier = id.Identifier };

                key = new PrimaryNode.TermFieldExpression
                {
                    Child = field.Child,
                    SecondChild = meth
                };
            }
            else
            {
                throw new NotImplementedException();
            }

            meth.Arguments = arguments;

            return key;
        }

        private PrimaryNode WalkConstructorCall()
        {
            bool isSuper = node.Type == (int)JavaNodeType.SUPER_CONSTRUCTOR_CALL;

            var arguments = new List<TranslateNode>();
            ITree argumentList = node.GetChild(0);
            for (int i = 0; i < argumentList.ChildCount; i++)
            {
                arguments.Add(new TranslationTranslator(argumentList.GetChild(i)).Walk());
            }

            return new PrimaryNode.TermConstructorCallExpression
                       {
                           IsSuper = isSuper,
                           Arguments = arguments
                       };
        }

        private PrimaryNode WalkArrayAccess()
        {
            return new PrimaryNode.TermArrayExpression
            {
                Child = new PrimaryTranslator(node.GetChild(0)).Walk(),
                Index = new ExpressionTranslator(node.GetChild(1)).Walk()
            };
        }
    }
}