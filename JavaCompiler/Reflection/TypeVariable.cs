using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection
{
    //TODO
    public class TypeVariable<T> where T : IGenericDeclaration<T>
    {
        public TypeVariable()
        {
            Bounds = new List<IType>();
        }

        public string Name { get; set; }

        public List<IType> Bounds { get; private set; }
        public T GenericDeclaration { get; set; }
    }
}
