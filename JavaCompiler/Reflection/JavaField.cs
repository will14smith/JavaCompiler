using System.Collections.Generic;

namespace JavaCompiler.Reflection
{
    public class JavaField
    {
        public JavaField()
        {
            Modifiers = new List<JavaModifier>();
        }

        public List<JavaModifier> Modifiers { get; private set; }

        public JavaTypeRef Type { get; set; }

        public string Name { get; set; }
    }
}
