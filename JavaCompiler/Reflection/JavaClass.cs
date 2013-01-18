using System.Collections.Generic;

namespace JavaCompiler.Reflection
{
    public class JavaClass : JavaType
    {
        public JavaClass()
        {
            Modifiers = new List<JavaModifier>();

            NestedTypes = new List<JavaType>();
            Interfaces = new List<JavaClass>();

            Fields = new List<JavaField>();
            Methods = new List<JavaMethod>();

            SuperType = "java.lang.Object";
        }

        public List<JavaModifier> Modifiers { get; private set; }
        public string Name { get; set; }

        public List<JavaType> NestedTypes { get; private set; }

        public List<JavaField> Fields { get; private set; }

        public List<JavaMethod> Methods { get; private set; }

        // TODO
        public List<JavaClass> Interfaces { get; private set; }

        public JavaTypeRef SuperType { get; set; }
    }
}
