using System;

namespace JavaCompiler.Reflection.Types
{
    public class Interface : DefinedType
    {
        public override bool IsAssignableTo(Type c)
        {
            throw new NotImplementedException();
        }
    }
}