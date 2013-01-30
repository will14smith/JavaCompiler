using System;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
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

            if (type is PlaceholderType)
            {
                type = ClassLocator.Find(type, generator.Manager.Imports);
            }

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

            return new ConditionalItem(Generator, OpCodeValue.ifne);
        }

        public virtual void Duplicate()
        {
        }

        public virtual void Drop()
        {
        }

        public virtual Item Coerce(Type target)
        {
            var targetCode = TypeCodeHelper.TypeCode(target);

            if (TypeCode == targetCode)
                return this;

            Load();

            var typecode1 = TypeCodeHelper.Truncate(TypeCode);
            var targetcode1 = TypeCodeHelper.Truncate(targetCode);

            if (typecode1 != ItemTypeCode.Object && targetcode1 == ItemTypeCode.Object)
            {
                return CoercePrimative(target as DefinedType);
            }

            if (typecode1 != targetcode1)
            {
                var offset = targetcode1 > typecode1 ? targetcode1 - 1 : targetcode1;
                var opcode = (int)OpCodeValue.i2l + (int)typecode1 * 3 + offset;

                Generator.Emit((OpCodeValue)opcode);
            }
            if (targetCode != targetcode1)
            {
                var opcode = (int)OpCodeValue.i2b + targetCode - ItemTypeCode.Byte;

                Generator.Emit((OpCodeValue)opcode);
            }

            return TypeCodeHelper.StackItem(Generator, target);
        }

        private Item CoercePrimative(DefinedType target)
        {
            var typecode1 = TypeCodeHelper.Truncate(TypeCode);

            switch (typecode1)
            {
                case ItemTypeCode.Int:
                    if (target.Name != "java.lang.Integer")
                    {
                        throw new InvalidOperationException();
                    }
                    var valueOf = target.Methods.Single(x => x.Name == "valueOf" && x.Parameters.Count == 1 && x.Parameters.First().Type == PrimativeTypes.Int);
                    var valueOfIndex = Generator.Manager.AddConstantMethodref(valueOf);

                    Generator.EmitInvokestatic(valueOfIndex, valueOf);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return TypeCodeHelper.StackItem(Generator, target);
        }

        public virtual int Width()
        {
            return 0;
        }
    }
}