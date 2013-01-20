using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class AssignmentCompiler
    {
        private readonly AssignmentNode node;
        public AssignmentCompiler(AssignmentNode node)
        {
            this.node = node;
        }

        public Class Compile(ByteCodeGenerator generator)
        {
            // get ref / index (setup stack)
            var variable = GetVariable(generator);

            // calculate value
            var returnType = new ExpressionCompiler(node.Value).Compile(generator);
            Common.Cast(returnType, variable.Type, generator);

            // store value (assume stack has nessassaries)
            if (variable.Type.Primitive)
            {
                Common.StorePrimative(variable, generator);
            }
            else
            {
                // save to ref
                throw new NotImplementedException();
            }

            return node.ReturnType;
        }

        private Variable GetVariable(ByteCodeGenerator generator)
        {
            if (node.Key is PrimaryNode.TermIdentifierExpression)
            {
                return generator.GetVariable((node.Key as PrimaryNode.TermIdentifierExpression).Identifier);
            }

            throw new NotImplementedException();
        }
    }
}
