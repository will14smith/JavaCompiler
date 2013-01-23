using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Items
{
    class IndexedItem : Item
    {
        public IndexedItem(ByteCodeGenerator generator, Type type)
            : base(generator, type) { }

        public override Item Load()
        {
            Generator.InternalEmit(OpCodeValue.iaload + (byte)TypeCode);

            return StackItem[(int) TypeCode];
        }

        public override void Store()
        {
            Generator.InternalEmit(OpCodeValue.iastore + (byte)TypeCode);
        }

        public override void Duplicate()
        {
            Generator.Emit(OpCodes.dup2);
        }

        public override void Drop()
        {
            Generator.Emit(OpCodes.pop2);
        }

        public override void Stash(ItemTypeCode code)
        {
            Generator.InternalEmit(OpCodeValue.dup_x2 + (byte) (3 * (TypeCodeHelper.Width(code) - 1)));
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
