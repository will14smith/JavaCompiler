using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Items
{
    internal class ImmediateItem : Item
    {
        private readonly object value;

        public ImmediateItem(ByteCodeGenerator generator, Type type, object value)
            : base(generator, type)
        {
            this.value = value;
        }

        private void LoadConstant()
        {
            short index;

            switch (TypeCode)
            {
                case ItemTypeCode.Byte:
                case ItemTypeCode.Char:
                case ItemTypeCode.Short:
                case ItemTypeCode.Int:
                    index = Generator.Manager.AddConstantInteger((int)value);
                    break;
                case ItemTypeCode.Float:
                    index = Generator.Manager.AddConstantFloat((float)value);
                    break;
                case ItemTypeCode.Long:
                    index = Generator.Manager.AddConstantLong((long)value);
                    break;
                case ItemTypeCode.Double:
                    index = Generator.Manager.AddConstantDouble((double)value);
                    break;
                case ItemTypeCode.Object:
                    index = Generator.Manager.AddConstantString((string)value);
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (TypeCode == ItemTypeCode.Long || TypeCode == ItemTypeCode.Double)
            {
                Generator.Emit(OpCodeValue.ldc2_w, index);
            }
            else if (index <= 255)
            {
                Generator.Emit(OpCodeValue.ldc, (byte)index);
            }
            else
            {
                Generator.Emit(OpCodeValue.ldc_w, index);
            }
        }

        public override Item Load()
        {
            switch (TypeCode)
            {
                case ItemTypeCode.Int:
                case ItemTypeCode.Byte:
                case ItemTypeCode.Short:
                case ItemTypeCode.Char:
                    var ival = (int)value;

                    if (-1 <= ival && ival <= 5)
                    {
                        Generator.Emit(OpCodeValue.iconst_0 + (byte)ival);
                    }
                    else if (byte.MinValue <= ival && ival <= byte.MaxValue)
                    {
                        Generator.Emit(OpCodeValue.bipush, (byte)ival);
                    }
                    else if (short.MinValue <= ival && ival <= short.MaxValue)
                    {
                        Generator.Emit(OpCodeValue.sipush, (short)ival);
                    }
                    else
                    {
                        LoadConstant();
                    }
                    break;
                case ItemTypeCode.Long:
                    var lval = (long)value;

                    if (lval == 0 || lval == 1)
                    {
                        Generator.Emit(OpCodeValue.lconst_0 + (byte)lval);
                    }
                    else
                    {
                        LoadConstant();
                    }
                    break;
                case ItemTypeCode.Float:
                    var fval = (float)value;
                    if (fval == 0.0f || fval == 1.0f || fval == 2.0f)
                    {
                        Generator.Emit(OpCodeValue.fconst_0 + (byte)fval);
                    }
                    else
                    {
                        LoadConstant();
                    }
                    break;
                case ItemTypeCode.Double:
                    var dval = (double)value;

                    if (dval == 0.0d || dval == 1.0d)
                    {
                        Generator.Emit(OpCodeValue.dconst_0 + (byte)dval);
                    }
                    else
                    {
                        LoadConstant();
                    }
                    break;
                case ItemTypeCode.Object:
                    LoadConstant();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return TypeCodeHelper.StackItem(Generator, Type);
        }

        public override ConditionalItem Conditional()
        {
            var ival = (int)value;

            return new ConditionalItem(Generator, ival != 0 ? OpCodeValue.@goto : OpCodeValue.jsr);
        }

        public override Item Coerce(Type target)
        {
            var targetCode = TypeCodeHelper.TypeCode(target);

            if (TypeCode == targetCode)
            {
                return this;
            }

            switch (targetCode)
            {
                case ItemTypeCode.Int:
                    if (TypeCodeHelper.Truncate(TypeCode) == ItemTypeCode.Int)
                    {
                        return this;
                    }

                    return new ImmediateItem(Generator, PrimativeTypes.Int, Convert.ToInt32(value));
                case ItemTypeCode.Long:
                    return new ImmediateItem(Generator, PrimativeTypes.Long, Convert.ToInt64(value));
                case ItemTypeCode.Float:
                    return new ImmediateItem(Generator, PrimativeTypes.Float, Convert.ToSingle(value));
                case ItemTypeCode.Double:
                    return new ImmediateItem(Generator, PrimativeTypes.Double, Convert.ToDouble(value));
                case ItemTypeCode.Byte:
                    return new ImmediateItem(Generator, PrimativeTypes.Byte, Convert.ToInt32(value));
                case ItemTypeCode.Char:
                    return new ImmediateItem(Generator, PrimativeTypes.Char, Convert.ToInt32(value));
                case ItemTypeCode.Short:
                    return new ImmediateItem(Generator, PrimativeTypes.Short, Convert.ToInt32(value));
                default:
                    return base.Coerce(target);
            }
        }

        public override string ToString()
        {
            return "immediate(" + value + ")";
        }
    }
}