using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;

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
            Generator.Emit(OpCodeValue.aload_0);

            return TypeCodeHelper.StackItem(Generator, Type);
        }

        public override string ToString()
        {
            return isSuper ? "super" : "this";
        }
    }
}