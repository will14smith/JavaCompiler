using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilers.Items
{
    internal class AssignItem : Item
    {
        private readonly Item lhs;

        public AssignItem(ByteCodeGenerator generator, Item lhs)
            : base(generator, lhs.Type)
        {
            this.lhs = lhs;
        }

        public override Item Load()
        {
            lhs.Stash(TypeCode);
            lhs.Store();

            return StackItem[(int) TypeCode];
        }

        public override void Duplicate()
        {
            Load().Duplicate();
        }

        public override void Drop()
        {
            lhs.Store();
        }

        public override void Stash(ItemTypeCode code)
        {
            throw new InvalidOperationException();
        }

        public override int Width()
        {
            return lhs.Width() + TypeCodeHelper.Width(TypeCode);
        }

        public override String ToString()
        {
            return "assign(lhs = " + lhs + ")";
        }
    }
}