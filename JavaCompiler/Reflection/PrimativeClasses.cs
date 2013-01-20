namespace JavaCompiler.Reflection
{
    public static class PrimativeClasses
    {
        public static Class Byte = new ByteClass();
        public static Class Short = new ShortClass();
        public static Class Int = new IntClass();
        public static Class Long = new LongClass();
        public static Class Float = new FloatClass();
        public static Class Double = new DoubleClass();
        public static Class Boolean = new BooleanClass();
        public static Class Char = new CharClass();

        public static Class Void = new VoidClass();
        public static Class CompileTime = new CompileTimeClass();

        private class ByteClass : Class
        {
            public override string Name { get { return "byte"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                //TODO: Byte
                if (!c.Primitive) return false;

                if (c is BooleanClass) return false;
                if (c is CharClass) return false;

                return true;
            }
        }
        private class ShortClass : Class
        {
            public override string Name { get { return "short"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                //TODO: Short
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is BooleanClass) return false;
                if (c is CharClass) return false;

                return true;
            }
        }
        private class IntClass : Class
        {
            public override string Name { get { return "int"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                //TODO: Integer
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is ShortClass) return false;
                if (c is BooleanClass) return false;
                if (c is CharClass) return false;

                return true;
            }
        }
        private class LongClass : Class
        {
            public override string Name { get { return "long"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                //TODO: Long
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is ShortClass) return false;
                if (c is IntClass) return false;
                if (c is BooleanClass) return false;
                if (c is CharClass) return false;

                return true;
            }
        }
        private class FloatClass : Class
        {
            public override string Name { get { return "float"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                //TODO: Float
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is ShortClass) return false;
                if (c is IntClass) return false;
                if (c is LongClass) return false;
                if (c is BooleanClass) return false;
                if (c is CharClass) return false;
                
                return true;
            }
        }
        private class DoubleClass : Class
        {
            public override string Name { get { return "double"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                //TODO: Double
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is ShortClass) return false;
                if (c is IntClass) return false;
                if (c is LongClass) return false;
                if (c is FloatClass) return false;
                if (c is BooleanClass) return false;
                if (c is CharClass) return false;

                return true;
            }
        }
        private class BooleanClass : Class
        {
            public override string Name { get { return "boolean"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                //TODO: Boolean
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is ShortClass) return false;
                if (c is IntClass) return false;
                if (c is LongClass) return false;
                if (c is FloatClass) return false;
                if (c is DoubleClass) return false;
                if (c is CharClass) return false;
                
                return true;
            }
        }
        private class CharClass : Class
        {
            public override string Name { get { return "char"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                //TODO: Char
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is ShortClass) return false;
                if (c is BooleanClass) return false;

                return true;
            }
        }

        private class VoidClass : Class
        {
            public override string Name { get { return "void"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                return false;
            }
        }
        internal class CompileTimeClass : Class
        {
            public override string Name { get { return "COMPILE TIME"; } }
            public override bool Primitive { get { return true; } }

            public override bool IsAssignableTo(Class c)
            {
                return false;
            }
        }
    }
}
