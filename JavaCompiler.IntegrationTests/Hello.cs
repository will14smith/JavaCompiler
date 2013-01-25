using System.Collections.Generic;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.IntegrationTests
{
    [TestClass]
    public class Hello : BaseMethodTest
    {
        public Hello()
        {
            Source =
                "public static void main(String args[]) {" +
                "   System.out.println(\"Hello\");" +
                "}";

            ExpectedTree =
                new MethodTree
                {
                    new PrimaryNode.TermFieldExpression
                    {
                        Child = new PrimaryNode.TermFieldExpression
                        {
                            Child = new PrimaryNode.TermIdentifierExpression { Identifier = "System" },
                            SecondChild = new PrimaryNode.TermIdentifierExpression { Identifier = "out" }
                        },
                        SecondChild = new PrimaryNode.TermMethodExpression
                        {
                            Identifier = "println",
                            Arguments = new List<ExpressionNode>
                            {
                                new PrimaryNode.TermStringLiteralExpression { Value = "\"Hello\"" }
                            }
                        }
                    },
                };
        }
    }
}
