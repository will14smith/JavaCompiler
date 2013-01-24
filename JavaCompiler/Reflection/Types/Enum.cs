using System;
using System.Collections.Generic;
using System.Linq;

namespace JavaCompiler.Reflection.Types
{
    public class Enum : DefinedType
    {
        public Enum()
        {
            Constants = new List<ICloneable>();

            Constructors = new List<Constructor>();
        }

        public Class Super { get; set; }

        public List<ICloneable> Constants { get; private set; }

        public List<Constructor> Constructors { get; private set; }

        public override bool IsAssignableTo(Type c)
        {
            throw new NotImplementedException();
        }
    }
}