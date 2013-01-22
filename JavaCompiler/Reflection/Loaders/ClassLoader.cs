using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Utilities;
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

            var magic = reader.ReadInt32();

            var minorVersion = reader.ReadInt16();
            var majorVersion = reader.ReadInt16();

            var constants = ReadConstants(reader);

            var modifiers = (ClassModifier)reader.ReadInt16();

            var thisClass = reader.ReadInt16();
            var superClass = reader.ReadInt16();

            var interfaces = ReadInterfaces(reader);
            var fields = ReadFields(reader, constants);
            var methods = ReadMethods(reader, constants);
            var attributes = ReadAttributes(reader, constants);

            var c = new Class
            {
                Name = GetClass(thisClass, constants).Name,
                Modifiers = modifiers,

                Super = (superClass == 0 ? null : GetClass(superClass, constants)) as Class
            };

            c.Interfaces.AddRange(interfaces.Select(x => GetClass(x, constants)).OfType<Interface>());
            c.Fields.AddRange(fields.Select(x => GetField(c, x, constants)));
            c.Methods.AddRange(methods.Select(x => GetMethod(c, x, constants)));

            return c;
        }

        private static CompileConstant[] ReadConstants(EndianBinaryReader reader)
        {
            var constantCount = reader.ReadInt16();
            var constants = new CompileConstant[constantCount];

            for (var i = 1; i < constantCount; i++)
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
        private static short[] ReadInterfaces(EndianBinaryReader reader)
        {
            var interfaceCount = reader.ReadInt16();
            var interfaces = new short[interfaceCount];

            for (var i = 0; i < interfaceCount; i++)
            {
                interfaces[i] = reader.ReadInt16();
            }

            return interfaces;
        }
        private static CompileFieldInfo[] ReadFields(EndianBinaryReader reader, CompileConstant[] constants)
        {
            var fieldCount = reader.ReadInt16();
            var fields = new CompileFieldInfo[fieldCount];

            for (var i = 0; i < fieldCount; i++)
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
        private static CompileMethodInfo[] ReadMethods(EndianBinaryReader reader, CompileConstant[] constants)
        {
            var methodCount = reader.ReadInt16();
            var methods = new CompileMethodInfo[methodCount];

            for (var i = 0; i < methodCount; i++)
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
            var attributeCount = reader.ReadInt16();
            var attributes = new CompileAttribute[attributeCount];

            for (var i = 0; i < attributeCount; i++)
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

                Type = GetType(field.Descriptor, constants),
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

            var methodDescriptor = GetUtf8(method.Descriptor, constants);
            var methodTypes = GetMethodTypeFromDescriptor(methodDescriptor);

            m.Parameters.AddRange(methodTypes.Item1.Select(x => new Method.Parameter { Type = x }));
            m.ReturnType = methodTypes.Item2;

            return m;
        }

        private static Type GetType(short p, CompileConstant[] constants)
        {
            var descriptor = GetUtf8(p, constants);

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

            var arrayDimensions = descriptor.TakeWhile(x => x == '[').Count();
            descriptor = new string(descriptor.SkipWhile(x => x == '[').ToArray());

            if (descriptor.Length == 1)
            {
                var primType = GetTypeFromDescriptor(descriptor);

                return new Type { ArrayDimensions = arrayDimensions, Name = primType.Name };
            }

            if (descriptor[0] != 'L') throw new ArgumentException();
            if (descriptor[descriptor.Length - 1] != ';') throw new ArgumentException();

            return new PlaceholderType { ArrayDimensions = arrayDimensions, Name = descriptor.Substring(1, descriptor.Length - 2) };
        }
        private static Tuple<List<Type>, Type> GetMethodTypeFromDescriptor(string descriptor)
        {
            var i = 0;
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
                            var typeName = "";
                            while (descriptor[i] != ';')
                            {
                                typeName += descriptor[i++];
                            }
                            i++;

                            parameterTypes.Add(new PlaceholderType { Name = typeName });
                        }
                        break;
                    case '[':
                        {
                            var arrayDimensions = 1;
                            while (descriptor[i] == '[')
                            {
                                arrayDimensions++;
                                i++;
                            }

                            var typeName = "";

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

                            parameterTypes.Add(new PlaceholderType { Name = typeName, ArrayDimensions = arrayDimensions });
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                }

            }

            if (descriptor[i++] != ')') throw new ArgumentException();

            var returnType = GetTypeFromDescriptor(descriptor.Substring(i));

            return new Tuple<List<Type>, Type>(parameterTypes, returnType);
        }

        private static DefinedType GetClass(short index, CompileConstant[] constants)
        {
            var constant = constants[index];

            var compileConstantClass = constant as CompileConstantClass;
            if (compileConstantClass != null)
            {
                return new PlaceholderType { Name = GetUtf8(compileConstantClass.NameIndex, constants) };
            }

            throw new InvalidOperationException();
        }
        private static string GetUtf8(short index, CompileConstant[] constants)
        {
            var constant = constants[index];

            var compileConstantUtf8 = constant as CompileConstantUtf8;
            if (compileConstantUtf8 != null)
            {
                return new string(new JavaTextEncoding().GetChars(compileConstantUtf8.Value));
            }

            throw new InvalidOperationException();
        }
    }
}
