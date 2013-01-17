using System.Collections.Generic;

namespace JavaCompiler.Reflection
{
    public class JavaParameter
    {
        public JavaParameter()
        {
            Modifiers = new List<JavaLocalModifier>();
        }

        public List<JavaLocalModifier> Modifiers { get; private set; }

        public string Name { get; set; }
        public JavaTypeRef Type { get; set; }

        public bool IsCatchAll { get; set; }
    }
}
