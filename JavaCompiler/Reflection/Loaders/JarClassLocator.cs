using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.SharpZipLib.Zip;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Reflection.Loaders
{
    internal class JarClassLocator : IClassLocator
    {
        public JarClassLocator(string jarFile)
        {
            JarFile = jarFile;
        }

        public string JarFile { get; private set; }

        #region IClassLocator Members

        public List<Type> Search(string s, List<string> imports)
        {
            {
                var diretoryName = Path.GetDirectoryName(s);
                var fileName = Path.GetFileNameWithoutExtension(s);

                var jbtPath = Path.Combine(diretoryName, fileName + ".jbt");
                if (File.Exists(jbtPath))
                {
                    return new JbtClassLocator(jbtPath).Search(s, imports);
                }
            }

            var zf = new ZipFile(JarFile);

            string[] classParts = s.Split('.');
            string classFolder = string.Join("\\", classParts.Take(classParts.Length - 1));
            string className = classParts.Last() + ".class";

            bool isAbsolute = !string.IsNullOrEmpty(classFolder);

            var types = new List<Type>();
            foreach (ZipEntry ze in zf)
            {
                if (!ze.IsFile) continue;

                string fileName = Path.GetFileName(ze.Name);
                string directoryName = Path.GetDirectoryName(ze.Name);

                if (isAbsolute)
                {
                    // absolute
                    if (directoryName == classFolder && fileName == className)
                    {
                        types.Add(ClassLoader.Load(zf.GetInputStream(ze)));
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(directoryName) && fileName == className)
                    {
                        types.Add(ClassLoader.Load(zf.GetInputStream(ze)));
                    }
                    else
                    {
                        foreach (string import in imports)
                        {
                            string[] importParts = import.Split('.');
                            string importFolder = string.Join("\\", importParts.Take(importParts.Length - 1));
                            string importName = importParts.Last();

                            if (!(importName == "*" || importName + ".class" == className)) continue;

                            if (importFolder == directoryName && fileName == className)
                            {
                                types.Add(ClassLoader.Load(zf.GetInputStream(ze)));
                            }
                        }
                    }
                }
            }

            return types;
        }

        #endregion
    }
}