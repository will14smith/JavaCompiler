using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilers.Items
{
    internal class MemberItem : Item
    {
        private readonly IMember member;
        private readonly bool nonVirtual;

        public MemberItem(ByteCodeGenerator generator, IMember member, bool nonVirtual)
            : base(generator, member.ReturnType)
        {
            this.nonVirtual = nonVirtual;
            this.member = member;
        }

        public override Item Load()
        {
            short index = Generator.Manager.AddConstantFieldref((Field) member);

            Generator.Emit(OpCodes.getfield, index);

            return StackItem[(int) TypeCode];
        }

        public override void Store()
        {
            short index = Generator.Manager.AddConstantFieldref((Field) member);

            Generator.Emit(OpCodes.putfield, index);
        }

        public override Item Invoke()
        {
            ItemTypeCode rescode = TypeCodeHelper.TypeCode(member.ReturnType);

            var method = (Method) member;
            if (member.DeclaringType is Interface)
            {
                short index = Generator.Manager.AddConstantInterfaceMethodref(method);

                Generator.Emit(OpCodes.invokeinterface, index, (byte) method.Parameters.Count, 0);
            }
            else if (nonVirtual)
            {
                short index = Generator.Manager.AddConstantMethodref(method);

                Generator.Emit(OpCodes.invokespecial, index);
            }
            else
            {
                short index = Generator.Manager.AddConstantMethodref(method);

                Generator.Emit(OpCodes.invokevirtual, index);
            }

            return StackItem[(int) rescode];
        }

        public override void Duplicate()
        {
            StackItem[(int) ItemTypeCode.Object].Duplicate();
        }

        public override void Drop()
        {
            StackItem[(int) ItemTypeCode.Object].Drop();
        }

        public override void Stash(ItemTypeCode code)
        {
            StackItem[(int) ItemTypeCode.Object].Stash(code);
        }

        public override int Width()
        {
            return 1;
        }

        public override string ToString()
        {
            return "member(" + member + (nonVirtual ? " nonvirtual)" : ")");
        }
    }
}