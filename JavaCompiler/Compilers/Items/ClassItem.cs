using JavaCompiler.Compilation.ByteCode;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Items
{
    class ClassItem : Item
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
