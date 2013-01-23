using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Items
{
    public enum ItemTypeCode
    {
        Int = 0,
        Long = 1,
        Float = 2,
        Double = 3,
        Object = 4,
        Byte = 5,
        Char = 6,
        Short = 7,
        Void = 8,
        TypeCodeCount = 9
    }

    public abstract class Item
    {
        protected ByteCodeGenerator Generator;

        protected Item(ByteCodeGenerator generator, Type type)
        {
            Generator = generator;

            if (type is DefinedType)
            {
                ((DefinedType) type).Resolve(generator.Manager.Imports);
            }

            Type = type;
            TypeCode = TypeCodeHelper.TypeCode(type);
        }

        public ItemTypeCode TypeCode { get; private set; }
        public Type Type { get; private set; }

        protected Item[] StackItem
        {
            get { return Generator.StackItem; }
        }

        public virtual Item Load()
        {
            throw new InvalidOperationException();
        }

        public virtual void Store()
        {
            throw new InvalidOperationException();
        }

        public virtual Item Invoke()
        {
            throw new InvalidOperationException();
        }

        public virtual void Stash(ItemTypeCode code)
        {
            StackItem[(int) code].Duplicate();
        }

        public virtual void Duplicate()
        {
            throw new InvalidOperationException();
        }

        public virtual void Drop()
        {
            throw new InvalidOperationException();
        }

        public virtual Item Coerce(ItemTypeCode targetCode)
        {
            if (TypeCode == targetCode)
                return this;

            Load();

            ItemTypeCode typecode1 = TypeCodeHelper.Truncate(TypeCode);
            ItemTypeCode targetcode1 = TypeCodeHelper.Truncate(targetCode);

            if (typecode1 != targetcode1)
            {
                ItemTypeCode offset = targetcode1 > typecode1 ? targetcode1 - 1 : targetcode1;

                ItemTypeCode opcode = (int) OpCodeValue.i2l + (int) typecode1*3 + offset;

                Generator.InternalEmit((OpCodeValue) opcode);
            }
            if (targetCode != targetcode1)
            {
                int opcode = (int) OpCodeValue.i2b + targetCode - ItemTypeCode.Byte;

                Generator.InternalEmit((OpCodeValue) opcode);
            }

            return StackItem[(int) targetCode];
        }

        public virtual int Width()
        {
            return 0;
        }
    }
}