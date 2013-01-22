using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Compilers.Methods.BlockStatements
{
    public class ConstructorBlockCompiler
    {
        private readonly MethodTree tree;
        public ConstructorBlockCompiler(MethodTree tree)
        {
            this.tree = tree;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            //TODO: Super call
            new BlockCompiler(tree).Compile(generator);
        }
    }
}
