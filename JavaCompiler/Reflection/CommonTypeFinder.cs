namespace JavaCompiler.Reflection
{
    public static class CommonTypeFinder
    {
        public static Class FindCommonType(this Class c1, Class c2)
        {
            if (c1 is PrimativeClasses.CompileTimeClass) return PrimativeClasses.CompileTime;
            if (c2 is PrimativeClasses.CompileTimeClass) return PrimativeClasses.CompileTime;

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
