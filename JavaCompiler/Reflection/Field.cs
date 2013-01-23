using System.Collections.Generic;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Reflection
{
    public class Field : AccessibleObject, IMember
    {
        #region IMember Members

        public bool Synthetic { get; set; }
        public DefinedType DeclaringType { get; set; }

        public string Name { get; set; }
        public Modifier Modifiers { get; set; }

        public Type ReturnType { get; set; }

        public void Resolve(List<Package> imports)
        {
            ReturnType = ClassLocator.Find(ReturnType, imports);
        }

        public string GetDescriptor()
        {
            return ReturnType.GetDescriptor();
        }

        #endregion
    }
}