using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection
{
    public class Field : AccessibleObject, IMember
    {
        public bool Synthetic { get; set; }
        public Class DeclaringClass { get; set; }

        public string Name { get; set; }
        public Modifier Modifiers { get; set; }

        public Type Type { get; set; }
    }
}
