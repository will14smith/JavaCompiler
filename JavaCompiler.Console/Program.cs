using System.IO;

namespace JavaCompiler.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("Tests", "*.java", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                CompileFile(file);
            }
        }

        static void CompileFile(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            var compiler = new Compiler(File.ReadAllText(filePath));

            compiler.ClassPath.Add(directory);

            File.WriteAllBytes(Path.Combine(directory, fileName + ".class"), compiler.Compile());
        }
    }
}
