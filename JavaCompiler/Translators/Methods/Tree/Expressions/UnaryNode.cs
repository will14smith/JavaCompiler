using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class UnaryNode : ExpressionNode
    {
        public TranslateNode Child { get; set; }

        public override Type GetType(ByteCodeGenerator manager)
        {
            return Child.GetType(manager, false, true);
        }

        public class PlusNode : UnaryNode
        {
            public override string ToString()
            {
                return string.Format("(+{0})", Child);
            }
        }
        public class MinusNode : UnaryNode
        {
            public override string ToString()
            {
                return string.Format("(-{0})", Child);
            }
        }
        public class PreIncNode : UnaryNode
        {
            public override string ToString()
            {
                return string.Format("(++{0})", Child);
            }
        }
        public class PreDecNode : UnaryNode
        {
            public override string ToString()
            {
                return string.Format("(--{0})", Child);
            }
        }
        public class PostIncNode : UnaryNode
        {
            public override string ToString()
            {
                return string.Format("({0}++)", Child);
            }
        }
        public class PostDecNode : UnaryNode
        {
            public override string ToString()
            {
                return string.Format("({0}++)", Child);
            }
        }
    }
}