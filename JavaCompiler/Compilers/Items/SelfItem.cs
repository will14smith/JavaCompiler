using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Compilers.Items
{
    internal class SelfItem : Item
    {
        private readonly bool isSuper;

        public SelfItem(ByteCodeGenerator generator, Type scope, bool isSuper)
            : base(generator, scope)
        {
            this.isSuper = isSuper;
        }

        public bool IsSuper
        {
            get { return isSuper; }
        }

        public override Item Load()
        {
            Generator.Emit(OpCodes.aload_0);

            return StackItem[(int) TypeCode];
        }

        public override string ToString()
        {
            return isSuper ? "super" : "this";
        }
    }
}