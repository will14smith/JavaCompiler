using System;
using System.Collections.Generic;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection
{
    public class Class : IType, IGenericDeclaration<Class>
    {
        public Class()
        {
            EnumConstants = new List<object>();

            Constructors = new List<Constructor>();
            Methods = new List<Method>();
            Fields = new List<Field>();

            Types = new List<IType>();

            Interfaces = new List<Class>();
            GenericInterfaces = new List<IType>();

            TypeParameters = new List<TypeVariable<Class>>();
        }

        public virtual string Name { get; set; }
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
        public virtual bool Primitive { get { return false; } }
        public bool Synthetic { get; set; }

        public List<object> EnumConstants { get; private set; }

        public List<Constructor> Constructors { get; private set; }
        public List<Field> Fields { get; private set; }
        public List<Method> Methods { get; private set; }

        public List<IType> Types { get; private set; }

        public List<Class> Interfaces { get; private set; }
        public List<IType> GenericInterfaces { get; private set; }

        public List<TypeVariable<Class>> TypeParameters { get; private set; }

        public virtual bool IsAssignableTo(Class c)
        {
            throw new NotImplementedException();
        }
        public bool CanAssignTo(Class c)
        {
            return c.IsAssignableTo(this);
        }
    }
}
