using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection
{
    //TODO
    public class TypeVariable<T> where T : IGenericDeclaration<T>
    {
        public TypeVariable()
        {
            Bounds = new List<Type>();
        }

        public string Name { get; set; }

        public List<Type> Bounds { get; private set; }
        public T GenericDeclaration { get; set; }
    }
}
