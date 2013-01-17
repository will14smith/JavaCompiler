using System.Collections.Generic;
using Antlr.Runtime.Tree;

namespace JavaCompiler.Reflection
{
    public class JavaMethod
    {
        public JavaMethod()
        {
            Modifiers = new List<JavaModifier>();

            Parameters = new List<JavaParameter>();
        }

        public List<JavaModifier> Modifiers { get; private set; }

        public JavaTypeRef ReturnType { get; set; }

        public string Name { get; set; }
        public List<JavaParameter> Parameters { get; private set; }

        public int ArrayLevels { get; set; }

        public ITree Body { get; set; }
    }
}
