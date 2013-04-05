using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;
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
            if (node is AssignmentNode.NormalAssignNode)
            {
                return CompileAssign(generator);
            }
            return CompileAssignOp(generator);
        }

        private Item CompileAssign(ByteCodeGenerator generator)
        {
            var lhs = new ExpressionCompiler(node.Left).Compile(generator);
            var type = ClassLocator.Find(lhs.Type, generator.Manager.Imports);

            new TranslationCompiler(node.Right, type).Compile(generator).Load();

            return new AssignItem(generator, lhs);
        }
        private Item CompileAssignOp(ByteCodeGenerator generator)
        {
            var lType = new TranslateNode { Child = node.Left }.GetType(generator, false, true);
            var rType = node.Right.GetType(generator, false, true);

            var type = lType.FindCommonType(rType);

            Item lhs;
            if (lType.Name == BuiltinTypes.String.Name)
            {
                var sb = BuiltinTypes.StringBuilder;

                AdditiveCompiler.MakeStringBuffer(generator, sb);

                lhs = new ExpressionCompiler(node.Left).Compile(generator);
                if (lhs.Width() > 0)
                {
                    generator.Emit(OpCodeValue.dup_x1 + (byte)(3 * (lhs.Width() - 1)));
                }

                lhs.Load();

                AdditiveCompiler.AppendStrings(generator, sb, node.Left);
                AdditiveCompiler.AppendStrings(generator, sb, node.Right.Child);

                AdditiveCompiler.BufferToString(generator, sb);
            }
            else
            {
                lhs = new ExpressionCompiler(node.Left).Compile(generator);
                lhs.Duplicate();

                lhs.Coerce(type).Load();

                new TranslationCompiler(node.Right, type).Compile(generator).Load();
                if (node is AssignmentNode.AddAssignNode)
                {
                    AdditiveCompiler.CompileAddition(generator, type);
                }
                else if (node is AssignmentNode.MinusAssignNode)
                {
                    AdditiveCompiler.CompileSubtraction(generator, type);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return new AssignItem(generator, lhs);
        }
    }
}