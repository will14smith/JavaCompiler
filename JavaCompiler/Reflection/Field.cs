using System.Collections.Generic;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Reflection
{
    public class Field : AccessibleObject, IMember
    {
        public bool Synthetic { get; set; }
        public DefinedType DeclaringType { get; set; }

        public string Name { get; set; }
        public Modifier Modifiers { get; set; }
        
        public Type Type { get; set; }

        public void Resolve(List<Package> imports)
        {
            Type = ClassLocator.Find(Type, imports);
        }
    }
}
