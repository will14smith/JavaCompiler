using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class AdditiveNode : BinaryNode
    {
        #region Nested type: AdditiveMinusNode

        public class AdditiveMinusNode : AdditiveNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " - " + RightChild + ")";
            }
        }

        #endregion

        #region Nested type: AdditivePlusNode

        public class AdditivePlusNode : AdditiveNode
        {
            public override string ToString()
            {
                return "(" + LeftChild + " + " + RightChild + ")";
            }

            public override Type GetType(ByteCodeGenerator manager)
            {
                var l = LeftChild.GetType(manager, false, true);
                var r = RightChild.GetType(manager, false, true);

                if (!l.Primitive || !r.Primitive)
                {
                    return BuiltinTypes.String;
                }

                return base.GetType(manager);
            }
        }

        #endregion
    }
}