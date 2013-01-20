using System;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Translators.Methods.Tree.Statements
{
    public class ReturnNode : StatementNode
    {
        public override void ValidateType()
        {
            throw new NotImplementedException();
        }

        public ExpressionNode Value { get; set; }
    }
}
