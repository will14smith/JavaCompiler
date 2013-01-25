using System.Collections.Generic;
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
            while ((JavaNodeType) child.Type == JavaNodeType.IMPORT)
            {
                program.Imports.Add(new Package { Name = GetName(child.GetChild(0)) });

                child = node.GetChild(i++);
            }

            // type decl
            program.Type = new TypeDeclarationTranslator(child).Walk();

            return program;
        }

        private static string GetName(ITree tree)
        {
            if((JavaNodeType)tree.Type == JavaNodeType.DOT)
            {
                return GetName(tree.GetChild(0)) + "." + GetName(tree.GetChild(1));
            }

            return tree.Text;
        }
    }
}