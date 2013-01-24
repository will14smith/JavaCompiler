using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Compilation.ByteCode
{
    class UninitializedType : Type
    {
        private const int _uninitializedThis = (int)ItemTypeCode.TypeCodeCount;
        private const int _uninitializedObject = _uninitializedThis + 1;

        public int Tag { get; private set; }
        public Type Type { get; private set; }
        public int Offset { get; private set; }

        private UninitializedType(int tag, Type qtype, int offset)
        {
            Tag = tag;
            Type = qtype;

            Offset = offset;
        }

        public static UninitializedType UninitializedThis(Type qtype)
        {
            return new UninitializedType(_uninitializedThis, qtype, -1);
        }

        public static UninitializedType UninitializedObject(Type qtype, int offset)
        {
            return new UninitializedType(_uninitializedObject, qtype, offset);
        }
    }
}
