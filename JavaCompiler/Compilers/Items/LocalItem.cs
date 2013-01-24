using System;
using JavaCompiler.Compilation.ByteCode;
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
                Generator.InternalEmit(
                    (OpCodeValue) ((byte) OpCodeValue.iload_0 + (byte) TypeCodeHelper.Truncate(TypeCode)*4 + reg));
            }
            else
            {
                Generator.InternalEmit(OpCodeValue.iload + (byte) TypeCodeHelper.Truncate(TypeCode));
                Generator.InternalEmitShort(reg);
            }

            return TypeCodeHelper.StackItem(Generator, Type);
        }

        public override void Store()
        {
            if (reg <= 3)
            {
                Generator.InternalEmit(
                    (OpCodeValue) ((byte) OpCodeValue.istore_0 + (byte) TypeCodeHelper.Truncate(TypeCode)*4 + reg));
            }
            else
            {
                Generator.InternalEmit(OpCodeValue.istore + (byte) TypeCodeHelper.Truncate(TypeCode));
                Generator.InternalEmitShort(reg);
            }

            //TODO: code.setDefined(reg);
        }


        public override String ToString()
        {
            return "localItem(type=" + type + "; reg=" + reg + ")";
        }
    }
}