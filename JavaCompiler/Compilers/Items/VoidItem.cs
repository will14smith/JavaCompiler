using JavaCompiler.Compilation.ByteCode;

namespace JavaCompiler.Compilers.Items
{
    class VoidItem : Item
    {
        public VoidItem(ByteCodeGenerator generator) : base(generator, ItemTypeCode.Void)
        {
        }

        public override string ToString()
        {
            return "void";
        }
    }
}
