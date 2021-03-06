﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Reflection.Types.Internal;
using Array = JavaCompiler.Reflection.Types.Array;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Reflection.Loaders
{
    public static class ClassLocator
    {
        private static readonly Dictionary<string, Type> CachedClasses = new Dictionary<string, Type>();

        static ClassLocator()
        {
            SearchPaths = new List<string> { @"C:\Program Files\Java\jre7\lib\rt.jar", @"D:\Program Files\Java\jre6\lib\rt.jar" };
        }

        public static List<string> SearchPaths { get; private set; }

        public static void Add(Type c, List<Package> importedPackages)
        {
            CachedClasses.Add(GetCacheKey(c.Name, ProcessImports(importedPackages)), c);
        }

        public static void Reset()
        {
            CachedClasses.Clear();
        }

        public static Type Find(Type c, List<Package> importedPackages)
        {
            if (c == null) return null;
            if (c.Primitive) return c;

            var array = c as Array;
            if (array != null)
            {
                return new Array(Find(array.ArrayType, importedPackages));
            }
            if (c is PlaceholderType)
            {
                var result = Find(c.Name, importedPackages);

                return result;
            }

            return c;
        }

        public static Type Find(string s)
        {
            return Find(s, new List<Package>());
        }

        public static Type Find(string s, List<Package> importedPackages)
        {
            List<string> imports = ProcessImports(importedPackages);

            string cacheKey = GetCacheKey(s, imports);

            if (!CachedClasses.ContainsKey(cacheKey))
            {
                var results = new List<Type>();

                foreach (string location in SearchPaths.Distinct())
                {
                    IClassLocator locator;

                    if (location.EndsWith(".jar"))
                    {
                        if (!File.Exists(location))
                        {
                            continue;
                        }

                        locator = new JarClassLocator(location);
                    }
                    else
                    {
                        locator = new DirectoryClassLocator(location);
                    }

                    results.AddRange(locator.Search(s, imports));
                }

                if (results.Count() == 1)
                {
                    CachedClasses.Add(cacheKey, results.Single());
                }
                else if (!results.Any())
                {
                }
                else
                {
                }
            }

            return CachedClasses[cacheKey];
        }

        private static List<string> ProcessImports(IEnumerable<Package> packages)
        {
            if (packages == null)
            {
                packages = new List<Package>();
            }

            List<string> imports = packages.Select(x => x.Name).ToList();
            if (!imports.Contains("java.lang.*"))
            {
                imports.Add("java.lang.*");
            }

            return imports.OrderBy(x => x).ToList();
        }

        private static string GetCacheKey(string s, IEnumerable<string> imports)
        {
            return imports.Aggregate(s, (s1, s2) => s1 + ";" + s2);
        }
    }
}