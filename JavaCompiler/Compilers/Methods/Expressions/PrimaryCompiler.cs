using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class PrimaryCompiler
    {
        private readonly PrimaryNode node;
        public PrimaryCompiler(PrimaryNode node)
        {
            this.node = node;
        }

        public Variable Compile(ByteCodeGenerator generator)
        {
            //TODO: need to do type determination
            if (node is PrimaryNode.TermIdentifierExpression)
            {
                var variable = generator.GetVariable((node as PrimaryNode.TermIdentifierExpression).Identifier);

                if(variable.Type.Primitive)
                {
                    Common.LoadPrimative(variable, generator);
                }

                return variable;
            }
            if (node is PrimaryNode.TermDecimalLiteralExpression)
            {
                return CompileDecimal(generator, node as PrimaryNode.TermDecimalLiteralExpression);
            }
            if (node is PrimaryNode.TermMethodCallExpression)
            {
                return CompileMethodCall(generator, node as PrimaryNode.TermMethodCallExpression);
            }
            if (node is PrimaryNode.TermFieldExpression)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        private static Variable CompileDecimal(ByteCodeGenerator generator, PrimaryNode.TermDecimalLiteralExpression primaryNode)
        {
            var value = primaryNode.Value;

            if (value > -128 && value < 127)
            {
                switch (value)
                {
                    case -1:
                        generator.Emit(OpCodes.iconst_m1);
                        break;
                    case 0:
                        generator.Emit(OpCodes.iconst_0);
                        break;
                    case 1:
                        generator.Emit(OpCodes.iconst_1);
                        break;
                    case 2:
                        generator.Emit(OpCodes.iconst_2);
                        break;
                    case 3:
                        generator.Emit(OpCodes.iconst_3);
                        break;
                    case 4:
                        generator.Emit(OpCodes.iconst_4);
                        break;
                    case 5:
                        generator.Emit(OpCodes.iconst_5);
                        break;
                    default:
                        generator.Emit(OpCodes.bipush, (byte)value);
                        break;
                }
            }
            else if (value > -32768 && value < 32767)
            {
                generator.Emit(OpCodes.sipush, (short)value);
            }
            else
            {
                generator.Emit(OpCodes.ldc, generator.Manager.AddConstantInteger(value));
            }

            return new Variable(PrimativeClasses.Int);
        }
        private static Variable CompileMethodCall(ByteCodeGenerator generator, PrimaryNode.TermMethodCallExpression termMethodCallExpression)
        {
            throw new NotImplementedException();
        }
    }
}
