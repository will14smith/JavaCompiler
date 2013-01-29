using System;
using JavaCompiler.Compilers.Items;

namespace JavaCompiler.Reflection.Types
{
    public static class PrimativeTypes
    {
        public static Type Byte = new ByteClass();
        public static Type Short = new ShortClass();
        public static Type Int = new IntClass();
        public static Type Long = new LongClass();
        public static Type Float = new FloatClass();
        public static Type Double = new DoubleClass();
        public static Type Boolean = new BooleanClass();
        public static Type Char = new CharClass();

        public static Type Void = new VoidClass();
        public static Type CompileTime = new CompileTimeClass();

        internal static ItemTypeCode TypeCode(Type type)
        {
            if (type is BooleanClass)
            {
                return ItemTypeCode.Byte;
            } 
            if (type is ByteClass)
            {
                return ItemTypeCode.Byte;
            }
            if (type is ShortClass)
            {
                return ItemTypeCode.Short;
            }
            if (type is IntClass)
            {
                return ItemTypeCode.Int;
            }
            if (type is LongClass)
            {
                return ItemTypeCode.Long;
            }
            if (type is FloatClass)
            {
                return ItemTypeCode.Float;
            }
            if (type is DoubleClass)
            {
                return ItemTypeCode.Double;
            }
            if (type is CharClass)
            {
                return ItemTypeCode.Char;
            }

            if (type is VoidClass)
            {
                return ItemTypeCode.Void;
            }

            throw new NotImplementedException();
        }

        #region Nested type: BooleanClass

        private class BooleanClass : Type
        {
            public override string Name
            {
                get { return "boolean"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override string GetDescriptor(bool b)
            {
                return "Z";
            }

            public override bool IsAssignableTo(Type c)
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

        #endregion

        #region Nested type: ByteClass

        private class ByteClass : Type
        {
            public override string Name
            {
                get { return "byte"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override string GetDescriptor(bool b)
            {
                return "B";
            }

            public override bool IsAssignableTo(Type c)
            {
                //TODO: Byte
                if (!c.Primitive) return false;

                if (c is BooleanClass) return false;
                if (c is CharClass) return false;

                return true;
            }
        }

        #endregion

        #region Nested type: CharClass

        private class CharClass : Type
        {
            public override string Name
            {
                get { return "char"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override string GetDescriptor(bool b)
            {
                return "C";
            }

            public override bool IsAssignableTo(Type c)
            {
                //TODO: Char
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is ShortClass) return false;
                if (c is BooleanClass) return false;

                return true;
            }
        }

        #endregion

        #region Nested type: CompileTimeClass

        internal class CompileTimeClass : Type
        {
            public override string Name
            {
                get { return "COMPILE TIME"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override bool IsAssignableTo(Type c)
            {
                return false;
            }
        }

        #endregion

        #region Nested type: DoubleClass

        private class DoubleClass : Type
        {
            public override string Name
            {
                get { return "double"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override string GetDescriptor(bool b)
            {
                return "D";
            }

            public override bool IsAssignableTo(Type c)
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

        #endregion

        #region Nested type: FloatClass

        private class FloatClass : Type
        {
            public override string Name
            {
                get { return "float"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override string GetDescriptor(bool b)
            {
                return "F";
            }

            public override bool IsAssignableTo(Type c)
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

        #endregion

        #region Nested type: IntClass

        private class IntClass : Type
        {
            public override string Name
            {
                get { return "int"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override string GetDescriptor(bool b)
            {
                return "I";
            }

            public override bool IsAssignableTo(Type c)
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

        #endregion

        #region Nested type: LongClass

        private class LongClass : Type
        {
            public override string Name
            {
                get { return "long"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override string GetDescriptor(bool b)
            {
                return "J";
            }

            public override bool IsAssignableTo(Type c)
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

        #endregion

        #region Nested type: ShortClass

        private class ShortClass : Type
        {
            public override string Name
            {
                get { return "short"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override string GetDescriptor(bool b)
            {
                return "S";
            }

            public override bool IsAssignableTo(Type c)
            {
                //TODO: Short
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is BooleanClass) return false;
                if (c is CharClass) return false;

                return true;
            }
        }

        #endregion

        #region Nested type: VoidClass

        private class VoidClass : Type
        {
            public override string Name
            {
                get { return "void"; }
            }

            public override bool Primitive
            {
                get { return true; }
            }

            public override string GetDescriptor(bool b)
            {
                return "V";
            }

            public override bool IsAssignableTo(Type c)
            {
                return false;
            }
        }

        #endregion
    }
}