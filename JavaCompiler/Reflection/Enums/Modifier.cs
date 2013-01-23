using System;

namespace JavaCompiler.Reflection.Enums
{
    [Flags]
    public enum Modifier
    {
        None = 0x0,
        Public = 0x1,
        Protected = 0x4,
        Private = 0x2,
        Static = 0x8,
        Abstract = 0x400,
        Native = 0x100,
        Syncronized = 0x20,
        Transient = 0x80,
        Volatile = 0x40,
        Strict = 0x800,
    }
}