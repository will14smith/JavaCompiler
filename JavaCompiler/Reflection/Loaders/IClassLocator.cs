using System.Collections.Generic;

namespace JavaCompiler.Reflection.Loaders
{
    internal interface IClassLocator
    {
        List<Class> Search(string s, List<string> imports);
    }
}
