using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class NewTranslator
    {
        private readonly ITree node;
        public NewTranslator(ITree node)
        {
            Debug.Assert(node.IsNewExpression());

            this.node = node;
        }

        public NewNode Walk()
        {
            var type = TypeTranslator.ProcessClass(node.GetChild(0));

            var child = node.GetChild(1);
            if (child.IsExpression())
            {
                var expressions = new List<ExpressionNode>();

                for (var i = 1; i < node.ChildCount; i++)
                {
                    child = node.GetChild(i);

                    expressions.Add(new ExpressionTranslator(child).Walk());
                }

                return new NewNode.NewArrayNode
                {
                    Type = type,
                    Dimensions = expressions
                };
            }
            if (child.Type == (int)JavaNodeType.ARGUMENT_LIST)
            {
                var arguments = new List<TranslateNode>();

                for (var i = 0; i < child.ChildCount; i++)
                {
                    arguments.Add(new TranslationTranslator(child.GetChild(i)).Walk());
                }

                return new NewNode.NewClassNode
                {
                    Type = type,
                    Arguments = arguments
                };
            }

            throw new NotImplementedException();
        }
    }
}