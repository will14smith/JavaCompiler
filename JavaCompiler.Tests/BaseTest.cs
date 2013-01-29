using System.Diagnostics;
using System.IO;
using System.Linq;

namespace JavaCompiler.Tests
{
    public class BaseTest
    {
        protected string Test(string folder, string className, params string[] args)
        {
            Compile(Path.Combine(folder, className + ".java"));

            return Run(folder, className, args);
        }

        protected void Compile(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            var compiler = new Compiler(File.ReadAllText(filePath));

            compiler.ClassPath.Add(directory);

            var classPath = Path.Combine(directory, fileName);

            File.WriteAllBytes(classPath + ".class", compiler.Compile());
        }
        protected string Run(string folder, string className, params string[] args)
        {
            var p = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    FileName = "java",

                    CreateNoWindow = true,

                    WorkingDirectory = folder,
                    Arguments = className + (args.Length > 0 ? " " : "") + string.Join(" ", args.Select(x => x.Contains(" ") ? "\"" + x + "\"" : x))
                }
            };

            p.Start();

            var output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            return output.TrimEnd('\r', '\n');
        }
    }
}
