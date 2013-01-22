using System;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilation.ByteCode
{
    public class Variable
    {
        internal short Index { get; private set; }
        internal string Name { get; private set; }
        internal Type Type { get; private set; }

        internal Variable(short index, string name, Type type)
        {
            Index = index;
            Name = name;
            Type = type;
        }

        public Variable(Type type)
        {
            Type = type;

            Index = -1;
            Name = string.Empty;
        }

        public bool IsAssignableTo(Type c)
        {
            throw new NotImplementedException();
        }
        public bool CanAssign(Type c)
        {
            throw new NotImplementedException();
        }
    }
}
