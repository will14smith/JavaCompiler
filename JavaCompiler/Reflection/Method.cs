using System.Collections.Generic;
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

            public Class Type { get; set; }
        }

        public Method()
        {
            TypeParameters = new List<JavaTypeVariable<Method>>();

            Parameters = new List<Parameter>();
            GenericParameterTypes = new List<IType>();

            ExceptionTypes = new List<Class>();
            GenericExceptionTypes = new List<IType>();
        }

        public bool Synthetic { get; set; }
        public bool VarArgs { get; set; }
        public Class DeclaringClass { get; set; }

        public string Name { get; set; }
        public Modifier Modifiers { get;  set; }

        public List<JavaTypeVariable<Method>> TypeParameters { get; private set; }

        public Class ReturnType { get; set; }
        public IType GenericReturnType { get; set; }

        public List<Parameter> Parameters { get; private set; }

        public List<IType> GenericParameterTypes { get; private set; }

        public List<Class> ExceptionTypes { get; private set; }
        public List<IType> GenericExceptionTypes { get; private set; }

        public MethodTree Body { get; set; }
    }
}
