using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.Expressions
{
    public class ShiftTranslator
    {
        private readonly ITree node;
        public ShiftTranslator(ITree node)
        {
            Debug.Assert(node.IsShiftExpression());

            this.node = node;
        }

        public ShiftNode Walk()
        {
            throw new NotImplementedException();
        }
    }
}
