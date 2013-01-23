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

            TypeParameters = new List<TypeVariable>();
        }

        public ClassModifier Modifiers { get; set; }

        public Package Package { get; set; }

        public Class DeclaringClass { get; set; }
        public Class ComponentType { get; set; }

        public List<Field> Fields { get; private set; }
        public List<Method> Methods { get; private set; }

        public List<Type> Types { get; private set; }

        public List<Interface> Interfaces { get; private set; }

        public List<TypeVariable> TypeParameters { get; private set; }

        public virtual void Resolve(List<Package> imports)
        {
        }
    }
}