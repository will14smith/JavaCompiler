using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Reflection
{
    public class Constructor : AccessibleObject, IGenericDeclaration, IMember
    {
        public Constructor()
        {
            TypeParameters = new List<TypeVariable>();

            Parameters = new List<Method.Parameter>();

            ExceptionTypes = new List<Type>();
        }

        public bool Synthetic { get; set; }
        public DefinedType DeclaringType { get; set; }

        public string Name { get; set; }
        public Modifier Modifiers { get; set; }

        public List<TypeVariable> TypeParameters { get; private set; }

        public List<Method.Parameter> Parameters { get; private set; }

        public List<Type> ExceptionTypes { get; private set; }

        public MethodTree Body { get; set; }

        public void Resolve(List<Package> imports)
        {
            foreach (var parameter in Parameters)
            {
                parameter.Resolve(imports);
            }
        }

        public string GetDescriptor()
        {
            return string.Format("({0})V", Parameters.Aggregate("", (s, parameter) => s + parameter.Type.GetDescriptor()));
        }

        public static explicit operator Method(Constructor constructor)
        {
            var method = new Method
            {
                Modifiers = constructor.Modifiers,
                Name = constructor.DeclaringType.Name,
                ReturnType = PrimativeTypes.Void
            };

            method.Parameters.AddRange(constructor.Parameters);

            return method;
        }
    }
}
