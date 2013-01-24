using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilers.Items
{
    public class StackItem : Item
    {
        public StackItem(ByteCodeGenerator generator, Type type)
            : base(generator, type)
        {
        }

        public override Item Load()
        {
            return this;
        }

        public override void Duplicate()
        {
            Generator.Emit(Width() == 2 ? OpCodeValue.dup2 : OpCodeValue.dup);
        }

        public override void Drop()
        {
            Generator.Emit(Width() == 2 ? OpCodeValue.pop2 : OpCodeValue.pop);
        }

        public override void Stash(ItemTypeCode code)
        {
            Generator.Emit((Width() == 2 ? OpCodeValue.dup_x2 : OpCodeValue.dup_x1) + (byte)(3 * (TypeCodeHelper.Width(code) - 1)));
        }

        public override int Width()
        {
            return TypeCodeHelper.Width(TypeCode);
        }

        public override string ToString()
        {
            return "stack(" + TypeCodeHelper.Name(TypeCode) + ")";
        }
    }
}