using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class AdditiveCompiler
    {
        private readonly AdditiveNode node;
        public AdditiveCompiler(AdditiveNode node)
        {
            this.node = node;
        }

        public Class Compile(ByteCodeGenerator generator)
        {
            var lhs = new ExpressionCompiler(node.LeftChild).Compile(generator);
            var rhs = new ExpressionCompiler(node.RightChild).Compile(generator);

            node.LeftChild.ReturnType = lhs;
            node.RightChild.ReturnType = rhs;

            node.ValidateType();

            Common.Cast(lhs, node.ReturnType, generator);
            Common.Cast(rhs, node.ReturnType, generator);

            var resultType = lhs.FindCommonType(rhs);

            if (node is AdditiveNode.AdditivePlusNode)
            {
                CompileAdd(generator, resultType);
            }
            else if (node is AdditiveNode.AdditiveMinusNode)
            {
                CompileSub(generator, resultType);
            }
            else
            {
                throw new NotImplementedException();
            }

            return resultType;
        }

        private static void CompileAdd(ByteCodeGenerator generator, Class returnType)
        {
            if (returnType == PrimativeClasses.Byte)
            {
                generator.Emit(OpCodes.iadd);
                generator.Emit(OpCodes.i2b);
            }
            else if (returnType == PrimativeClasses.Short)
            {
                generator.Emit(OpCodes.iadd);
                generator.Emit(OpCodes.i2s);
            }
            else if (returnType == PrimativeClasses.Int)
            {
                generator.Emit(OpCodes.iadd);
            }
            else if (returnType == PrimativeClasses.Long)
            {
                generator.Emit(OpCodes.ladd);
            }
            else if (returnType == PrimativeClasses.Float)
            {
                generator.Emit(OpCodes.fadd);
            }
            else if (returnType == PrimativeClasses.Double)
            {
                generator.Emit(OpCodes.dadd);
            }
            else if (returnType == PrimativeClasses.Char)
            {
                generator.Emit(OpCodes.iadd);
                generator.Emit(OpCodes.i2c);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private static void CompileSub(ByteCodeGenerator generator, Class returnType)
        {
            if (returnType == PrimativeClasses.Byte)
            {
                generator.Emit(OpCodes.isub);
                generator.Emit(OpCodes.i2b);
            }
            else if (returnType == PrimativeClasses.Short)
            {
                generator.Emit(OpCodes.isub);
                generator.Emit(OpCodes.i2s);
            }
            else if (returnType == PrimativeClasses.Int)
            {
                generator.Emit(OpCodes.isub);
            }
            else if (returnType == PrimativeClasses.Long)
            {
                generator.Emit(OpCodes.lsub);
            }
            else if (returnType == PrimativeClasses.Float)
            {
                generator.Emit(OpCodes.fsub);
            }
            else if (returnType == PrimativeClasses.Double)
            {
                generator.Emit(OpCodes.dsub);
            }
            else if (returnType == PrimativeClasses.Char)
            {
                generator.Emit(OpCodes.isub);
                generator.Emit(OpCodes.i2c);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
