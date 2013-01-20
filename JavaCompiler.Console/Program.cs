using System.IO;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace JavaCompiler.Console
{
    public class Program
    {
        public static void Preorder(ITree tree, int depth)
        {
            if (tree == null)
            {
                return;
            }

            for (var i = 0; i < depth; i++)
            {
                System.Console.Write("  ");
            }

            System.Console.WriteLine(tree);

            for(var i = 0 ; i < tree.ChildCount; i++)
            {
                Preorder(tree.GetChild(i), depth + 1);
            }
        }

        static void Main(string[] args)
        {
            var compiler = new Compiler(File.ReadAllText("Exercise1.java"));

            File.WriteAllBytes("Exercise1.class", compiler.Compile());
        }
    }
}
