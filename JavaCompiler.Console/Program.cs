using System.Diagnostics;
using System.IO;
using System.Linq;
using JavaCompiler.Jbt;
using JavaCompiler.Jbt.Tree;
using JavaCompiler.Utilities;

namespace JavaCompiler.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ConvertJar(@"C:\Program Files\Java\jre7\lib\rt2.jar");

            var files = Directory.GetFiles("Tests", "*.java", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                CompileFile(file);
            }

            //TestBTree();
        }

        private static void TestBTree()
        {
            var tree = new BTree(3);

            for (var i = 0; i < 8; i++)
            {
                tree.Insert(i, i + 10);

                for (var j = 0; j <= i; j++)
                {
                    Debug.Assert(tree.Find(j).SequenceEqual(new long[] { j + 10 }));
                }
            }

            using (var file = File.OpenWrite("treetest.bin"))
            {
                tree.Write(new BinaryWriter(file));
            }

            var newTree = new BTree(3);

            using (var file = File.OpenRead("treetest.bin"))
            {
                newTree.Read(new BinaryReader(file));
            }

            for (var i = 0; i < 8; i++)
            {
                Debug.Assert(tree.Find(i).SequenceEqual(new long[] { i + 10 }));
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
