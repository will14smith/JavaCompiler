using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Items
{
    internal class LocalItem : Item
    {
        private readonly short reg;
        private readonly Type type;

        public LocalItem(ByteCodeGenerator generator, Variable localVariable)
            : this(generator, localVariable.Type, localVariable.Index)
        {
        }

        public LocalItem(ByteCodeGenerator generator, Type type, short reg)
            : base(generator, type)
        {
            this.reg = reg;
            this.type = type;
        }

        public override Item Load()
        {
            if (reg <= 3)
            {
                Generator.Emit((OpCodeValue)((byte)OpCodeValue.iload_0 + (byte)TypeCodeHelper.Truncate(TypeCode) * 4 + reg));
            }
            else
            {
                Generator.Emit(OpCodeValue.iload + (byte)TypeCodeHelper.Truncate(TypeCode), reg);
            }

            return TypeCodeHelper.StackItem(Generator, Type);
        }

        public override void Store()
        {
            if (reg <= 3)
            {
                Generator.Emit((OpCodeValue)((byte)OpCodeValue.istore_0 + (byte)TypeCodeHelper.Truncate(TypeCode) * 4 + reg));
            }
            else if(reg <= 255)
            {
                Generator.Emit(OpCodeValue.istore + (byte)TypeCodeHelper.Truncate(TypeCode), (byte) reg);
            }
            else
            {
                Generator.Emit(OpCodeValue.istore + (byte)TypeCodeHelper.Truncate(TypeCode), reg);
            }

            //TODO: code.setDefined(reg);
        }


        public override String ToString()
        {
            return "localItem(type=" + type + "; reg=" + reg + ")";
        }

        public void Incr(int x)
        {
            if (TypeCode == ItemTypeCode.Int && x >= -32768 && x <= 32767)
            {
                Generator.EmitWide(OpCodeValue.iinc, reg, (short)x);
            }
            else
            {
                Load();
                if (x >= 0)
                {
                    new ImmediateItem(Generator, PrimativeTypes.Int, x).Load();
                    Generator.Emit(OpCodeValue.iadd);
                }
                else
                {
                    new ImmediateItem(Generator, PrimativeTypes.Int, -x).Load();
                    Generator.Emit(OpCodeValue.isub);
                }

                new StackItem(Generator, PrimativeTypes.Int).Coerce(Type);
                Store();
            }
        }
    }
}