namespace JavaCompiler.Reflection.Enums
{
    public class LocalModifier
    {
        public static LocalModifier Final
        {
            get { return new LocalModifier {IsFinal = true}; }
        }

        public bool IsFinal { get; set; }
    }
}