using JavaCompiler.Reflection.Loaders;

namespace JavaCompiler.Reflection.Types
{
    public static class BuiltinTypes
    {
        // boxed types
        private static readonly Class characterType = (Class)ClassLocator.Find("java.lang.Character");
        private static readonly Class byteType = (Class)ClassLocator.Find("java.lang.Byte");
        private static readonly Class shortType = (Class)ClassLocator.Find("java.lang.Short");
        private static readonly Class integerType = (Class)ClassLocator.Find("java.lang.Integer");
        private static readonly Class longType = (Class)ClassLocator.Find("java.lang.Long");
        private static readonly Class floatType = (Class)ClassLocator.Find("java.lang.Float");
        private static readonly Class doubleType = (Class)ClassLocator.Find("java.lang.Double");
        private static readonly Class booleanType = (Class)ClassLocator.Find("java.lang.Boolean");
        private static readonly Class voidType = (Class)ClassLocator.Find("java.lang.Void");

        // core types
        private static readonly Class objectType = (Class)ClassLocator.Find("java.lang.Object");
        private static readonly Class stringType = (Class)ClassLocator.Find("java.lang.String");
        private static readonly Class stringBuilderType = (Class)ClassLocator.Find("java.lang.StringBuilder");

        // magic types
        private static readonly Class thisType = new ThisType();
        private static readonly Class superType = new SuperType();
        private static readonly Class _null = new NullType();

        public static Class Character { get { return characterType; } }
        public static Class Byte { get { return byteType; } }
        public static Class Short { get { return shortType; } }
        public static Class Integer { get { return integerType; } }
        public static Class Long { get { return longType; } }
        public static Class Float { get { return floatType; } }
        public static Class Double { get { return doubleType; } }
        public static Class Boolean { get { return booleanType; } }
        public static Class Void { get { return voidType; } }

        public static Class Object { get { return objectType; } }
        public static Class String { get { return stringType; } }
        public static Class StringBuilder { get { return stringBuilderType; } }

        public static Class This { get { return thisType; } }
        public static Class Super { get { return superType; } }

        public static Class Null { get { return _null; } }

        private class ThisType : Class
        {
        }
        private class SuperType : Class
        {
        }
        private class NullType : Class
        {
        }
    }
}
