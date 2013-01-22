using System;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Methods;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers
{
    class LoadValueCompiler
    {
        private PrimaryNode key;
        private DefinedType classScope;
        private bool methodScope;

        public LoadValueCompiler(PrimaryNode key, DefinedType classScope)
            : this(key, classScope, true)
        {
        }
        private LoadValueCompiler(PrimaryNode key, DefinedType classScope, bool methodScope)
        {
            this.key = key;
            this.classScope = classScope;
            this.methodScope = methodScope;
        }

        public Type Compile(ByteCodeGenerator generator)
        {
            if (key is PrimaryNode.TermIdentifierExpression)
            {
                var id = key as PrimaryNode.TermIdentifierExpression;

                return CompileIdExpression(generator, id);
            }
            if (key is PrimaryNode.TermFieldExpression)
            {
                var field = key as PrimaryNode.TermFieldExpression;

                return CompileFieldExpression(generator, field);
            }

            throw new NotImplementedException();
        }

        private Type CompileIdExpression(ByteCodeGenerator generator, PrimaryNode.TermIdentifierExpression id)
        {
            if (methodScope)
            {
                var variable = generator.GetVariable(id.Identifier);
                if (variable != null)
                {
                    // local variable found
                    return CompileLocalVariable(generator, variable);
                }
            }

            // look for class field
            return CompileClassField(generator, id);
        }
        private Type CompileFieldExpression(ByteCodeGenerator generator, PrimaryNode.TermFieldExpression field)
        {
            if (field.Child is PrimaryNode.TermThisExpression)
            {
                if (field.SecondChild is PrimaryNode.TermIdentifierExpression)
                {
                    var id = field.SecondChild as PrimaryNode.TermIdentifierExpression;

                    return CompileClassField(generator, id);
                }
            }

            throw new NotImplementedException();
        }


        private Type CompileLocalVariable(ByteCodeGenerator generator, Variable variable)
        {
            if (variable.Type.Primitive)
            {
                Common.LoadPrimative(variable, generator);
            }
            else
            {
                throw new NotImplementedException();
            }

            return variable.Type;
        }
        private Type CompileClassField(ByteCodeGenerator generator, PrimaryNode.TermIdentifierExpression id)
        {
            throw new NotImplementedException();
        }
    }
}
