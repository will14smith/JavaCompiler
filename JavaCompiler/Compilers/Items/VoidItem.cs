using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Compilers.Items
{
    internal class VoidItem : Item
    {
        public VoidItem(ByteCodeGenerator generator) : base(generator, PrimativeTypes.Void)
        {
        }

        public override string ToString()
        {
            return "void";
        }
    }
}