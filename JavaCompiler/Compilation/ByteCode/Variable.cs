using System;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilation.ByteCode
{
    public class Variable
    {
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

        internal short Index { get; private set; }
        internal string Name { get; private set; }
        internal Type Type { get; private set; }

        public bool IsDefined
        {
            get { return true; }
            set { throw new NotImplementedException(); }
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