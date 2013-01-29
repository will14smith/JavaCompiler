using System.Collections.Generic;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class NewNode : ExpressionNode
    {
        public class NewArrayNode : NewNode
        {
            public Type Type { get; set; }
            public List<ExpressionNode> Dimensions { get; set; }
        }

        public class NewClassNode : NewNode
        {
            public Type Type { get; set; }
            public List<ExpressionNode> Arguments { get; set; }
        }
    }
}