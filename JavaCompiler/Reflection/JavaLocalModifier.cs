namespace JavaCompiler.Reflection
{
    public class JavaLocalModifier
    {
        public static JavaLocalModifier FINAL { get { return new JavaLocalModifier {IsFinal = true}; } }

        public JavaAnnotation Annotation { get; set; }
        public bool IsFinal { get; set; }
    }
}
