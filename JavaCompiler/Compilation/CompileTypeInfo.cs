using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilation
{
    public class CompileTypeInfo
    {
        public CompileTypeInfo()
        {
            Constants = new List<CompileConstant>();

            Interfaces = new List<short>();
            Fields = new List<CompileFieldInfo>();
            Methods = new List<CompileMethodInfo>();
            Attributes = new List<CompileAttribute>();
        }

        public string Name { get; set; }

        public ClassModifier Modifiers { get; set; }

        public short ThisClass { get; set; }
        public short SuperClass { get; set; }

        public List<CompileConstant> Constants { get; private set; }

        public List<short> Interfaces { get; private set; }
        public List<CompileFieldInfo> Fields { get; private set; }
        public List<CompileMethodInfo> Methods { get; private set; }
        public List<CompileAttribute> Attributes { get; private set; }

        #region Read
        public void Read(Stream stream)
        {
            var reader = new EndianBinaryReader(EndianBitConverter.Big, stream);

            var magic = reader.ReadInt32();

            var minorVersion = reader.ReadInt16();
            var majorVersion = reader.ReadInt16();

            ReadConstants(reader);

            Modifiers = (ClassModifier)reader.ReadInt16();

            ThisClass = reader.ReadInt16();
            SuperClass = reader.ReadInt16();

            Name = GetClass(ThisClass).GetDescriptor(false);

            ReadInterfaces(reader);
            ReadFields(reader);
            ReadMethods(reader);
            Attributes = ReadAttributes(reader);
        }

        private void ReadConstants(EndianBinaryReader reader)
        {
            var constantCount = reader.ReadInt16();

            Constants.Add(null);
            for (var i = 1; i < constantCount; i++)
            {
                var tag = (CompileConstants)reader.ReadByte();
                switch (tag)
                {
                    case CompileConstants.Class:
                        Constants.Add(new CompileConstantClass().Read(reader));
                        break;
                    case CompileConstants.Fieldref:
                        Constants.Add(new CompileConstantFieldref().Read(reader));
                        break;
                    case CompileConstants.Methodref:
                        Constants.Add(new CompileConstantMethodref().Read(reader));
                        break;
                    case CompileConstants.InterfaceMethodref:
                        Constants.Add(new CompileConstantInterfaceMethodref().Read(reader));
                        break;
                    case CompileConstants.String:
                        Constants.Add(new CompileConstantString().Read(reader));
                        break;
                    case CompileConstants.Integer:
                        Constants.Add(new CompileConstantInteger().Read(reader));
                        break;
                    case CompileConstants.Float:
                        Constants.Add(new CompileConstantFloat().Read(reader));
                        break;
                    case CompileConstants.Long:
                        Constants.Add(new CompileConstantLong().Read(reader));
                        Constants.Add(null); // The next slot is invalid
                        i++;
                        break;
                    case CompileConstants.Double:
                        Constants.Add(new CompileConstantDouble().Read(reader));
                        Constants.Add(null); // The next slot is invalid
                        i++;
                        break;
                    case CompileConstants.NameAndType:
                        Constants.Add(new CompileConstantNameAndType().Read(reader));
                        break;
                    case CompileConstants.Utf8:
                        Constants.Add(new CompileConstantUtf8().Read(reader));
                        break;
                    case CompileConstants.MethodHandle:
                        Constants.Add(new CompileConstantMethodHandle().Read(reader));
                        break;
                    case CompileConstants.MethodType:
                        Constants.Add(new CompileConstantMethodType().Read(reader));
                        break;
                    case CompileConstants.InvokeDynamic:
                        Constants.Add(new CompileConstantInvokeDynamic().Read(reader));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private void ReadInterfaces(EndianBinaryReader reader)
        {
            var interfaceCount = reader.ReadInt16();

            for (var i = 0; i < interfaceCount; i++)
            {
                Interfaces.Add(reader.ReadInt16());
            }
        }

        private void ReadFields(EndianBinaryReader reader)
        {
            var fieldCount = reader.ReadInt16();
            for (var i = 0; i < fieldCount; i++)
            {
                var field = new CompileFieldInfo();

                field.Modifiers = (Modifier)reader.ReadInt16();
                field.Name = reader.ReadInt16();
                field.Descriptor = reader.ReadInt16();

                field.Attributes.AddRange(ReadAttributes(reader));

                Fields.Add(field);
            }
        }

        private void ReadMethods(EndianBinaryReader reader)
        {
            var methodCount = reader.ReadInt16();

            for (var i = 0; i < methodCount; i++)
            {
                var method = new CompileMethodInfo();

                method.Modifiers = (Modifier)reader.ReadInt16();
                method.Name = reader.ReadInt16();
                method.Descriptor = reader.ReadInt16();

                method.Attributes.AddRange(ReadAttributes(reader));

                Methods.Add(method);
            }
        }

        private List<CompileAttribute> ReadAttributes(EndianBinaryReader reader)
        {
            var attributeCount = reader.ReadInt16();
            var attributes = new List<CompileAttribute>();

            for (var i = 0; i < attributeCount; i++)
            {
                attributes.Add(CompileAttribute.ReadAttribute(reader, Constants));
            }

            return attributes;
        }
        #endregion
        #region Write
        public void Write(EndianBinaryWriter writer)
        {
            // magic
            writer.Write(new byte[] { 0xCA, 0xFE, 0xBA, 0xBE });
            // version (minor, major)
            writer.Write(new byte[] { 0x00, 0x00, 0x00, 0x33 });
            // const pool
            WriteConstBytes(writer);
            // access flags
            WriteModiferBytes(writer);
            // this class
            writer.Write(ThisClass);
            // super class
            writer.Write(SuperClass);
            // interfaces
            WriteInterfaceBytes(writer);
            // fields
            WriteFieldBytes(writer);
            // methods
            WriteMethodBytes(writer);
            // attributes
            WriteAttributeBytes(writer);
        }

        private void WriteConstBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)(Constants.Count + 1));

            foreach (var constant in Constants.Where(constant => constant != null))
            {
                writer.Write(constant.Tag);
                constant.Write(writer);
            }
        }

        private void WriteModiferBytes(EndianBinaryWriter writer)
        {
            var modifierValue = (short)((int)Modifiers & 0x631);

            writer.Write(modifierValue);
        }

        private void WriteInterfaceBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)Interfaces.Count());

            foreach (short i in Interfaces)
            {
                writer.Write(i);
            }
        }

        private void WriteFieldBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)Fields.Count());

            foreach (CompileFieldInfo field in Fields)
            {
                field.Write(writer);
            }
        }

        private void WriteMethodBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)Methods.Count());

            foreach (CompileMethodInfo method in Methods)
            {
                method.Write(writer);
            }
        }

        private void WriteAttributeBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)Attributes.Count());

            foreach (CompileAttribute attribute in Attributes)
            {
                writer.Write(attribute.NameIndex);
                writer.Write(attribute.Length);

                attribute.Write(writer);
            }
        }

        #endregion

        #region ToType
        public Type ToType()
        {
            throw new NotImplementedException();
            /*var c = new Class
            {
                Name = GetClass(thisClass, constants).Name,
                Modifiers = modifiers,
                Super = (SuperClass == 0 ? null : GetClass(SuperClass, constants)) as Class
            };

            c.Interfaces.AddRange(interfaces.Select(x => GetClass(x, constants)).OfType<Interface>());
            c.Fields.AddRange(fields.Select(x => GetField(c, x, constants)));

            List<Method> javaMethods = methods.Select(x => GetMethod(c, x, constants)).ToList();

            c.Methods.AddRange(javaMethods.Where(x => x.Name != "<init>"));
            c.Constructors.AddRange(javaMethods.Where(x => x.Name == "<init>").Select(x => (Constructor)x));

            return c;*/
        }

        private DefinedType GetClass(short index)
        {
            var constant = Constants[index];

            var compileConstantClass = constant as CompileConstantClass;
            if (compileConstantClass != null)
            {
                return new PlaceholderType { Name = GetUtf8(compileConstantClass.NameIndex).Replace('/', '.') };
            }

            throw new InvalidOperationException();
        }
        private string GetUtf8(short index)
        {
            var constant = Constants[index];

            var compileConstantUtf8 = constant as CompileConstantUtf8;
            if (compileConstantUtf8 != null)
            {
                return new string(new JavaTextEncoding().GetChars(compileConstantUtf8.Value));
            }

            throw new InvalidOperationException();
        }

        #endregion

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
