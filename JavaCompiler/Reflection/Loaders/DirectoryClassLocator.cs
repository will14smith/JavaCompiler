using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JavaCompiler.Reflection.Loaders
{
    class DirectoryClassLocator : IClassLocator
    {
        public string Directory { get; private set; }
        public DirectoryClassLocator(string baseDirectory)
        {
            Directory = baseDirectory;
        }

        public List<Class> Search(string s, List<string> imports)
        {
            if (s.Contains("."))
            {
                return SearchAbsolute(s);
            }
            
            var classes = new List<Class>();

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

        private List<Class> SearchAbsolute(string s)
        {
            var classes = new List<Class>();

            var path = Path.Combine(Directory, s.Replace('.', '\\') + ".class");

            if (File.Exists(path))
            {
                classes.Add(ClassLoader.Load(path));
            }

            return classes;
        }
    }
}
