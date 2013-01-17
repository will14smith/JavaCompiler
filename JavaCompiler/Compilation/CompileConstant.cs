namespace JavaCompiler.Compilation
{
    public enum CompileConstants : byte
    {
        Class = 7,
        Fieldref = 9,
        Methodref = 10,
        InterfaceMethodref = 11,
        String = 8,
        Integer = 3,
        Float = 4,
        Long = 5,
        Double = 6,
        NameAndType =12,
        Utf8 = 1,
        MethodHandle = 15,
        MethodType = 16,
        InvokeDynamic = 18
    }

    public abstract class CompileConstant
    {
        public abstract byte Tag { get; }
    }

    public class CompileConstantClass : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.Class; } }

        public short NameIndex { get; set; }
    }
    public class CompileConstantFieldref : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.Fieldref; } }

        public short ClassIndex { get; set; }
        public short NameAndTypeIndex { get; set; }
    }
    public class CompileConstantMethodref : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.Methodref; } }

        public short ClassIndex { get; set; }
        public short NameAndTypeIndex { get; set; }
    }
    public class CompileConstantInterfaceMethodref : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.InterfaceMethodref; } }

        public short ClassIndex { get; set; }
        public short NameAndTypeIndex { get; set; }
    }
    public class CompileConstantString : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.String; } }

        public short StringIndex { get; set; }
    }
    public class CompileConstantInteger : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.Integer; } }

        public byte[] Value { get; set; }
    }
    public class CompileConstantFloat : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.Float; } }

        public byte[] Value { get; set; }
    }
    public class CompileConstantLong : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.Long; } }

        public byte[] HValue { get; set; }
        public byte[] LValue { get; set; }
    }
    public class CompileConstantDouble : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.Double; } }

        public byte[] HValue { get; set; }
        public byte[] LValue { get; set; }
    }
    public class CompileConstantNameAndType : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.NameAndType; } }

        public short NameIndex { get; set; }
        public short DescriptorIndex { get; set; }
    }
    public class CompileConstantUtf8 : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.NameAndType; } }

        public short Length { get; set; }
        public byte[] Value { get; set; }
    }
    public class CompileConstantMethodHandle : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.MethodHandle; } }

        public byte RefKind { get; set; }
        public short RefIndex { get; set; }
    }
    public class CompileConstantMethodType : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.MethodType; } }

        public short DescriptorIndex { get; set; }
    }
    public class CompileConstantInvokeDynamic : CompileConstant
    {
        public override byte Tag { get { return (byte)CompileConstants.InvokeDynamic; } }

        public short BootstrapIndex { get; set; }
        public short NameAndTypeIndex { get; set; }
    }
}
