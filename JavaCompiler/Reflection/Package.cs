using System;

namespace JavaCompiler.Reflection
{
    public class Package
    {
        public string Name { get; set; }

        public Package Clone()
        {
            return new Package
            {
                Name = Name
            };
        }
    }
}