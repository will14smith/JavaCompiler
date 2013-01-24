using System.Collections.Generic;
using System.Linq;
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

        public List<Field> Fields { get; private set; }
        public List<Method> Methods { get; private set; }

        public List<Type> Types { get; private set; }

        public List<Interface> Interfaces { get; private set; }

        public virtual void Resolve(List<Package> imports)
        {
        }

        public override Type Clone()
        {
            var type = (DefinedType)base.Clone();

            type.Modifiers = Modifiers;

            type.DeclaringClass = (Class)DeclaringClass.Clone();
            type.ComponentType = (Class)ComponentType.Clone();

            type.Fields = Fields.Select(x => x.Clone()).ToList();
            type.Methods = Methods.Select(x => x.Clone()).ToList();

            type.Types = Types.Select(x => x.Clone()).ToList();

            type.Interfaces = Interfaces.Select(x => (Interface)x.Clone()).ToList();

            return type;
        }
    }
}