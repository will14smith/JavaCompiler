using System.Collections.Generic;
using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Reflection.Types
{
    public abstract class DefinedType : Type
    {
        protected DefinedType()
        {
            Methods = new List<Method>();
            Fields = new List<Field>();

            Types = new List<Type>();

            Interfaces = new List<Interface>();
        }

        public ClassModifier Modifiers { get; set; }

        public Class DeclaringClass { get; set; }
        public Class ComponentType { get; set; }

        public List<Field> Fields { get; protected set; }
        public List<Method> Methods { get; protected set; }

        public List<Type> Types { get; protected set; }

        public List<Interface> Interfaces { get; protected set; }

        public virtual void Resolve(List<Package> imports)
        {
        }
    }
}