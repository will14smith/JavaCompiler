using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class BinaryNode : ExpressionNode
    {
        public TranslateNode LeftChild { get; set; }
        public TranslateNode RightChild { get; set; }

        public override Type GetType(ByteCodeGenerator manager)
        {
            var l = LeftChild.GetType(manager, false, true);
            var r = RightChild.GetType(manager, false, true);

            return l.FindCommonType(r);
        }
    }
}
