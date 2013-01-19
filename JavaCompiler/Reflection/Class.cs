using System.Collections.Generic;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection
{
    public class Class : IType, IGenericDeclaration<Class>
    {
        public Class()
        {
            TypeParameters = new List<JavaTypeVariable<Class>>();
            Methods = new List<Method>();
            Fields = new List<Field>();
            Constructors = new List<Constructor>();
        }

        public string Name { get; set; }
        public Modifier Modifiers { get; set; }

        public Package Package { get; set; }

        public Class Super { get; set; }
        public IType GenericSuperclass { get; set; }

        public Class DeclaringClass { get; set; }
        public Class ComponentType { get; set; }

        public bool Array { get; set; }
        public bool Annotation { get; set; }
        public bool Enum { get; set; }
        public bool Interface { get; set; }
        public bool Primitive { get; set; }
        public bool Synthetic { get; set; }

        public List<object> EnumConstants { get; set; }

        public List<Constructor> Constructors { get; private set; }
        public List<Field> Fields { get; private set; }
        public List<Method> Methods { get; private set; }

        public List<IType> Types { get; set; }

        public List<Class> Interfaces { get; set; }
        public List<IType> GenericInterfaces { get; set; }

        public List<JavaTypeVariable<Class>> TypeParameters { get; private set; }
    }
}
