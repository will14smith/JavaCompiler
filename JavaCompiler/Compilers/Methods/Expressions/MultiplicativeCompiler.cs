using System;
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
            var lType = new TranslationCompiler(node.LeftChild).GetType(generator, false);
            var rType = new TranslationCompiler(node.RightChild).GetType(generator, false);

            var type = lType.FindCommonType(rType);

            var lhs = new TranslationCompiler(node.LeftChild, type).Compile(generator);
            var rhs = new TranslationCompiler(node.RightChild, type).Compile(generator);

            if (!type.Primitive)
            {
                throw new InvalidOperationException();
            }

            lhs.Load();
            rhs.Load();

            if (node is MultiplicativeNode.MultiplicativeMultiplyNode)
            {
                CompileMultiplication(generator, type);
            }
            else if (node is MultiplicativeNode.MultiplicativeDivideNode)
            {
                CompileDivide(generator, type);
            } 
            else if (node is MultiplicativeNode.MultiplicativeModNode)
            {
                CompileMod(generator, type);
            }

            return new StackItem(generator, type);
        }

        private static void CompileMultiplication(ByteCodeGenerator generator, Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    generator.Emit(OpCodeValue.imul);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodeValue.lmul);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodeValue.fmul);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodeValue.dmul);
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
                    generator.Emit(OpCodeValue.idiv);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodeValue.ldiv);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodeValue.fdiv);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodeValue.ddiv);
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
                    generator.Emit(OpCodeValue.irem);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodeValue.lrem);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodeValue.frem);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodeValue.drem);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

    }
}