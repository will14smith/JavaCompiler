using System.Collections.Generic;

namespace JavaCompiler.Reflection
{
    public class JavaClass : JavaType
    {
        public JavaClass()
        {
            Modifiers = new List<JavaModifier>();
            NestedTypes = new List<JavaType>();

            Members = new List<JavaMember>();
            Methods = new List<JavaMethod>();
        }

        public List<JavaModifier> Modifiers { get; private set; }
        public string Name { get; set; }

        public List<JavaType> NestedTypes { get; private set; }

        public List<JavaMember> Members { get; private set; }

        public List<JavaMethod> Methods { get; private set; }
    }
}
