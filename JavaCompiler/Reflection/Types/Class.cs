using System.Collections.Generic;
using System.Linq;
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

        public override bool IsAssignableTo(Type c)
        {
            //TODO: Improve
            if (Name == "java.lang.Object") return !c.Primitive;

            return c.GetDescriptor() == GetDescriptor();
        }

        public override void Resolve(List<Package> imports)
        {
            Super = ClassLocator.Find(Super, imports) as Class;
        }
    }
}