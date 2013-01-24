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
            var field = (Field)member;
            short index = Generator.Manager.AddConstantFieldref((Field)member);

            Generator.EmitGetfield(index, field);

            return TypeCodeHelper.StackItem(Generator, Type);
        }

        public override void Store()
        {
            var field = (Field) member;
            short index = Generator.Manager.AddConstantFieldref(field);

            Generator.EmitPutfield(index, field);
        }

        public override Item Invoke()
        {
            var method = (Method)member;
            if (member.DeclaringType is Interface)
            {
                var index = Generator.Manager.AddConstantInterfaceMethodref(method);

                Generator.EmitInvokeinterface(index, method);
            }
            else if (nonVirtual)
            {
                var index = Generator.Manager.AddConstantMethodref(method);

                Generator.EmitInvokespecial(index, method);
            }
            else
            {
                var index = Generator.Manager.AddConstantMethodref(method);

                Generator.EmitInvokevirtual(index, method);
            }

            return TypeCodeHelper.StackItem(Generator, member.ReturnType);
        }

        public override void Duplicate()
        {
            TypeCodeHelper.StackItem(Generator, Type).Duplicate();
        }

        public override void Drop()
        {
            TypeCodeHelper.StackItem(Generator, Type).Drop();
        }

        public override void Stash(ItemTypeCode code)
        {
            TypeCodeHelper.StackItem(Generator, Type).Stash(code);
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