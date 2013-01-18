using System.Collections.Generic;

namespace JavaCompiler.Reflection
{
    public class JavaProgram
    {
        public JavaProgram()
        {
            Types = new List<JavaType>();
        }

        public List<JavaType> Types { get; set; }
    }
}
