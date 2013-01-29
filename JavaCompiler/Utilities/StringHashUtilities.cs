using System;

namespace JavaCompiler.Utilities
{
    static class StringHashUtilities
    {
        public static ulong Hash(this string s)
        {
            var hashedValue = 3074457345618258791ul;
            foreach (var t in s)
            {
                hashedValue += t;
                hashedValue *= 3074457345618258799ul;
            }
            return hashedValue;
        }
    }
}
