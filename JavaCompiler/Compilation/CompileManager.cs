using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Types;
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

            Imports = new List<Package>();

            nextConstantIndex = 1;
        }

        #region Constants

        private short nextConstantIndex;
        public List<CompileConstant> ConstantPool { get; private set; }

        public short AddConstantFieldref(Field field)
        {
            if (field == null) return 0;

            short classIndex = AddConstantClass(field.DeclaringType);
            short nameAndTypeIndex = AddConstantNameAndType(field.Name, field);

            CompileConstantFieldref fieldConst =
                ConstantPool.OfType<CompileConstantFieldref>().FirstOrDefault(
                    x => x.ClassIndex == classIndex && x.NameAndTypeIndex == nameAndTypeIndex);

            if (fieldConst == null)
            {
                fieldConst = new CompileConstantFieldref
                                 {
                                     PoolIndex = nextConstantIndex++,
                                     ClassIndex = classIndex,
                                     NameAndTypeIndex = nameAndTypeIndex
                                 };

                ConstantPool.Add(fieldConst);
            }

            return fieldConst.PoolIndex;
        }

        public short AddConstantMethodref(Method method)
        {
            if (method == null) return 0;

            short classIndex = AddConstantClass(method.DeclaringType);
            short nameAndTypeIndex = AddConstantNameAndType(method.Name, method);

            CompileConstantMethodref methodConst =
                ConstantPool.OfType<CompileConstantMethodref>().FirstOrDefault(
                    x => x.ClassIndex == classIndex && x.NameAndTypeIndex == nameAndTypeIndex);

            if (methodConst == null)
            {
                methodConst = new CompileConstantMethodref
                                  {
                                      PoolIndex = nextConstantIndex++,
                                      ClassIndex = classIndex,
                                      NameAndTypeIndex = nameAndTypeIndex
                                  };

                ConstantPool.Add(methodConst);
            }

            return methodConst.PoolIndex;
        }

        public short AddConstantInterfaceMethodref(Method method)
        {
            if (method == null) return 0;

            short classIndex = AddConstantClass(method.DeclaringType);
            short nameAndTypeIndex = AddConstantNameAndType(method.Name, method);

            CompileConstantInterfaceMethodref methodConst =
                ConstantPool.OfType<CompileConstantInterfaceMethodref>().FirstOrDefault(
                    x => x.ClassIndex == classIndex && x.NameAndTypeIndex == nameAndTypeIndex);

            if (methodConst == null)
            {
                methodConst = new CompileConstantInterfaceMethodref
                                  {
                                      PoolIndex = nextConstantIndex++,
                                      ClassIndex = classIndex,
                                      NameAndTypeIndex = nameAndTypeIndex
                                  };

                ConstantPool.Add(methodConst);
            }

            return methodConst.PoolIndex;
        }

        public short AddConstantNameAndType(string name, IMember type)
        {
            if (name == null || type == null) return 0;

            short nameIndex = AddConstantUtf8(name);
            short typeIndex = AddConstantUtf8(type.GetDescriptor());
            CompileConstantNameAndType nameAndTypeConst =
                ConstantPool.OfType<CompileConstantNameAndType>().FirstOrDefault(
                    x => x.NameIndex == nameIndex && x.DescriptorIndex == typeIndex);

            if (nameAndTypeConst == null)
            {
                nameAndTypeConst = new CompileConstantNameAndType
                                       {
                                           PoolIndex = nextConstantIndex++,
                                           NameIndex = nameIndex,
                                           DescriptorIndex = typeIndex
                                       };

                ConstantPool.Add(nameAndTypeConst);
            }

            return nameAndTypeConst.PoolIndex;
        }

        public short AddConstantClass(DefinedType c)
        {
            if (c == null) return 0;

            short nameIndex = AddConstantUtf8(c.Name);
            CompileConstantClass classConst =
                ConstantPool.OfType<CompileConstantClass>().FirstOrDefault(x => x.NameIndex == nameIndex);

            if (classConst == null)
            {
                classConst = new CompileConstantClass {PoolIndex = nextConstantIndex++, NameIndex = nameIndex};

                ConstantPool.Add(classConst);
            }

            return classConst.PoolIndex;
        }

        public short AddConstantInteger(int value)
        {
            CompileConstantInteger intConst =
                ConstantPool.OfType<CompileConstantInteger>().FirstOrDefault(x => x.Value == value);

            if (intConst == null)
            {
                intConst = new CompileConstantInteger {PoolIndex = nextConstantIndex++, Value = value};

                ConstantPool.Add(intConst);
            }

            return intConst.PoolIndex;
        }

        public short AddConstantFloat(float value)
        {
            CompileConstantFloat floatConst =
                ConstantPool.OfType<CompileConstantFloat>().FirstOrDefault(x => x.Value == value);

            if (floatConst == null)
            {
                floatConst = new CompileConstantFloat {PoolIndex = nextConstantIndex++, Value = value};

                ConstantPool.Add(floatConst);
            }

            return floatConst.PoolIndex;
        }

        public short AddConstantLong(long value)
        {
            CompileConstantLong longConst =
                ConstantPool.OfType<CompileConstantLong>().FirstOrDefault(x => x.Value == value);

            if (longConst == null)
            {
                longConst = new CompileConstantLong {PoolIndex = nextConstantIndex++, Value = value};

                ConstantPool.Add(longConst);
            }

            return longConst.PoolIndex;
        }

        public short AddConstantDouble(double value)
        {
            CompileConstantDouble doubleConst =
                ConstantPool.OfType<CompileConstantDouble>().FirstOrDefault(x => x.Value == value);

            if (doubleConst == null)
            {
                doubleConst = new CompileConstantDouble {PoolIndex = nextConstantIndex++, Value = value};

                ConstantPool.Add(doubleConst);
            }

            return doubleConst.PoolIndex;
        }

        public short AddConstantString(string value)
        {
            short utfIndex = AddConstantUtf8(value);

            CompileConstantString stringConst =
                ConstantPool.OfType<CompileConstantString>().FirstOrDefault(x => x.StringIndex == utfIndex);

            if (stringConst == null)
            {
                stringConst = new CompileConstantString {PoolIndex = nextConstantIndex++, StringIndex = utfIndex};

                ConstantPool.Add(stringConst);
            }

            return stringConst.PoolIndex;
        }

        public short AddConstantUtf8(string s)
        {
            byte[] value = new JavaTextEncoding().GetBytes(s);
            CompileConstantUtf8 utf8Const =
                ConstantPool.OfType<CompileConstantUtf8>().FirstOrDefault(x => x.Value.SequenceEqual(value));

            if (utf8Const == null)
            {
                utf8Const = new CompileConstantUtf8 {PoolIndex = nextConstantIndex++, Value = value};

                ConstantPool.Add(utf8Const);
            }

            return utf8Const.PoolIndex;
        }

        #endregion

        #region Modifiers

        public ClassModifier Modifiers { get; private set; }

        public void SetModifiers(ClassModifier modifiers)
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
            writer.Write(new byte[] {0xCA, 0xFE, 0xBA, 0xBE});
            // version (minor, major)
            writer.Write(new byte[] {0x00, 0x00, 0x00, 0x33});
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
            byte[] programArray = program.ToArray();

            Array.Copy(programArray, bytes, bytes.Length);

            return bytes;
        }

        private void WriteConstBytes(EndianBinaryWriter writer)
        {
            writer.Write((short) (ConstantPool.Count() + 1));

            foreach (CompileConstant constant in ConstantPool)
            {
                writer.Write(constant.Tag);
                constant.Write(writer);
            }
        }

        private void WriteModiferBytes(EndianBinaryWriter writer)
        {
            var modifierValue = (short) ((int) Modifiers & 0x631);

            writer.Write(modifierValue);
        }

        private void WriteInterfaceBytes(EndianBinaryWriter writer)
        {
            writer.Write((short) Interfaces.Count());

            foreach (short i in Interfaces)
            {
                writer.Write(i);
            }
        }

        private void WriteFieldBytes(EndianBinaryWriter writer)
        {
            writer.Write((short) Fields.Count());

            foreach (CompileFieldInfo field in Fields)
            {
                field.Write(writer);
            }
        }

        private void WriteMethodBytes(EndianBinaryWriter writer)
        {
            writer.Write((short) Methods.Count());

            foreach (CompileMethodInfo method in Methods)
            {
                method.Write(writer);
            }
        }

        private void WriteAttributeBytes(EndianBinaryWriter writer)
        {
            writer.Write((short) Attributes.Count());

            foreach (CompileAttribute attribute in Attributes)
            {
                writer.Write(attribute.NameIndex);
                writer.Write(attribute.Length);

                attribute.Write(writer);
            }
        }

        #endregion

        public List<Package> Imports { get; private set; }
    }
}