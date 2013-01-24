using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Items
{
    internal class IndexedItem : Item
    {
        public IndexedItem(ByteCodeGenerator generator, Type type)
            : base(generator, type)
        {
        }

        public override Item Load()
        {
            Generator.Emit(OpCodeValue.iaload + (byte)TypeCode);

            return TypeCodeHelper.StackItem(Generator, Type);
        }

        public override void Store()
        {
            Generator.Emit(OpCodeValue.iastore + (byte)TypeCode);
        }

        public override void Duplicate()
        {
            Generator.Emit(OpCodeValue.dup2);
        }

        public override void Drop()
        {
            Generator.Emit(OpCodeValue.pop2);
        }

        public override void Stash(ItemTypeCode code)
        {
            Generator.Emit(OpCodeValue.dup_x2 + (byte)(3 * (TypeCodeHelper.Width(code) - 1)));
        }

        public override int Width()
        {
            return 2;
        }

        public override String ToString()
        {
            return "indexed(" + TypeCodeHelper.Name(TypeCode) + ")";
        }
    }
}