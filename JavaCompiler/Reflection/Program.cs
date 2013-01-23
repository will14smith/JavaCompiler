using System.Collections.Generic;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Reflection
{
    public class Program
    {
        public Program()
        {
            Imports = new List<Package>();
        }

        public Package Package { get; set; }
        public List<Package> Imports { get; private set; }

        public DefinedType Type { get; set; }
    }
}