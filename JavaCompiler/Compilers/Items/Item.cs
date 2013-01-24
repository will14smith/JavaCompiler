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

            var definedType = type as DefinedType;
            if (definedType != null)
            {
                definedType.Resolve(generator.Manager.Imports);
            }

            Type = type;
            TypeCode = TypeCodeHelper.TypeCode(type);
        }

        public ItemTypeCode TypeCode { get; private set; }
        public Type Type { get; private set; }

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
            TypeCodeHelper.StackItem(Generator, Type).Duplicate();
        }

        public virtual ConditionalItem Conditional()
        {
            Load();

            return new ConditionalItem(Generator, OpCodes.ifne);
        }

        public virtual void Duplicate()
        {
            throw new InvalidOperationException();
        }

        public virtual void Drop()
        {
            throw new InvalidOperationException();
        }

        public virtual Item Coerce(Type target)
        {
            var targetCode = TypeCodeHelper.TypeCode(target);

            if (TypeCode == targetCode)
                return this;

            Load();

            var typecode1 = TypeCodeHelper.Truncate(TypeCode);
            var targetcode1 = TypeCodeHelper.Truncate(targetCode);

            if (typecode1 != targetcode1)
            {
                var offset = targetcode1 > typecode1 ? targetcode1 - 1 : targetcode1;
                var opcode = (int)OpCodeValue.i2l + (int)typecode1 * 3 + offset;

                Generator.InternalEmit((OpCodeValue)opcode);
            }
            if (targetCode != targetcode1)
            {
                var opcode = (int)OpCodeValue.i2b + targetCode - ItemTypeCode.Byte;

                Generator.InternalEmit((OpCodeValue)opcode);
            }

            return TypeCodeHelper.StackItem(Generator, target);
        }

        public virtual int Width()
        {
            return 0;
        }
    }
}