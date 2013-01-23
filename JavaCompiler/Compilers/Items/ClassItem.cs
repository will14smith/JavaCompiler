using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Compilers.Items
{
    internal class ClassItem : Item
    {
        public ClassItem(ByteCodeGenerator generator, Type type) : base(generator, type)
        {
        }

        public override Item Load()
        {
            return StackItem[(int) ItemTypeCode.Void];
        }
    }
}