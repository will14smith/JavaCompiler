using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Utilities;
using Array = JavaCompiler.Reflection.Types.Array;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Reflection.Loaders
{
    public static class ClassLoader
    {
        public static Type Load(string path)
        {
            return Load(File.OpenRead(path));
        }

        public static Type Load(Stream stream)
        {
            var reader = new EndianBinaryReader(EndianBitConverter.Big, stream);

            int magic = reader.ReadInt32();

            short minorVersion = reader.ReadInt16();
            short majorVersion = reader.ReadInt16();

            CompileConstant[] constants = ReadConstants(reader);

            var modifiers = (ClassModifier)reader.ReadInt16();

            short thisClass = reader.ReadInt16();
            short superClass = reader.ReadInt16();

            IEnumerable<short> interfaces = ReadInterfaces(reader);
            IEnumerable<CompileFieldInfo> fields = ReadFields(reader, constants);
            IEnumerable<CompileMethodInfo> methods = ReadMethods(reader, constants);
            CompileAttribute[] attributes = ReadAttributes(reader, constants);

            var c = new Class
                        {
                            Name = GetClass(thisClass, constants).Name,
                            Modifiers = modifiers,
                            Super = (superClass == 0 ? null : GetClass(superClass, constants)) as Class
                        };

            c.Interfaces.AddRange(interfaces.Select(x => GetClass(x, constants)).OfType<Interface>());
            c.Fields.AddRange(fields.Select(x => GetField(c, x, constants)));

            List<Method> javaMethods = methods.Select(x => GetMethod(c, x, constants)).ToList();

            c.Methods.AddRange(javaMethods.Where(x => x.Name != "<init>"));
            c.Constructors.AddRange(javaMethods.Where(x => x.Name == "<init>").Select(x => (Constructor)x));

            return c;
        }

        private static CompileConstant[] ReadConstants(EndianBinaryReader reader)
        {
            short constantCount = reader.ReadInt16();
            var constants = new CompileConstant[constantCount];

            for (int i = 1; i < constantCount; i++)
            {
                var tag = (CompileConstants)reader.ReadByte();
                switch (tag)
                {
                    case CompileConstants.Class:
                        constants[i] = new CompileConstantClass().Read(reader);
                        break;
                    case CompileConstants.Fieldref:
                        constants[i] = new CompileConstantFieldref().Read(reader);
                        break;
                    case CompileConstants.Methodref:
                        constants[i] = new CompileConstantMethodref().Read(reader);
                        break;
                    case CompileConstants.InterfaceMethodref:
                        constants[i] = new CompileConstantInterfaceMethodref().Read(reader);
                        break;
                    case CompileConstants.String:
                        constants[i] = new CompileConstantString().Read(reader);
                        break;
                    case CompileConstants.Integer:
                        constants[i] = new CompileConstantInteger().Read(reader);
                        break;
                    case CompileConstants.Float:
                        constants[i] = new CompileConstantFloat().Read(reader);
                        break;
                    case CompileConstants.Long:
                        constants[i] = new CompileConstantLong().Read(reader);
                        i++; // The next slot is invalid
                        break;
                    case CompileConstants.Double:
                        constants[i] = new CompileConstantDouble().Read(reader);
                        i++; // The next slot is invalid
                        break;
                    case CompileConstants.NameAndType:
                        constants[i] = new CompileConstantNameAndType().Read(reader);
                        break;
                    case CompileConstants.Utf8:
                        constants[i] = new CompileConstantUtf8().Read(reader);
                        break;
                    case CompileConstants.MethodHandle:
                        constants[i] = new CompileConstantMethodHandle().Read(reader);
                        break;
                    case CompileConstants.MethodType:
                        constants[i] = new CompileConstantMethodType().Read(reader);
                        break;
                    case CompileConstants.InvokeDynamic:
                        constants[i] = new CompileConstantInvokeDynamic().Read(reader);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return constants;
        }

        private static IEnumerable<short> ReadInterfaces(EndianBinaryReader reader)
        {
            short interfaceCount = reader.ReadInt16();
            var interfaces = new short[interfaceCount];

            for (int i = 0; i < interfaceCount; i++)
            {
                interfaces[i] = reader.ReadInt16();
            }

            return interfaces;
        }

        private static IEnumerable<CompileFieldInfo> ReadFields(EndianBinaryReader reader, CompileConstant[] constants)
        {
            short fieldCount = reader.ReadInt16();
            var fields = new CompileFieldInfo[fieldCount];

            for (int i = 0; i < fieldCount; i++)
            {
                var field = new CompileFieldInfo();

                field.Modifiers = (Modifier)reader.ReadInt16();
                field.Name = reader.ReadInt16();
                field.Descriptor = reader.ReadInt16();

                field.Attributes.AddRange(ReadAttributes(reader, constants));

                fields[i] = field;
            }

            return fields;
        }

        private static IEnumerable<CompileMethodInfo> ReadMethods(EndianBinaryReader reader, CompileConstant[] constants)
        {
            short methodCount = reader.ReadInt16();
            var methods = new CompileMethodInfo[methodCount];

            for (int i = 0; i < methodCount; i++)
            {
                var method = new CompileMethodInfo();

                method.Modifiers = (Modifier)reader.ReadInt16();
                method.Name = reader.ReadInt16();
                method.Descriptor = reader.ReadInt16();

                method.Attributes.AddRange(ReadAttributes(reader, constants));

                methods[i] = method;
            }

            return methods;
        }

        private static CompileAttribute[] ReadAttributes(EndianBinaryReader reader, CompileConstant[] constants)
        {
            short attributeCount = reader.ReadInt16();
            var attributes = new CompileAttribute[attributeCount];

            for (int i = 0; i < attributeCount; i++)
            {
                attributes[i] = CompileAttribute.ReadAttribute(reader, constants);
            }

            return attributes;
        }

        public static Field GetField(Class c, CompileFieldInfo field, CompileConstant[] constants)
        {
            return new Field
                       {
                           DeclaringType = c,
                           Name = GetUtf8(field.Name, constants),
                           Modifiers = field.Modifiers,
                           ReturnType = GetType(field.Descriptor, constants),
                       };
        }

        public static Method GetMethod(Class c, CompileMethodInfo method, CompileConstant[] constants)
        {
            var m = new Method
                        {
                            DeclaringType = c,
                            Name = GetUtf8(method.Name, constants),
                            Modifiers = method.Modifiers,
                        };

            string methodDescriptor = GetUtf8(method.Descriptor, constants);
            Tuple<List<Type>, Type> methodTypes = GetMethodTypeFromDescriptor(methodDescriptor);

            m.Parameters.AddRange(methodTypes.Item1.Select(x => new Method.Parameter { Type = x }));
            m.ReturnType = methodTypes.Item2;

            return m;
        }

        private static Type GetType(short p, CompileConstant[] constants)
        {
            string descriptor = GetUtf8(p, constants);

            return GetTypeFromDescriptor(descriptor);
        }

        private static Type GetTypeFromDescriptor(string descriptor)
        {
            if (descriptor.Length == 1)
            {
                switch (descriptor)
                {
                    case "B":
                        return PrimativeTypes.Byte;
                    case "C":
                        return PrimativeTypes.Char;
                    case "D":
                        return PrimativeTypes.Double;
                    case "F":
                        return PrimativeTypes.Float;
                    case "I":
                        return PrimativeTypes.Int;
                    case "J":
                        return PrimativeTypes.Long;
                    case "S":
                        return PrimativeTypes.Short;
                    case "Z":
                        return PrimativeTypes.Boolean;
                    case "V":
                        return PrimativeTypes.Void;
                    default:
                        throw new NotImplementedException();
                }
            }

            int arrayDimensions = descriptor.TakeWhile(x => x == '[').Count();
            descriptor = new string(descriptor.SkipWhile(x => x == '[').ToArray());

            if (descriptor.Length == 1)
            {
                Type type = GetTypeFromDescriptor(descriptor);

                for (var i = 0; i < arrayDimensions; i++)
                {
                    type = new Array(type);
                }

                return type;
            }

            if (descriptor[0] != 'L') throw new ArgumentException();
            if (descriptor[descriptor.Length - 1] != ';') throw new ArgumentException();

            {
                Type type = new PlaceholderType
                               {
                                   Name = descriptor.Replace('/', '.').Substring(1, descriptor.Length - 2)
                               };

                for (var i = 0; i < arrayDimensions; i++)
                {
                    type = new Array(type);
                }

                return type;
            }
        }

        private static Tuple<List<Type>, Type> GetMethodTypeFromDescriptor(string descriptor)
        {
            int i = 0;
            if (descriptor[i++] != '(') throw new ArgumentException();

            var parameterTypes = new List<Type>();

            while (descriptor[i] != ')')
            {
                switch (descriptor[i++])
                {
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'F':
                    case 'I':
                    case 'J':
                    case 'S':
                    case 'Z':
                        parameterTypes.Add(GetTypeFromDescriptor(new string(new[] { descriptor[i - 1] })));
                        break;
                    case 'L':
                        {
                            string typeName = "";
                            while (descriptor[i] != ';')
                            {
                                typeName += descriptor[i++];
                            }
                            i++;

                            parameterTypes.Add(new PlaceholderType { Name = typeName.Replace('/', '.') });
                        }
                        break;
                    case '[':
                        {
                            int arrayDimensions = 1;
                            while (descriptor[i] == '[')
                            {
                                arrayDimensions++;
                                i++;
                            }

                            string typeName = "";

                            if (descriptor[i] == 'L')
                            {
                                while (descriptor[i] != ';')
                                {
                                    typeName += descriptor[i++];
                                }
                            }
                            else
                            {
                                typeName = GetTypeFromDescriptor(new string(new[] { descriptor[i] })).Name;
                            }
                            i++;

                            Type type = new PlaceholderType { Name = typeName.Replace('/', '.') };

                            for (var x = 0; x < arrayDimensions; x++)
                            {
                                type = new Array(type);
                            }

                            parameterTypes.Add(type);
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            if (descriptor[i++] != ')') throw new ArgumentException();

            Type returnType = GetTypeFromDescriptor(descriptor.Substring(i));

            return new Tuple<List<Type>, Type>(parameterTypes, returnType);
        }

        private static DefinedType GetClass(short index, CompileConstant[] constants)
        {
            CompileConstant constant = constants[index];

            var compileConstantClass = constant as CompileConstantClass;
            if (compileConstantClass != null)
            {
                return new PlaceholderType { Name = GetUtf8(compileConstantClass.NameIndex, constants).Replace('/', '.') };
            }

            throw new InvalidOperationException();
        }

        private static string GetUtf8(short index, CompileConstant[] constants)
        {
            CompileConstant constant = constants[index];

            var compileConstantUtf8 = constant as CompileConstantUtf8;
            if (compileConstantUtf8 != null)
            {
                return new string(new JavaTextEncoding().GetChars(compileConstantUtf8.Value));
            }

            throw new InvalidOperationException();
        }
    }
}