using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators;

namespace JavaCompiler.Reflection.Loaders
{
    class DirectoryClassLocator : IClassLocator
    {
        public string Directory { get; private set; }
        public DirectoryClassLocator(string baseDirectory)
        {
            Directory = baseDirectory;
        }

        public List<Type> Search(string s, List<string> imports)
        {
            if (s.Contains("."))
            {
                return SearchAbsolute(s);
            }

            var classes = new List<Type>();

            /*{
                var path = Path.Combine(Directory, s + ".class");

                if(File.Exists(path))
                {
                    classes.Add(ClassLoader.Load(path));
                }
            }*/

            var usedFiles = new List<string>();

            foreach (var import in imports)
            {
                var importParts = import.Split('.');
                var importName = importParts.Last();

                if (importName != "*" && importName != s) continue;

                var path = Path.Combine(Directory, s.Replace('.', '\\') + ".class");

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

                    var tree = Compiler.BuildAst(File.ReadAllText(path));
                    var classStructure = new ProgramTranslator(tree).Walk().Type;

                    classes.Add(classStructure);
                }
            }

            return classes;
        }

        private List<Type> SearchAbsolute(string s)
        {
            var classes = new List<Type>();

            var path = Path.Combine(Directory, s.Replace('.', '\\') + ".class");

            if (File.Exists(path))
            {
                classes.Add(ClassLoader.Load(path));
            }

            return classes;
        }
    }
}
