using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Reflection.Interfaces
{
    public interface IMember
    {
        string Name { get; set; }
        bool Synthetic { get; set; }

        Class DeclaringClass { get; set; }

        Modifier Modifiers { get; set; }
    }
}
