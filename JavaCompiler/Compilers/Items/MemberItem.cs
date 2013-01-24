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
            short index = Generator.Manager.AddConstantFieldref((Field)member);

            Generator.Emit(OpCodes.getfield, index);

            return TypeCodeHelper.StackItem(Generator, Type);
        }

        public override void Store()
        {
            short index = Generator.Manager.AddConstantFieldref((Field)member);

            Generator.Emit(OpCodes.putfield, index);
        }

        public override Item Invoke()
        {
            var method = (Method)member;
            if (member.DeclaringType is Interface)
            {
                var index = Generator.Manager.AddConstantInterfaceMethodref(method);

                Generator.EmitInvoke(OpCodes.invokeinterface, (short)method.Parameters.Count, index, (byte)method.Parameters.Count, 0);
            }
            else if (nonVirtual)
            {
                var index = Generator.Manager.AddConstantMethodref(method);

                Generator.EmitInvoke(OpCodes.invokespecial, (short)method.Parameters.Count, index);
            }
            else
            {
                var index = Generator.Manager.AddConstantMethodref(method);

                Generator.EmitInvoke(OpCodes.invokevirtual, (short)method.Parameters.Count, index);
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