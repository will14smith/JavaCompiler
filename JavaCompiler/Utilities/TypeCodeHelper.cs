using System;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Utilities
{
    public static class TypeCodeHelper
    {
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

            return typecodeNames[(int) typeCode];
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
                    return new PlaceholderType {Name = "java.lang.Object"};
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
    }
}