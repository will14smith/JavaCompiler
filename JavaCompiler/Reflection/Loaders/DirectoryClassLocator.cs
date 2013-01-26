using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators;

namespace JavaCompiler.Reflection.Loaders
{
    internal class DirectoryClassLocator : IClassLocator
    {
        public DirectoryClassLocator(string baseDirectory)
        {
            Directory = baseDirectory;
        }

        public string Directory { get; private set; }

        #region IClassLocator Members

        public List<Type> Search(string s, List<string> imports)
        {
            if (s.Contains("."))
            {
                return SearchAbsolute(s);
            }

            var classes = new List<Type>();

            var usedFiles = new List<string>();

            foreach (string import in imports)
            {
                string[] importParts = import.Split('.');
                string importName = importParts.Last();

                if (importName != "*" && importName != s) continue;

                string path = Path.Combine(Directory, s.Replace('.', '\\') + ".class");

                if (usedFiles.Contains(Path.GetFileNameWithoutExtension(path)))
                {
                    continue;
                }

                if (File.Exists(path))
                {
                    usedFiles.Add(Path.GetFileNameWithoutExtension(path));

                    classes.Add(ClassLoader.Load(path));

                    continue;
                }

                path = Path.Combine(Directory, s.Replace('.', '\\') + ".java");

                if (File.Exists(path))
                {
                    usedFiles.Add(Path.GetFileNameWithoutExtension(path));

                    CommonTree tree = Compiler.BuildAst(File.ReadAllText(path));
                    DefinedType classStructure = new ProgramTranslator(tree).Walk().Type;

                    classes.Add(classStructure);
                }
            }

            return classes;
        }

        #endregion

        private List<Type> SearchAbsolute(string s)
        {
            var classes = new List<Type>();

            string path = Path.Combine(Directory, s.Replace('.', '\\') + ".class");

            if (File.Exists(path))
            {
                classes.Add(ClassLoader.Load(path));
            }

            return classes;
        }
    }
}