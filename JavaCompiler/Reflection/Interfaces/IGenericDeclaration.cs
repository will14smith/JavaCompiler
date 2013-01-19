using System.Collections.Generic;

namespace JavaCompiler.Reflection.Interfaces
{
    public interface IGenericDeclaration<T> where T : IGenericDeclaration<T>
    {
        List<JavaTypeVariable<T>> TypeParameters { get; }
    }
}
