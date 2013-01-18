using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JavaCompiler.Reflection;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilation
{
    public class CompileManager
    {
        public CompileManager()
        {
            ConstantPool = new List<CompileConstant>();

            Modifiers = new List<JavaModifier>();
            Fields = new List<CompileFieldInfo>();
            Methods = new List<CompileMethodInfo>();
            Attributes = new List<CompileAttribute>();
        }

        #region Constants
        public List<CompileConstant> ConstantPool { get; private set; }

        public short AddConstantClass(string className)
        {
            var nameIndex = AddConstantUtf8(className);
            var classConst = ConstantPool.OfType<CompileConstantClass>().FirstOrDefault(x => x.NameIndex == nameIndex);

            if (classConst == null)
            {
                classConst = new CompileConstantClass { NameIndex = nameIndex };

                ConstantPool.Add(classConst);
            }

            return (short)ConstantPool.IndexOf(classConst);
        }
        public short AddConstantUtf8(string s)
        {
            var value = Encoding.UTF8.GetBytes(s);
            var utf8Const = ConstantPool.OfType<CompileConstantUtf8>().FirstOrDefault(x => x.Value == value);

            if (utf8Const == null)
            {
                utf8Const = new CompileConstantUtf8 { Length = (short)value.Length, Value = value };

                ConstantPool.Add(utf8Const);
            }

            return (short)ConstantPool.IndexOf(utf8Const);
        }
        public short AddConstantUtf8Type(JavaTypeRef type)
        {
            return AddConstantUtf8(ProcessTypeName(type));
        }

        public static string ProcessTypeName(JavaTypeRef type)
        {
            var name = "";

            for (var i = 0; i < type.ArrayLevels; i++)
            {
                name += "[";
            }

            switch (type)
            {
                case "byte":
                    name += "B";
                    break;
                case "char":
                    name += "C";
                    break;
                case "double":
                    name += "D";
                    break;
                case "float":
                    name += "F";
                    break;
                case "int":
                    name += "I";
                    break;
                case "long":
                    name += "J";
                    break;
                case "short":
                    name += "S";
                    break;
                case "boolean":
                    name += "Z";
                    break;
                case "void":
                    name += "V";
                    break;
                default:
                    name += string.Format("L{0};", type.TypeName);
                    break;
            }

            return name;
        }
        public static string ProcessMethodDescriptor(JavaMethod method)
        {
            var descriptor = "(";

            foreach (var parameter in method.Parameters)
            {
                descriptor += ProcessTypeName(parameter.Type);
            }

            descriptor += ")";

            descriptor += ProcessTypeName(method.ReturnType);

            return descriptor;
        }
        #endregion

        #region Modifiers

        public List<JavaModifier> Modifiers { get; private set; }

        public void SetModifiers(List<JavaModifier> modifiers)
        {
            Modifiers = modifiers ?? new List<JavaModifier>();
        }

        #endregion

        #region Inheritance

        public short ThisClass { get; private set; }
        public short SuperClass { get; private set; }
        public List<short> Interfaces { get; private set; }

        public void SetThisClass(short thisClass)
        {
            ThisClass = thisClass;
        }
        public void SetSuperClass(short superClass)
        {
            SuperClass = superClass;
        }
        public void SetInterfaces(List<short> interfaces)
        {
            Interfaces = interfaces ?? new List<short>();
        }

        #endregion

        #region Fields

        public List<CompileFieldInfo> Fields { get; private set; }

        public void AddField(CompileFieldInfo field)
        {
            Fields.Add(field);
        }

        #endregion
        #region Methods

        public List<CompileMethodInfo> Methods { get; private set; }

        public void AddMethod(CompileMethodInfo method)
        {
            Methods.Add(method);
        }

        #endregion
        #region Attributes

        public List<CompileAttribute> Attributes { get; private set; }

        public void AddAttribute(CompileAttribute attribute)
        {
            attribute.NameIndex = AddConstantUtf8(attribute.Name);

            Attributes.Add(attribute);
        }

        #endregion

        #region Output
        public byte[] GetBytes()
        {
            var program = new MemoryStream();
            var writer = new EndianBinaryWriter(EndianBitConverter.Big, program);
            
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

            writer.Flush();

            return program.ToArray();
        }
        private void WriteConstBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)ConstantPool.Count());

            foreach (var constant in ConstantPool)
            {
                writer.Write(constant.Tag);
                constant.Write(writer);
            }
        }
        private void WriteModiferBytes(EndianBinaryWriter writer)
        {
            var modifierValue = (short)(Modifiers.Aggregate<JavaModifier, short>(0, (current, modifier) => (short)(current | (short)modifier)) & 0x631);

            writer.Write(modifierValue);
        }
        private void WriteInterfaceBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)Interfaces.Count());

            foreach (var i in Interfaces)
            {
                writer.Write(i);
            }
        }
        private void WriteFieldBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)Fields.Count());

            foreach (var field in Fields)
            {
                field.Write(writer);
            }
        }
        private void WriteMethodBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)Methods.Count());

            foreach (var method in Methods)
            {
                method.Write(writer);
            }
        }
        private void WriteAttributeBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)Attributes.Count());

            foreach (var attribute in Attributes)
            {
                writer.Write(attribute.NameIndex);
                writer.Write(attribute.Length);
                
                attribute.Write(writer);
            }
        }

        #endregion
    }
}
