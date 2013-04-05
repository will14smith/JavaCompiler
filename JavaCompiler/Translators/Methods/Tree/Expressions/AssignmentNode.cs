using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class AssignmentNode : ExpressionNode
    {
        public PrimaryNode Left { get; set; }
        public TranslateNode Right { get; set; }

        public override Type GetType(ByteCodeGenerator manager)
        {
            return Right.GetType(manager, false, false);
        }

        public class NormalAssignNode : AssignmentNode
        {
            public override string ToString()
            {
                return Left + " = " + Right;
            }
        }

        public class AddAssignNode : AssignmentNode
        {
            public override string ToString()
            {
                return Left + " += " + Right;
            }
        }
        public class MinusAssignNode : AssignmentNode
        {
            public override string ToString()
            {
                return Left + " -= " + Right;
            }
        }
        public class MultiplyAssignNode : AssignmentNode
        {
            public override string ToString()
            {
                return Left + " *= " + Right;
            }
        }
        public class DivideAssignNode : AssignmentNode
        {
            public override string ToString()
            {
                return Left + " /= " + Right;
            }
        }
        public class ModAssignNode : AssignmentNode
        {
            public override string ToString()
            {
                return Left + " %= " + Right;
            }
        }
    }
}