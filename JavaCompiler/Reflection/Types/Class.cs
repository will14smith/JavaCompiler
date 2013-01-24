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
            return c.GetDescriptor() == GetDescriptor();
        }

        public override void Resolve(List<Package> imports)
        {
            Super = ClassLocator.Find(Super, imports) as Class;
        }

        public override Type Clone()
        {
            var type = (Class) base.Clone();

            type.Super = (Class) Super.Clone();

            type.Constructors = Constructors.Select(x => x.Clone()).ToList();

            return type;
        }
    }
}