﻿using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Translators.Methods.Tree.Expressions
{
    public class LogicalAndNode : ExpressionNode
    {
        public override Type GetType(ByteCodeGenerator manager)
        {
            throw new System.NotImplementedException();
        }
    }
}