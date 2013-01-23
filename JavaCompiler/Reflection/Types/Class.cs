using System;
using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Loaders;

namespace JavaCompiler.Reflection.Types
{
    public class Class : DefinedType, IGenericDeclaration
    {
        public Class()
        {
            Constructors = new List<Constructor>();
        }

        public Class Super { get; set; }

        public List<Constructor> Constructors { get; private set; }

        public override bool IsAssignableTo(Type c)
        {
            throw new NotImplementedException();
        }

        public override void Resolve(List<Package> imports)
        {
            Super = ClassLocator.Find(Super, imports) as Class;
        }
    }
}