using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Types;

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
            if(type.Primitive)
            {
                return PrimativeTypes.TypeCode(type);
            }

            return ItemTypeCode.Object;
        }

        public static string Name(ItemTypeCode typeCode)
        {
            var typecodeNames = new [] { "int", "long", "float", "double", "object", "byte", "char", "short", "void", "oops" };

            return typecodeNames[(int) typeCode];
        }
    }
}
