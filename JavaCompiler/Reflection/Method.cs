using System.Collections.Generic;
using System.Linq;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Reflection
{
    public class Method : AccessibleObject, IGenericDeclaration<Method>, IMember
    {
        public class Parameter
        {
            public Parameter()
            {
                Modifiers = new List<LocalModifier>();
            }

            public string Name { get; set; }
            public List<LocalModifier> Modifiers { get; private set; }

            public Type Type { get; set; }
        }

        public Method()
        {
            TypeParameters = new List<TypeVariable<Method>>();

            Parameters = new List<Parameter>();
            GenericParameterTypes = new List<Type>();

            ExceptionTypes = new List<Class>();
            GenericExceptionTypes = new List<Type>();
        }

        public bool Synthetic { get; set; }
        public bool VarArgs { get; set; }
        public Class DeclaringClass { get; set; }

        public string Name { get; set; }
        public Modifier Modifiers { get; set; }

        public List<TypeVariable<Method>> TypeParameters { get; private set; }

        public Type ReturnType { get; set; }
        public Type GenericReturnType { get; set; }

        public List<Parameter> Parameters { get; private set; }

        public List<Type> GenericParameterTypes { get; private set; }

        public List<Class> ExceptionTypes { get; private set; }
        public List<Type> GenericExceptionTypes { get; private set; }

        public MethodTree Body { get; set; }

        public string GetDescriptor()
        {
            return string.Format("({0}){1}", Parameters.Aggregate("", (s, parameter) => s + parameter.Type.GetDescriptor()), ReturnType.GetDescriptor());
        }
    }
}
