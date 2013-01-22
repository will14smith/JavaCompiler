using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Reflection.Types;

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

            {
                var path = Path.Combine(Directory, s + ".class");

                if(File.Exists(path))
                {
                    classes.Add(ClassLoader.Load(path));
                }
            }

            foreach (var import in imports)
            {
                var importParts = import.Split('.');
                var importName = importParts.Last();

                if (importName != "*" && importName != s) continue;

                var path = Path.Combine(Directory, import.Replace('.', '\\') + ".class");

                if (File.Exists(path))
                {
                    classes.Add(ClassLoader.Load(path));
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
