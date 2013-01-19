using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;

namespace JavaCompiler.Reflection
{
    //TODO
    public class Program
    {
        public Program()
        {
            Types = new List<IType>();
        }

        public List<IType> Types { get; set; }
    }
}
