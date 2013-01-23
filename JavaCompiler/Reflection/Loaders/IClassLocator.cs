using System.Collections.Generic;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Reflection.Loaders
{
    internal interface IClassLocator
    {
        List<Type> Search(string s, List<string> imports);
    }
}