using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class AdditiveCompiler
    {
        private readonly AdditiveNode node;

        public AdditiveCompiler(AdditiveNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            var lhs = new ExpressionCompiler(node.LeftChild).Compile(generator);
            var rhs = new ExpressionCompiler(node.LeftChild).Compile(generator);

            if (lhs.Type.Primitive && rhs.Type.Primitive)
            {
                var resultType = lhs.Type.FindCommonType(rhs.Type);

                lhs.Coerce(resultType);
                rhs.Coerce(resultType);

                CompileAddition(generator, resultType);

                return new StackItem(generator, resultType);
            }

            // string addition
            return CompileString(generator, lhs, rhs);
        }

        private static void CompileAddition(ByteCodeGenerator generator, Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch(typeCode)
            {
                case ItemTypeCode.Int:
                    generator.Emit(OpCodes.iadd);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodes.ladd);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodes.fadd);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodes.dadd);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private Item CompileString(ByteCodeGenerator generator, Item lhs, Item rhs)
        {
            // return new StackItem(generator, new PlaceholderType { Name = "java.lang.String" });
            throw new NotImplementedException();
        }
    }
}