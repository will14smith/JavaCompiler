using System.Collections.Generic;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Reflection.Interfaces
{
    public interface IMember
    {
        string Name { get; set; }
        bool Synthetic { get; set; }

        DefinedType DeclaringType { get; set; }

        Modifier Modifiers { get; set; }

        void Resolve(List<Package> imports);
    }
}
