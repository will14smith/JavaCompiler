using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators
{
    public class ProgramTranslator
    {
        private readonly ITree node;

        public ProgramTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int) JavaNodeType.JAVA_SOURCE);

            this.node = node;
        }

        public Program Walk()
        {
            var program = new Program();

            ITree annotationList = node.GetChild(0);

            int i = 1;
            ITree child = node.GetChild(i++);

            // package decl?
            if ((JavaNodeType) child.Type == JavaNodeType.PACKAGE)
            {
                child = node.GetChild(i++);
            }

            // import decl*
            if ((JavaNodeType) child.Type == JavaNodeType.IMPORT)
            {
                child = node.GetChild(i);
            }

            // type decl
            program.Type = new TypeDeclarationTranslator(child).Walk();

            return program;
        }
    }
}