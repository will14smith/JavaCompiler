using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;

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

        public Type Type { get; set; }
    }
}
