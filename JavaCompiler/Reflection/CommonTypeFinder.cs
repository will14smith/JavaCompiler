using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Reflection
{
    public static class CommonTypeFinder
    {
        public static Type FindCommonType(this Type c1, Type c2)
        {
            if (c1 is PrimativeTypes.CompileTimeClass) return PrimativeTypes.CompileTime;
            if (c2 is PrimativeTypes.CompileTimeClass) return PrimativeTypes.CompileTime;

            if (!(c1.IsAssignableTo(c2) || c2.CanAssignTo(c1)))
            {
                // No EASY common type found
                // will have to search superclasses
                return null;
            }

            if (c1.IsAssignableTo(c2))
            {
                return c2;
            }
            if (c2.IsAssignableTo(c1))
            {
                return c1;
            }

            return null;
        }
    }
}