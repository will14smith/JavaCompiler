using System;
using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection.Types
{
    public class Enum : DefinedType, IGenericDeclaration
    {
        public Enum()
        {
            Constants = new List<object>();

            Constructors = new List<Constructor>();
        }

        public Class Super { get; set; }
        public Type GenericSuperclass { get; set; }

        public List<object> Constants { get; private set; }

        public List<Constructor> Constructors { get; private set; }

        public override bool IsAssignableTo(Type c)
        {
            throw new NotImplementedException();
        }
    }
}
