using System;
using JavaCompiler.Compilation.ByteCode;

namespace JavaCompiler.Compilers.Items
{
    class SelfItem : Item
    {
        private readonly bool isSuper;

        public SelfItem(ByteCodeGenerator generator, bool isSuper)
            : base(generator, ItemTypeCode.Object)
        {
            this.isSuper = isSuper;
        }

        public bool IsSuper { get { return isSuper; } }

        public override Item Load()
        {
            Generator.Emit(OpCodes.aload_0);

            return StackItem[(int)TypeCode];
        }

        public override String ToString()
        {
            return isSuper ? "super" : "this";
        }
    }
}
