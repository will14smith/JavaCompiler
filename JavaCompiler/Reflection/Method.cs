using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Reflection
{
    public class Method : AccessibleObject, IGenericDeclaration, IMember
    {
        public Method()
        {
            TypeParameters = new List<TypeVariable>();

            Parameters = new List<Parameter>();

            ExceptionTypes = new List<Class>();
        }

        public bool VarArgs { get; set; }
        public Type GenericReturnType { get; set; }

        public List<Parameter> Parameters { get; private set; }

        public List<Class> ExceptionTypes { get; private set; }

        public MethodTree Body { get; set; }

        #region IGenericDeclaration Members

        public List<TypeVariable> TypeParameters { get; private set; }

        #endregion

        #region IMember Members

        public bool Synthetic { get; set; }
        public DefinedType DeclaringType { get; set; }

        public string Name { get; set; }
        public Modifier Modifiers { get; set; }
        public Type ReturnType { get; set; }

        public void Resolve(List<Package> imports)
        {
            ReturnType = ClassLocator.Find(ReturnType, imports);

            foreach (Parameter parameter in Parameters)
            {
                parameter.Resolve(imports);
            }
        }

        public string GetDescriptor()
        {
            return string.Format("({0}){1}",
                                 Parameters.Aggregate("", (s, parameter) => s + parameter.Type.GetDescriptor()),
                                 ReturnType.GetDescriptor());
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}({1})", Name,
                                 Parameters.Aggregate("", (s, parameter) => s + ", " + parameter.Type.GetDescriptor()));
        }

        public static explicit operator Constructor(Method method)
        {
            if (method == null) return null;

            var constructor = new Constructor
                                  {
                                      Modifiers = method.Modifiers,
                                      DeclaringType = method.DeclaringType,
                                  };

            constructor.Parameters.AddRange(method.Parameters);

            return constructor;
        }

        #region Nested type: Parameter

        public class Parameter
        {
            public Parameter()
            {
                Modifiers = new List<LocalModifier>();
            }

            public string Name { get; set; }
            public List<LocalModifier> Modifiers { get; private set; }

            public Type Type { get; set; }

            public void Resolve(List<Package> imports)
            {
                Type = ClassLocator.Find(Type, imports);
            }
        }

        #endregion
    }
}