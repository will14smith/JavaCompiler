using System.Collections.Generic;

namespace JavaCompiler.Reflection
{
    public class Package
    {
        public Package()
        {
            Packages = new List<Package>();
        }

        public string Name { get; set; }

        public List<Package> Packages { get; private set; }
    }
}
