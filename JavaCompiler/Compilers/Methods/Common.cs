using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;

namespace JavaCompiler.Compilers.Methods
{
    public static class Common
    {
        #region Casting
        public static void Cast(Class stackType, Class requiredType, ByteCodeGenerator generator, bool force = false)
        {
            if (stackType == requiredType) return;

            if (!(force || stackType.IsAssignableTo(requiredType)))
            {
                throw new InvalidCastException();
            }

            // figure out the cast...
            if (stackType.Primitive && requiredType.Primitive)
            {
                CastPrimative(stackType, requiredType, generator);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private static void CastPrimative(Class stackType, Class requiredType, ByteCodeGenerator generator)
        {
            if (requiredType == PrimativeClasses.Byte)
            {
                CastByte(stackType, generator);
            }
            else if (requiredType == PrimativeClasses.Short)
            {
                CastShort(stackType, generator);
            }
            else if (requiredType == PrimativeClasses.Int)
            {
                CastInt(stackType, generator);
            }
            else if (requiredType == PrimativeClasses.Long)
            {
                CastLong(stackType, generator);
            }
            else if (requiredType == PrimativeClasses.Float)
            {
                CastFloat(stackType, generator);
            }
            else if (requiredType == PrimativeClasses.Double)
            {
                CastDouble(stackType, generator);
            }
            else if (requiredType == PrimativeClasses.Char)
            {
                CastChar(stackType, generator);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private static void CastByte(Class stackType, ByteCodeGenerator generator)
        {
            if (stackType == PrimativeClasses.Byte)
            {
            }
            if (stackType == PrimativeClasses.Short)
            {
                generator.Emit(OpCodes.i2b);
            }
            else if (stackType == PrimativeClasses.Int)
            {
                generator.Emit(OpCodes.i2b);
            }
            else if (stackType == PrimativeClasses.Long)
            {
                generator.Emit(OpCodes.l2i);
                generator.Emit(OpCodes.i2b);
            }
            else if (stackType == PrimativeClasses.Float)
            {
                generator.Emit(OpCodes.f2i);
                generator.Emit(OpCodes.i2b);
            }
            else if (stackType == PrimativeClasses.Double)
            {
                generator.Emit(OpCodes.d2i);
                generator.Emit(OpCodes.i2b);
            }
            else if (stackType == PrimativeClasses.Char)
            {
                generator.Emit(OpCodes.i2b);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private static void CastShort(Class stackType, ByteCodeGenerator generator)
        {
            if (stackType == PrimativeClasses.Byte)
            {
                generator.Emit(OpCodes.i2s);
            }
            else if (stackType == PrimativeClasses.Short)
            {
            }
            else if (stackType == PrimativeClasses.Int)
            {
                generator.Emit(OpCodes.i2s);
            }
            else if (stackType == PrimativeClasses.Long)
            {
                generator.Emit(OpCodes.l2i);
                generator.Emit(OpCodes.i2s);
            }
            else if (stackType == PrimativeClasses.Float)
            {
                generator.Emit(OpCodes.f2i);
                generator.Emit(OpCodes.i2s);
            }
            else if (stackType == PrimativeClasses.Double)
            {
                generator.Emit(OpCodes.d2i);
                generator.Emit(OpCodes.i2s);
            }
            else if (stackType == PrimativeClasses.Char)
            {
                generator.Emit(OpCodes.i2s);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private static void CastInt(Class stackType, ByteCodeGenerator generator)
        {
            if (stackType == PrimativeClasses.Byte)
            {
            }
            else if (stackType == PrimativeClasses.Short)
            {
            }
            else if (stackType == PrimativeClasses.Int)
            {
            }
            else if (stackType == PrimativeClasses.Long)
            {
                generator.Emit(OpCodes.l2i);
            }
            else if (stackType == PrimativeClasses.Float)
            {
                generator.Emit(OpCodes.f2i);
            }
            else if (stackType == PrimativeClasses.Double)
            {
                generator.Emit(OpCodes.d2i);
            }
            else if (stackType == PrimativeClasses.Char)
            {
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private static void CastLong(Class stackType, ByteCodeGenerator generator)
        {
            if (stackType == PrimativeClasses.Byte)
            {
                generator.Emit(OpCodes.i2l);
            }
            else if (stackType == PrimativeClasses.Short)
            {
                generator.Emit(OpCodes.i2l);
            }
            else if (stackType == PrimativeClasses.Int)
            {
                generator.Emit(OpCodes.i2l);
            }
            else if (stackType == PrimativeClasses.Long)
            {
            }
            else if (stackType == PrimativeClasses.Float)
            {
                generator.Emit(OpCodes.f2l);
            }
            else if (stackType == PrimativeClasses.Double)
            {
                generator.Emit(OpCodes.d2l);
            }
            else if (stackType == PrimativeClasses.Char)
            {
                generator.Emit(OpCodes.i2l);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private static void CastFloat(Class stackType, ByteCodeGenerator generator)
        {
            if (stackType == PrimativeClasses.Byte)
            {
                generator.Emit(OpCodes.i2f);
            }
            else if (stackType == PrimativeClasses.Short)
            {
                generator.Emit(OpCodes.i2f);
            }
            else if (stackType == PrimativeClasses.Int)
            {
                generator.Emit(OpCodes.i2f);
            }
            else if (stackType == PrimativeClasses.Long)
            {
                generator.Emit(OpCodes.l2f);
            }
            else if (stackType == PrimativeClasses.Float)
            {
            }
            else if (stackType == PrimativeClasses.Double)
            {
                generator.Emit(OpCodes.d2f);
            }
            else if (stackType == PrimativeClasses.Char)
            {
                generator.Emit(OpCodes.i2f);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private static void CastDouble(Class stackType, ByteCodeGenerator generator)
        {
            if (stackType == PrimativeClasses.Byte)
            {
                generator.Emit(OpCodes.i2d);
            }
            else if (stackType == PrimativeClasses.Short)
            {
                generator.Emit(OpCodes.i2d);
            }
            else if (stackType == PrimativeClasses.Int)
            {
                generator.Emit(OpCodes.i2d);
            }
            else if (stackType == PrimativeClasses.Long)
            {
                generator.Emit(OpCodes.l2d);
            }
            else if (stackType == PrimativeClasses.Float)
            {
                generator.Emit(OpCodes.f2d);
            }
            else if (stackType == PrimativeClasses.Double)
            {
            }
            else if (stackType == PrimativeClasses.Char)
            {
                generator.Emit(OpCodes.i2d);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private static void CastChar(Class stackType, ByteCodeGenerator generator)
        {
            if (stackType == PrimativeClasses.Byte)
            {
                generator.Emit(OpCodes.i2c);
            }
            if (stackType == PrimativeClasses.Short)
            {
                generator.Emit(OpCodes.i2c);
            }
            else if (stackType == PrimativeClasses.Int)
            {
                generator.Emit(OpCodes.i2c);
            }
            else if (stackType == PrimativeClasses.Long)
            {
                generator.Emit(OpCodes.l2i);
                generator.Emit(OpCodes.i2c);
            }
            else if (stackType == PrimativeClasses.Float)
            {
                generator.Emit(OpCodes.f2i);
                generator.Emit(OpCodes.i2c);
            }
            else if (stackType == PrimativeClasses.Double)
            {
                generator.Emit(OpCodes.d2i);
                generator.Emit(OpCodes.i2c);
            }
            else if (stackType == PrimativeClasses.Char)
            {
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Store
        public static void StorePrimative(Variable variable, ByteCodeGenerator generator)
        {
            if (variable.Type == PrimativeClasses.Byte)
            {
                StoreInt(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Short)
            {
                StoreInt(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Int)
            {
                StoreInt(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Long)
            {
                StoreLong(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Float)
            {
                StoreFloat(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Double)
            {
                StoreDouble(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Boolean)
            {
                StoreInt(variable, generator); //TODO Check!
            }
            else if (variable.Type == PrimativeClasses.Char)
            {
                StoreInt(variable, generator);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static void StoreInt(Variable variable, ByteCodeGenerator generator)
        {
            switch (variable.Index)
            {
                case 0:
                    generator.Emit(OpCodes.istore_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.istore_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.istore_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.istore_3);
                    break;
                default:
                    generator.Emit(OpCodes.istore, variable.Index);
                    break;

            }
        }
        public static void StoreLong(Variable variable, ByteCodeGenerator generator)
        {
            switch (variable.Index)
            {
                case 0:
                    generator.Emit(OpCodes.lstore_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.lstore_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.lstore_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.lstore_3);
                    break;
                default:
                    generator.Emit(OpCodes.lstore, variable.Index);
                    break;

            }
        }
        public static void StoreFloat(Variable variable, ByteCodeGenerator generator)
        {
            switch (variable.Index)
            {
                case 0:
                    generator.Emit(OpCodes.fstore_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.fstore_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.fstore_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.fstore_3);
                    break;
                default:
                    generator.Emit(OpCodes.fstore, variable.Index);
                    break;

            }
        }
        public static void StoreDouble(Variable variable, ByteCodeGenerator generator)
        {
            switch (variable.Index)
            {
                case 0:
                    generator.Emit(OpCodes.dstore_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.dstore_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.dstore_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.dstore_3);
                    break;
                default:
                    generator.Emit(OpCodes.dstore, variable.Index);
                    break;

            }
        }
        #endregion

        #region Load
        public static void LoadPrimative(Variable variable, ByteCodeGenerator generator)
        {
            if (variable.Type == PrimativeClasses.Byte)
            {
                LoadInt(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Short)
            {
                LoadInt(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Int)
            {
                LoadInt(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Long)
            {
                LoadLong(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Float)
            {
                LoadFloat(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Double)
            {
                LoadDouble(variable, generator);
            }
            else if (variable.Type == PrimativeClasses.Boolean)
            {
                LoadInt(variable, generator); //TODO Check!
            }
            else if (variable.Type == PrimativeClasses.Char)
            {
                LoadInt(variable, generator);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static void LoadInt(Variable variable, ByteCodeGenerator generator)
        {
            switch (variable.Index)
            {
                case 0:
                    generator.Emit(OpCodes.iload_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.iload_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.iload_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.iload_3);
                    break;
                default:
                    generator.Emit(OpCodes.iload, variable.Index);
                    break;

            }
        }
        public static void LoadLong(Variable variable, ByteCodeGenerator generator)
        {
            switch (variable.Index)
            {
                case 0:
                    generator.Emit(OpCodes.lload_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.lload_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.lload_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.lload_3);
                    break;
                default:
                    generator.Emit(OpCodes.lload, variable.Index);
                    break;

            }
        }
        public static void LoadFloat(Variable variable, ByteCodeGenerator generator)
        {
            switch (variable.Index)
            {
                case 0:
                    generator.Emit(OpCodes.fload_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.fload_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.fload_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.fload_3);
                    break;
                default:
                    generator.Emit(OpCodes.fload, variable.Index);
                    break;

            }
        }
        public static void LoadDouble(Variable variable, ByteCodeGenerator generator)
        {
            switch (variable.Index)
            {
                case 0:
                    generator.Emit(OpCodes.dload_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.dload_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.dload_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.dload_3);
                    break;
                default:
                    generator.Emit(OpCodes.dload, variable.Index);
                    break;

            }
        }
        #endregion
    }
}
