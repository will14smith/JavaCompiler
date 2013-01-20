using JavaCompiler.Reflection;

namespace JavaCompiler.Compilation.ByteCode
{
    public class Variable
    {
        internal short Index { get; private set; }
        internal string Name { get; private set; }
        internal Class Type { get; private set; }

        internal Variable(short index, string name, Class type)
        {
            Index = index;
            Name = name;
            Type = type;
        }

        public Variable(Class type)
        {
            Type = type;

            Index = -1;
            Name = string.Empty;
        }

        public bool IsAssignableTo(Class c)
        {
            // TODO
            return true;
        }
        public bool CanAssign(Class c)
        {
            // TODO
            return true;
        }
    }
}
