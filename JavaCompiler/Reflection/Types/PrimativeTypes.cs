using System;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Utilities;

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

            throw new InvalidOperationException();
        }
        public static Type UnboxType(Type type)
        {
            if (type.Name == "java.lang.Character") return Char;
            if (type.Name == "java.lang.Byte") return Byte;
            if (type.Name == "java.lang.Short") return Short;
            if (type.Name == "java.lang.Integer") return Int;
            if (type.Name == "java.lang.Long") return Long;
            if (type.Name == "java.lang.Float") return Float;
            if (type.Name == "java.lang.Double") return Double;
            if (type.Name == "java.lang.Boolean") return Boolean;
            if (type.Name == "java.lang.Void") return Void;

            return type;
        }

        internal abstract class PrimativeType : Type
        {
            public abstract Item Box(ByteCodeGenerator generator, Item item);
            public abstract Item Box(ByteCodeGenerator generator, Item item, DefinedType destType);
            public abstract Item Unbox(ByteCodeGenerator generator, Item item);
        }

        #region Nested type: BooleanClass

        private class BooleanClass : PrimativeType
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

            public override Item Box(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }

            public override Item Box(ByteCodeGenerator generator, Item item, DefinedType destType)
            {
                throw new NotImplementedException();
            }

            public override Item Unbox(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Nested type: ByteClass

        private class ByteClass : PrimativeType
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

            public override Item Box(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }

            public override Item Box(ByteCodeGenerator generator, Item item, DefinedType destType)
            {
                throw new NotImplementedException();
            }

            public override Item Unbox(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Nested type: CharClass

        private class CharClass : PrimativeType
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

            public override Item Box(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }

            public override Item Box(ByteCodeGenerator generator, Item item, DefinedType destType)
            {
                throw new NotImplementedException();
            }

            public override Item Unbox(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Nested type: DoubleClass

        private class DoubleClass : PrimativeType
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

            public override Item Box(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }

            public override Item Box(ByteCodeGenerator generator, Item item, DefinedType destType)
            {
                throw new NotImplementedException();
            }

            public override Item Unbox(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Nested type: FloatClass

        private class FloatClass : PrimativeType
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

            public override Item Box(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }

            public override Item Box(ByteCodeGenerator generator, Item item, DefinedType destType)
            {
                throw new NotImplementedException();
            }

            public override Item Unbox(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Nested type: IntClass

        private class IntClass : PrimativeType
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
                if (c.Name == "java.lang.Object") return true;
                if (!c.Primitive) return false;

                if (c is ByteClass) return false;
                if (c is ShortClass) return false;
                if (c is BooleanClass) return false;
                if (c is CharClass) return false;

                return true;
            }

            public override Item Box(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }

            public override Item Box(ByteCodeGenerator generator, Item item, DefinedType destType)
            {
                if (TypeCodeHelper.Truncate(item.Type) != ItemTypeCode.Int) throw new InvalidOperationException();
                if (destType.Name != "java.lang.Integer") throw new InvalidOperationException();

                // do conversion
                var valueOf = destType.Methods.Single(x => x.Name == "valueOf" && x.Parameters.Count == 1 && x.Parameters.Single().Type == Int);

                item.Load();

                return new StaticItem(generator, valueOf).Invoke();
            }

            public override Item Unbox(ByteCodeGenerator generator, Item item)
            {
                if (item.Type.Name != "java.lang.Integer") throw new InvalidOperationException();

                var definedType = item.Type as DefinedType;

                var valueOf = definedType.Methods.Single(x => x.Name == "intValue" && x.Parameters.Count == 0);

                item.Load();

                return new MemberItem(generator, valueOf, valueOf.Modifiers.HasFlag(Modifier.Private)).Invoke();
            }
        }

        #endregion

        #region Nested type: LongClass

        private class LongClass : PrimativeType
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

            public override Item Box(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }

            public override Item Box(ByteCodeGenerator generator, Item item, DefinedType destType)
            {
                throw new NotImplementedException();
            }

            public override Item Unbox(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Nested type: ShortClass

        private class ShortClass : PrimativeType
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

            public override Item Box(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }

            public override Item Box(ByteCodeGenerator generator, Item item, DefinedType destType)
            {
                throw new NotImplementedException();
            }

            public override Item Unbox(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Nested type: VoidClass

        private class VoidClass : PrimativeType
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

            public override Item Box(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }

            public override Item Box(ByteCodeGenerator generator, Item item, DefinedType destType)
            {
                throw new NotImplementedException();
            }

            public override Item Unbox(ByteCodeGenerator generator, Item item)
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}