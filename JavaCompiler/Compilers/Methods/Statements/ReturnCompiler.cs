using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Statements;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Statements
{
    public class ReturnCompiler
    {
        private readonly ReturnNode node;
        public ReturnCompiler(ReturnNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            if (node.Value == null)
            {
                if (generator.Method.ReturnType != PrimativeTypes.Void)
                {
                    throw new InvalidOperationException();
                }

                generator.Emit(OpCodeValue.@return);

                return new VoidItem(generator);
            }

            var value = new ExpressionCompiler(node.Value).Compile(generator);
            value.Load();

            CompileReturn(generator, value.Type);

            return new VoidItem(generator);
        }

        private void CompileReturn(ByteCodeGenerator generator, Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    generator.Emit(OpCodeValue.ireturn);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodeValue.lreturn);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodeValue.freturn);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodeValue.dreturn);
                    break;
                case ItemTypeCode.Object:
                    generator.Emit(OpCodeValue.areturn);
                    break;
                default:
                    throw new NotImplementedException();
            }

        }
    }
}