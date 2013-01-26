using System;
using System.Collections.Generic;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Reflection.Loaders
{
    class JbtClassLocator : IClassLocator
    {
        public JbtClassLocator(string jbtFile)
        {
            JbtFile = jbtFile;
        }

        public string JbtFile { get; private set; }

        public List<Type> Search(string s, List<string> imports)
        {
            throw new NotImplementedException();
        }
    }
}
