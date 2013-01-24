﻿using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class MultiplicativeCompiler
    {
        private readonly MultiplicativeNode node;

        public MultiplicativeCompiler(MultiplicativeNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            var lhs = new ExpressionCompiler(node.LeftChild).Compile(generator);
            var rhs = new ExpressionCompiler(node.RightChild).Compile(generator);

            if (!lhs.Type.Primitive || !rhs.Type.Primitive)
            {
                throw new InvalidOperationException();
            }

            var resultType = lhs.Type.FindCommonType(rhs.Type);

            lhs.Coerce(resultType).Load();
            rhs.Coerce(resultType).Load();

            if (node is MultiplicativeNode.MultiplicativeMultiplyNode)
            {
                CompileMultiplication(generator, resultType);
            }
            else if (node is MultiplicativeNode.MultiplicativeDivideNode)
            {
                CompileDivide(generator, resultType);
            } 
            else if (node is MultiplicativeNode.MultiplicativeModNode)
            {
                CompileMod(generator, resultType);
            }

            return new StackItem(generator, resultType);
        }

        private static void CompileMultiplication(ByteCodeGenerator generator, Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    generator.Emit(OpCodes.imul);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodes.lmul);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodes.fmul);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodes.dmul);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private static void CompileDivide(ByteCodeGenerator generator, Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    generator.Emit(OpCodes.idiv);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodes.ldiv);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodes.fdiv);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodes.ddiv);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private static void CompileMod(ByteCodeGenerator generator, Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    generator.Emit(OpCodes.irem);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodes.lrem);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodes.frem);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodes.drem);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

    }
}