using System;
using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection.Types
{
    public class Class : DefinedType, IGenericDeclaration
    {
        public Class()
        {
            Constructors = new List<Constructor>();
        }

        public Class Super { get; set; }
        public Type GenericSuperclass { get; set; }

        public List<Constructor> Constructors { get; private set; }

        public override bool IsAssignableTo(Type c)
        {
            throw new NotImplementedException();
        }
    }
}
