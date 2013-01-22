using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Methods;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers
{
    class StoreValueCompiler
    {
        private PrimaryNode key;
        private Type returnType;
        private DefinedType classScope;
        private bool methodScope;

        public StoreValueCompiler(PrimaryNode key, Type returnType, DefinedType classScope)
            : this(key, returnType, classScope, true)
        {
        }
        private StoreValueCompiler(PrimaryNode key, Type returnType, DefinedType classScope, bool methodScope)
        {
            this.key = key;
            this.returnType = returnType;
            this.classScope = classScope;
            this.methodScope = methodScope;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            if (key is PrimaryNode.TermIdentifierExpression)
            {
                var id = key as PrimaryNode.TermIdentifierExpression;

                CompileIdExpression(generator, id);
            }
            else if (key is PrimaryNode.TermFieldExpression)
            {
                var field = key as PrimaryNode.TermFieldExpression;

                CompileFieldExpression(generator, field);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void CompileIdExpression(ByteCodeGenerator generator, PrimaryNode.TermIdentifierExpression id)
        {
            if (methodScope)
            {
                var variable = generator.GetVariable(id.Identifier);
                if (variable != null)
                {
                    // local variable found
                    CompileLocalVariable(generator, variable);
                }
            }

            // look for class field
            CompileClassField(generator, id);
        }
        private void CompileFieldExpression(ByteCodeGenerator generator, PrimaryNode.TermFieldExpression field)
        {
            if (field.Child is PrimaryNode.TermThisExpression)
            {
                if (field.SecondChild is PrimaryNode.TermIdentifierExpression)
                {
                    var id = field.SecondChild as PrimaryNode.TermIdentifierExpression;

                    CompileClassField(generator, id);
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private Type CompileLocalVariable(ByteCodeGenerator generator, Variable variable)
        {
            if (variable.Type.Primitive)
            {
                Common.StorePrimative(variable, generator);
            }
            else
            {
                throw new NotImplementedException();
            }

            return variable.Type;
        }
        private Type CompileClassField(ByteCodeGenerator generator, PrimaryNode.TermIdentifierExpression id)
        {
            short fieldref;

            generator.Emit(OpCodes.putfield, fieldref);
        }

    }
}
