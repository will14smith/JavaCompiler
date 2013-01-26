using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Jbt.IO;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Reflection.Loaders
{
    class JbtClassLocator : IClassLocator
    {
        private static readonly Dictionary<string, JbtClassLocator> Locators = new Dictionary<string, JbtClassLocator>();
        public static JbtClassLocator Get(string jbtFile)
        {
            if (!Locators.ContainsKey(jbtFile))
            {
                Locators.Add(jbtFile, new JbtClassLocator(jbtFile));
            }

            return Locators[jbtFile];
        }

        private JbtClassLocator(string jbtFile)
        {
            JbtFile = jbtFile;

            Reader = new JbtReader(new EndianBinaryReader(EndianBitConverter.Big, File.OpenRead(jbtFile)));
        }

        public string JbtFile { get; private set; }
        public JbtReader Reader { get; private set; }

        public List<Type> Search(string s, List<string> imports)
        {
            if (s.Contains("."))
            {
                return SearchAbsolute(s);
            }

            var classes = new List<Type>();

            foreach (var import in imports)
            {
                var importParts = import.Split('.');
                var importName = importParts.Last();

                if (importName != "*" && importName != s) continue;

                var resolvedType = string.Join("/", importParts.Take(importParts.Count() - 1).Concat(new[] { s }));

                var type = Reader.Find(resolvedType);
                if (type != null)
                {
                    classes.Add(type);
                }
            }

            return classes;
        }

        private List<Type> SearchAbsolute(string s)
        {
            var classes = new List<Type>();

            var type = Reader.Find(s.Replace('.', '/'));
            if (type != null)
            {
                classes.Add(type);
            }

            return classes;
        }
    }
}
