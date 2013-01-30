using System.Collections.Generic;
using JavaCompiler.Reflection.Loaders;

namespace JavaCompiler.Reflection.Types
{
    public class Class : DefinedType
    {
        public Class()
        {
            Constructors = new List<Constructor>();
        }

        public Class Super { get; set; }

        public List<Constructor> Constructors { get; private set; }

        // is this assignable to c?
        public override bool IsAssignableTo(Type c)
        {
            //TODO: Improve
            return c.GetDescriptor() == GetDescriptor() || (Super != null && Super.IsAssignableTo(c));
        }

        public override void Resolve(List<Package> imports)
        {
            Super = ClassLocator.Find(Super, imports) as Class;

            if (Super != null) Super.Resolve(imports);
        }
    }
}