using System;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Tree.Statements
{
    public class IfNode : StatementNode
    {
        public override void ValidateType()
        {
            throw new NotImplementedException();
        }

        public ExpressionNode Condition { get; set; }

        public MethodTreeNode TrueBranch { get; set; }
        public MethodTreeNode FalseBranch { get; set; }
    }
}
