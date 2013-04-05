using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class RelationNode : ExpressionNode
    {
        public TranslateNode LeftChild { get; set; }
        public TranslateNode RightChild { get; set; }

        public override Type GetType(ByteCodeGenerator manager)
        {
            var l = LeftChild.GetType(manager, false, true);
            var r = RightChild.GetType(manager, false, true);

            return l.FindCommonType(r);
        }

        public class LessThanEqNode : RelationNode
        {
            public override string ToString()
            {
                return string.Format("{0} <= {1}", LeftChild, RightChild);
            }
        }
        public class GreaterThanEqNode : RelationNode
        {
            public override string ToString()
            {
                return string.Format("{0} >= {1}", LeftChild, RightChild);
            }
        }
        public class LessThanNode : RelationNode
        {
            public override string ToString()
            {
                return string.Format("{0} < {1}", LeftChild, RightChild);
            }
        }
        public class GreaterThanNode : RelationNode
        {
            public override string ToString()
            {
                return string.Format("{0} > {1}", LeftChild, RightChild);
            }
        }
    }
}