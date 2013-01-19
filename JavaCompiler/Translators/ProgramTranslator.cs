using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators
{
    class ProgramTranslator
    {
        private readonly ITree node;
        public ProgramTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.JAVA_SOURCE);

            this.node = node;
        }

        public Program Walk()
        {
            var program = new Program();

            var annotationList = node.GetChild(0);

            var i = 1;
            var child = node.GetChild(i++);

            // package decl?
            if ((JavaNodeType)child.Type == JavaNodeType.PACKAGE)
            {
                child = node.GetChild(i++);
            }

            // import decl*
            if ((JavaNodeType)child.Type == JavaNodeType.IMPORT)
            {
                child = node.GetChild(i);
            }

            // type decl*
            while(i <= node.ChildCount)
            {
                program.Types.Add(new TypeDeclarationTranslator(child).Walk());

                child = node.GetChild(i++);
            }

            return program;
        }
    }
}
