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
            short index = Generator.Manager.AddConstantFieldref((Field)member);

            Generator.Emit(OpCodes.getstatic, index);

            return StackItem[(int)TypeCode];
        }

        public override void Store()
        {
            short index = Generator.Manager.AddConstantFieldref((Field)member);

            Generator.Emit(OpCodes.putstatic, index);
        }

        public override Item Invoke()
        {
            ItemTypeCode rescode = TypeCodeHelper.TypeCode(member.ReturnType);

            var method = (Method)member;
            short index = Generator.Manager.AddConstantMethodref(method);

            Generator.EmitInvoke(OpCodes.invokestatic, (short)method.Parameters.Count, index);

            return StackItem[(int)rescode];
        }

        public override string ToString()
        {
            return "static(" + member + ")";
        }
    }
}