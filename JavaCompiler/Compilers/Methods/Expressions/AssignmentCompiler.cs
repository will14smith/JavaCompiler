using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class AssignmentCompiler
    {
        private readonly AssignmentNode node;
        public AssignmentCompiler(AssignmentNode node)
        {
            this.node = node;
        }

        public Type Compile(ByteCodeGenerator generator)
        {
            // calculate value
            var returnType = new ExpressionCompiler(node.Value).Compile(generator);

            new StoreValueCompiler(node.Key, returnType, generator.Method.DeclaringType).Compile(generator);

            return node.ReturnType;
        }
    }
}
