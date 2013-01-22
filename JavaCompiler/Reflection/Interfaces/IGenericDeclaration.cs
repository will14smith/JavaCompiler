using System.Collections.Generic;

namespace JavaCompiler.Reflection.Interfaces
{
    public interface IGenericDeclaration
    {
        List<TypeVariable> TypeParameters { get; }
    }
}
