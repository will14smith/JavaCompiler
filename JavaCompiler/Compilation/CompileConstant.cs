using System;
using JavaCompiler.Utilities;

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
        NameAndType = 12,
        Utf8 = 1,
        MethodHandle = 15,
        MethodType = 16,
        InvokeDynamic = 18
    }

    public abstract class CompileConstant
    {
        public short PoolIndex { get; set; }

        public abstract byte Tag { get; }

        public abstract void Write(EndianBinaryWriter writer);
        public abstract CompileConstant Read(EndianBinaryReader reader);
    }

    public class CompileConstantClass : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.Class; }
        }

        public short NameIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(NameIndex);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            NameIndex = reader.ReadInt16();

            return this;
        }
    }

    public class CompileConstantFieldref : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.Fieldref; }
        }

        public short ClassIndex { get; set; }
        public short NameAndTypeIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(ClassIndex);
            writer.Write(NameAndTypeIndex);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            ClassIndex = reader.ReadInt16();
            NameAndTypeIndex = reader.ReadInt16();

            return this;
        }
    }

    public class CompileConstantMethodref : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.Methodref; }
        }

        public short ClassIndex { get; set; }
        public short NameAndTypeIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(ClassIndex);
            writer.Write(NameAndTypeIndex);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            ClassIndex = reader.ReadInt16();
            NameAndTypeIndex = reader.ReadInt16();

            return this;
        }
    }

    public class CompileConstantInterfaceMethodref : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.InterfaceMethodref; }
        }

        public short ClassIndex { get; set; }
        public short NameAndTypeIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(ClassIndex);
            writer.Write(NameAndTypeIndex);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            ClassIndex = reader.ReadInt16();
            NameAndTypeIndex = reader.ReadInt16();

            return this;
        }
    }

    public class CompileConstantString : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.String; }
        }

        public short StringIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(StringIndex);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            StringIndex = reader.ReadInt16();

            return this;
        }
    }

    public class CompileConstantInteger : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.Integer; }
        }

        public int Value { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(Value);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            Value = reader.ReadInt32();

            return this;
        }
    }

    public class CompileConstantFloat : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.Float; }
        }

        public float Value { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(Value);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            Value = reader.ReadSingle();

            return this;
        }
    }

    public class CompileConstantLong : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.Long; }
        }

        public long Value { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(Value);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            Value = reader.ReadInt64();

            return this;
        }
    }

    public class CompileConstantDouble : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.Double; }
        }

        public double Value { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(Value);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            Value = reader.ReadDouble();

            return this;
        }
    }

    public class CompileConstantNameAndType : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.NameAndType; }
        }

        public short NameIndex { get; set; }
        public short DescriptorIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(NameIndex);
            writer.Write(DescriptorIndex);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            NameIndex = reader.ReadInt16();
            DescriptorIndex = reader.ReadInt16();

            return this;
        }
    }

    public class CompileConstantUtf8 : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.Utf8; }
        }

        public byte[] Value { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write((short) Value.Length);
            writer.Write(Value);
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            short length = reader.ReadInt16();

            Value = reader.ReadBytes(length);

            return this;
        }

        public override string ToString()
        {
            return new string(new JavaTextEncoding().GetChars(Value));
        }
    }

    public class CompileConstantMethodHandle : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.MethodHandle; }
        }

        public byte RefKind { get; set; }
        public short RefIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            throw new NotImplementedException();
        }
    }

    public class CompileConstantMethodType : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.MethodType; }
        }

        public short DescriptorIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            throw new NotImplementedException();
        }
    }

    public class CompileConstantInvokeDynamic : CompileConstant
    {
        public override byte Tag
        {
            get { return (byte) CompileConstants.InvokeDynamic; }
        }

        public short BootstrapIndex { get; set; }
        public short NameAndTypeIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public override CompileConstant Read(EndianBinaryReader reader)
        {
            throw new NotImplementedException();
        }
    }
}