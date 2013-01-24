using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilers.Items
{
    internal class StaticItem : Item
    {
        private readonly IMember member;

        public StaticItem(ByteCodeGenerator generator, IMember member)
            : base(generator, member.ReturnType)
        {
            this.member = member;
        }

        public override Item Load()
        {
            var field = (Field)member;
            short index = Generator.Manager.AddConstantFieldref(field);

            Generator.EmitGetstatic(index, field);

            return TypeCodeHelper.StackItem(Generator, Type);
        }

        public override void Store()
        {
            var field = (Field)member;
            short index = Generator.Manager.AddConstantFieldref(field);

            Generator.EmitPutstatic(index, field);
        }

        public override Item Invoke()
        {
            var method = (Method)member;
            var index = Generator.Manager.AddConstantMethodref(method);

            Generator.EmitInvokestatic(index, method);

            return TypeCodeHelper.StackItem(Generator, member.ReturnType);
        }

        public override string ToString()
        {
            return "static(" + member + ")";
        }
    }
}