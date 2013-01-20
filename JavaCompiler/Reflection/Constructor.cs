using System.Collections.Generic;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection
{
    public class Constructor : AccessibleObject, IGenericDeclaration<Constructor>, IMember
    {
        public Constructor()
        {
            TypeParameters = new List<TypeVariable<Constructor>>();

            ParameterTypes = new List<Class>();
            GenericParameterTypes = new List<IType>();

            ExceptionTypes = new List<Class>();
            GenericExceptionTypes = new List<IType>();
        }

        public bool Synthetic { get; set; }
        public Class DeclaringClass { get; set; }

        public string Name { get; set; }
        public Modifier Modifiers { get; set; }

        public List<TypeVariable<Constructor>> TypeParameters { get; private set; }

        public List<Class> ParameterTypes { get; private set; }
        public List<IType> GenericParameterTypes { get; private set; }

        public List<Class> ExceptionTypes { get; private set; }
        public List<IType> GenericExceptionTypes { get; private set; }
    }
}
