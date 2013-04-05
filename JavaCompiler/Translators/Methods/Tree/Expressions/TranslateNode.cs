using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class TranslateNode : MethodTreeNode
    {
        public ExpressionNode Child { get; set; }

        public Type GetType(ByteCodeGenerator manager, bool tryBox, bool tryUnBox)
        {
            var type = Child.GetType(manager);

            var primative = type as PrimativeTypes.PrimativeType;
            if (tryBox && primative != null)
            {
                return primative.BoxedType;
            }

            if (tryUnBox && !type.Primitive)
            {
                return PrimativeTypes.UnboxType(type);
            }

            return type;
        }


        public override string ToString()
        {
            return Child.ToString();
        }
    }
}
