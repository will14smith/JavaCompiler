using System.IO;
using JavaCompiler.Jbt;
using JavaCompiler.Jbt.Tree;
using JavaCompiler.Utilities;

namespace JavaCompiler.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("Tests\\Constructors", "*.java", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                CompileFile(file);
            }

            //ConvertJar(@"C:\Program Files\Java\jre7\lib\plugin.jar");
            //ConvertJar(@"C:\Program Files\Java\jre7\lib\rt.jar");
            //ConvertJar(@"E:\Projects\picture_processing\junit.jar");

            //CompileFile(@"Tests\Tutorial1\Exercise1.java");
        }

        static void CompileFile(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            var compiler = new Compiler(File.ReadAllText(filePath));

            compiler.ClassPath.Add(directory);

            File.WriteAllBytes(Path.Combine(directory, fileName + ".class"), compiler.Compile());
        }

        static void ConvertJar(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var writePath = Path.Combine(directory, fileName + ".jbt");

            var jbtConverter = new JbtConverter(File.OpenRead(filePath));

            jbtConverter.Convert(new EndianBinaryWriter(EndianBitConverter.Big, File.Create(writePath)));
        }
    }
}
