using System;
using System.Collections.Generic;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection
{
    public class Class : Type, IGenericDeclaration<Class>
    {
        public Class()
        {
            EnumConstants = new List<object>();

            Constructors = new List<Constructor>();
            Methods = new List<Method>();
            Fields = new List<Field>();

            Types = new List<Type>();

            Interfaces = new List<Class>();
            GenericInterfaces = new List<Type>();

            TypeParameters = new List<TypeVariable<Class>>();
        }

        // Name
        public Modifier Modifiers { get; set; }

        public Package Package { get; set; }

        public Class Super { get; set; }
        public Type GenericSuperclass { get; set; }

        public Class DeclaringClass { get; set; }
        public Class ComponentType { get; set; }

        public bool Array { get; set; }
        public bool Annotation { get; set; }
        public bool Enum { get; set; }
        public bool Interface { get; set; }
        public bool Synthetic { get; set; }

        public List<object> EnumConstants { get; private set; }

        public List<Constructor> Constructors { get; private set; }
        public List<Field> Fields { get; private set; }
        public List<Method> Methods { get; private set; }

        public List<Type> Types { get; private set; }

        public List<Class> Interfaces { get; private set; }
        public List<Type> GenericInterfaces { get; private set; }

        public List<TypeVariable<Class>> TypeParameters { get; private set; }

        public override bool IsAssignableTo(Type c)
        {
            throw new NotImplementedException();
        }
    }
}
