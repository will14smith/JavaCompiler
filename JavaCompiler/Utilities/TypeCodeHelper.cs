using System;
using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Types;
using Array = JavaCompiler.Reflection.Types.Array;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Utilities
{
    public static class TypeCodeHelper
    {
        public static ItemTypeCode Truncate(Type type)
        {
            return Truncate(TypeCode(type));
        }
        public static ItemTypeCode Truncate(ItemTypeCode tc)
        {
            switch (tc)
            {
                case ItemTypeCode.Byte:
                case ItemTypeCode.Short:
                case ItemTypeCode.Char:
                    return ItemTypeCode.Int;
                default:
                    return tc;
            }
        }

        public static int Width(Type type)
        {
            return Width(TypeCode(type));
        }
        public static int Width(ItemTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ItemTypeCode.Long:
                case ItemTypeCode.Double:
                    return 2;
                case ItemTypeCode.Void:
                    return 0;
                default:
                    return 1;
            }
        }

        public static ItemTypeCode TypeCode(Type type)
        {
            if (type.Primitive)
            {
                return PrimativeTypes.TypeCode(type);
            }

            return ItemTypeCode.Object;
        }

        public static string Name(ItemTypeCode typeCode)
        {
            var typecodeNames = new[]
                                    {
                                        "int", "long", "float", "double", "object", "byte", "char", "short", "void", "oops"
                                    };

            return typecodeNames[(int)typeCode];
        }

        public static Type Type(ItemTypeCode typeCode)
        {
            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    return PrimativeTypes.Int;
                case ItemTypeCode.Long:
                    return PrimativeTypes.Long;
                case ItemTypeCode.Float:
                    return PrimativeTypes.Float;
                case ItemTypeCode.Double:
                    return PrimativeTypes.Double;
                case ItemTypeCode.Object:
                    return BuiltinTypes.Object;
                case ItemTypeCode.Byte:
                    return PrimativeTypes.Byte;
                case ItemTypeCode.Char:
                    return PrimativeTypes.Char;
                case ItemTypeCode.Short:
                    return PrimativeTypes.Short;
                case ItemTypeCode.Void:
                    return PrimativeTypes.Void;
                default:
                    throw new NotImplementedException();
            }
        }

        public static Item StackItem(ByteCodeGenerator generator, Type type)
        {
            if (type.Primitive)
            {
                if (TypeCode(type) == ItemTypeCode.Void)
                {
                    return new VoidItem(generator);
                }
            }

            return new StackItem(generator, type);
        }

        public static int Width(IEnumerable<Type> typeCode)
        {
            return typeCode.Sum(x => Width(x));
        }

        public static byte ArrayCode(Type elemType)
        {
            if (elemType == PrimativeTypes.Byte) return 8;
            if (elemType == PrimativeTypes.Boolean) return 4;
            if (elemType == PrimativeTypes.Short) return 9;
            if (elemType == PrimativeTypes.Char) return 5;
            if (elemType == PrimativeTypes.Int) return 10;
            if (elemType == PrimativeTypes.Long) return 11;
            if (elemType == PrimativeTypes.Float) return 6;
            if (elemType == PrimativeTypes.Double) return 7;
            if (elemType is Array) return 1;
            if (elemType is Class) return 0;

            throw new NotImplementedException();
        }
    }
}