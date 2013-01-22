using System.Collections.Generic;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Reflection
{
    //TODO
    public class TypeVariable
    {
        public TypeVariable()
        {
            Bounds = new List<Type>();
        }

        public string Name { get; set; }

        public List<Type> Bounds { get; private set; }
        public Type GenericDeclaration { get; set; }
    }
}
