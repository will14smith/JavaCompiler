using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class AssignmentCompiler
    {
        private readonly AssignmentNode node;

        public AssignmentCompiler(AssignmentNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            Item lhs = new ExpressionCompiler(node.Left).Compile(generator);

            new ExpressionCompiler(node.Right).Compile(generator).Load();

            return new AssignItem(generator, lhs);
        }
    }
}