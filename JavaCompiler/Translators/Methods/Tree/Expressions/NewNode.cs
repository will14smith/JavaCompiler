using System.Collections.Generic;
using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public abstract class NewNode : ExpressionNode
    {
        public Type Type { get; set; }

        public class NewArrayNode : NewNode
        {
            public List<ExpressionNode> Dimensions { get; set; }

            public override Type GetType(ByteCodeGenerator manager)
            {
                throw new System.NotImplementedException();
            }
        }

        public class NewClassNode : NewNode
        {
            public List<TranslateNode> Arguments { get; set; }

            public override Type GetType(ByteCodeGenerator manager)
            {
                return Type;
            }

        }
    }
}