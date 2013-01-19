using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilation
{
    public class CompileManager
    {
        public CompileManager()
        {
            ConstantPool = new List<CompileConstant>();

            Fields = new List<CompileFieldInfo>();
            Methods = new List<CompileMethodInfo>();
            Attributes = new List<CompileAttribute>();

            nextConstantIndex = 1;
        }

        #region Constants
        private short nextConstantIndex;
        public List<CompileConstant> ConstantPool { get; private set; }

        public short AddConstantClass(string className)
        {
            var nameIndex = AddConstantUtf8(className);
            var classConst = ConstantPool.OfType<CompileConstantClass>().FirstOrDefault(x => x.NameIndex == nameIndex);

            if (classConst == null)
            {
                classConst = new CompileConstantClass { PoolIndex = nextConstantIndex++, NameIndex = nameIndex };

                ConstantPool.Add(classConst);
            }

            return classConst.PoolIndex;
        }
        public short AddConstantUtf8(string s)
        {
            var value = new JavaTextEncoding().GetBytes(s);
            var utf8Const = ConstantPool.OfType<CompileConstantUtf8>().FirstOrDefault(x => x.Value == value);

            if (utf8Const == null)
            {
                utf8Const = new CompileConstantUtf8 { PoolIndex = nextConstantIndex++, Value = value };

                ConstantPool.Add(utf8Const);
            }

            return utf8Const.PoolIndex;
        }
        public short AddConstantUtf8Type(Class type)
        {
            return AddConstantUtf8(ProcessTypeName(type));
        }

        public static string ProcessTypeName(Class type)
        {
            var name = "";

            /*TODO: for (var i = 0; i < type.ArrayLevels; i++)
            {
                name += "[";
            }*/

            switch (type.Name)
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
                    name += string.Format("L{0};", type.Name);
                    break;
            }

            return name;
        }
        public static string ProcessMethodDescriptor(Method method)
        {
            var descriptor = method.Parameters.Aggregate("(", (current, parameter) => current + ProcessTypeName(parameter.Type));

            descriptor += ")";

            descriptor += ProcessTypeName(method.ReturnType);

            return descriptor;
        }
        #endregion

        #region Modifiers

        public Modifier Modifiers { get; private set; }

        public void SetModifiers(Modifier modifiers)
        {
            Modifiers = modifiers;
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
            writer.Write(new byte[] { 0x00, 0x00, 0x00, 0x31 });
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

            var bytes = new byte[program.Length];
            var programArray = program.ToArray();

            Array.Copy(programArray, bytes, bytes.Length);

            return bytes;
        }
        private void WriteConstBytes(EndianBinaryWriter writer)
        {
            writer.Write((short)(ConstantPool.Count() + 1));

            foreach (var constant in ConstantPool)
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
