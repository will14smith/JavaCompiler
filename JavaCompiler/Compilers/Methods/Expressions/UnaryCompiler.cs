using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class UnaryCompiler
    {
        private readonly UnaryNode node;

        public UnaryCompiler(UnaryNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            //TODO
            var item = new ExpressionCompiler(node.Child.Child).Compile(generator);

            if (node is UnaryNode.PlusNode)
            {
                return item.Load();
            }
            if (node is UnaryNode.MinusNode)
            {
                throw new NotImplementedException();
            }

            if (node is UnaryNode.PreIncNode)
            {
                return CompilePreOp(generator, item);
            }
            if (node is UnaryNode.PreDecNode)
            {
                return CompilePreOp(generator, item);
            }

            if (node is UnaryNode.PostIncNode)
            {
                return CompilePostOp(generator, item);
            }
            if (node is UnaryNode.PostDecNode)
            {
                return CompilePostOp(generator, item);
            }

            throw new NotImplementedException();
        }

        private Item CompilePreOp(ByteCodeGenerator generator, Item item)
        {
            if (item is LocalItem && TypeCodeHelper.Truncate(item.TypeCode) == ItemTypeCode.Int)
            {
                ((LocalItem)item).Incr(node is UnaryNode.PreIncNode ? 1 : -1);

                return item;
            }
            else
            {
                item.Load();

                generator.Emit(One(item.TypeCode));
                if (node is UnaryNode.PreIncNode)
                {
                    generator.Emit(OpAdd(item.Type));
                }
                else if (node is UnaryNode.PreDecNode)
                {
                    generator.Emit(OpSub(item.Type));
                }

                var typeCode = item.TypeCode;
                if (item.Type != PrimativeTypes.Int && TypeCodeHelper.Truncate(typeCode) == ItemTypeCode.Int)
                {
                    generator.Emit(OpCodeValue.i2b + (byte)typeCode - (byte)ItemTypeCode.Byte);
                }
                return new AssignItem(generator, item);
            }
        }

        private Item CompilePostOp(ByteCodeGenerator generator, Item item)
        {
            item.Duplicate();

            if (item is LocalItem && TypeCodeHelper.Truncate(item.TypeCode) == ItemTypeCode.Int)
            {
                //var res = item.Load();

                ((LocalItem)item).Incr(node is UnaryNode.PostIncNode ? 1 : -1);

                //return res;
                return item;
            }
            else
            {
                var res = item.Load();
                item.Stash(item.TypeCode);

                generator.Emit(One(item.TypeCode));

                if (node is UnaryNode.PostIncNode)
                {
                    generator.Emit(OpAdd(item.Type));
                }
                else if (node is UnaryNode.PostDecNode)
                {
                    generator.Emit(OpSub(item.Type));
                }

                var typeCode = TypeCodeHelper.TypeCode(item.Type);
                if (item.Type != PrimativeTypes.Int && TypeCodeHelper.Truncate(typeCode) == ItemTypeCode.Int)
                {
                    generator.Emit(OpCodeValue.i2b + (byte)typeCode - (byte)ItemTypeCode.Byte);
                }
                item.Store();

                return res;
            }
        }

        private OpCodeValue One(ItemTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ItemTypeCode.Int:
                case ItemTypeCode.Byte:
                case ItemTypeCode.Short:
                case ItemTypeCode.Char:
                    return OpCodeValue.iconst_1;
                case ItemTypeCode.Long:
                    return OpCodeValue.lconst_1;
                case ItemTypeCode.Float:
                    return OpCodeValue.fconst_1;
                case ItemTypeCode.Double:
                    return OpCodeValue.dconst_1;
                default:
                    throw new NotImplementedException();
            }
        }

        private OpCodeValue OpAdd(Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    return OpCodeValue.iadd;
                case ItemTypeCode.Long:
                    return OpCodeValue.ladd;
                case ItemTypeCode.Float:
                    return OpCodeValue.fadd;
                case ItemTypeCode.Double:
                    return OpCodeValue.dadd;
                default:
                    throw new NotImplementedException();
            }
        }

        private OpCodeValue OpSub(Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    return OpCodeValue.isub;
                case ItemTypeCode.Long:
                    return OpCodeValue.lsub;
                case ItemTypeCode.Float:
                    return OpCodeValue.fsub;
                case ItemTypeCode.Double:
                    return OpCodeValue.dsub;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}