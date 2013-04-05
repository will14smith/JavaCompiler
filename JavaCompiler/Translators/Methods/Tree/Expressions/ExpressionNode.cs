using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class ExpressionNode : StatementNode
    {
        public abstract Type GetType(ByteCodeGenerator manager);
    }
}