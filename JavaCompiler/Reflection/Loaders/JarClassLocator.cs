﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.SharpZipLib.Zip;

namespace JavaCompiler.Reflection.Loaders
{
    class JarClassLocator : IClassLocator
    {
        public string JarFile { get; private set; }
        public JarClassLocator(string jarFile)
        {
            JarFile = jarFile;
        }

        public List<Class> Search(string s, List<string> imports)
        {
            var zf = new ZipFile(JarFile);

            var classParts = s.Split('.');
            var classFolder = string.Join("\\", classParts.Take(classParts.Length - 1));
            var className = classParts.Last() + ".class";

            var isAbsolute = !string.IsNullOrEmpty(classFolder);

            var classes = new List<Class>();
            foreach (ZipEntry ze in zf)
            {
                if (!ze.IsFile) continue;

                var fileName = Path.GetFileName(ze.Name);
                var directoryName = Path.GetDirectoryName(ze.Name);

                if (isAbsolute)
                {
                    // absolute
                    if (directoryName == classFolder && fileName == className)
                    {
                        classes.Add(ClassLoader.Load(zf.GetInputStream(ze)));
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(directoryName) && fileName == className)
                    {
                        classes.Add(ClassLoader.Load(zf.GetInputStream(ze)));
                    }
                    else
                    {
                        foreach (var import in imports)
                        {
                            var importParts = import.Split('.');
                            var importFolder = string.Join("\\", importParts.Take(importParts.Length - 1));
                            var importName = importParts.Last();

                            if (!(importName == "*" || importName + ".class" == className)) continue;

                            if (importFolder == directoryName && fileName == className)
                            {
                                classes.Add(ClassLoader.Load(zf.GetInputStream(ze)));
                            }
                        }
                    }
                }
            }

            return classes;
        }
    }
}
