using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Compilers.Methods.Statements;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Translators.Methods.Tree.Statements;

namespace JavaCompiler.Compilers.Methods.BlockStatements
{
    public class StatementCompiler
    {
        private readonly MethodTreeNode node;

        public StatementCompiler(MethodTreeNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            if (node is MethodTree)
            {
                new BlockCompiler(node as MethodTree).Compile(generator);

                return new VoidItem(generator);
            }
            if (node is ExpressionNode)
            {
                return new ExpressionCompiler(node as ExpressionNode).Compile(generator);
            }
            if (node is AssertNode)
            {
                return new AssertCompiler(node as AssertNode).Compile(generator);
            }
            if (node is IfNode)
            {
                return new IfCompiler(node as IfNode).Compile(generator);
            }
            if (node is ForNode)
            {
                return new ForCompiler(node as ForNode).Compile(generator);
            }
            if (node is ForEachNode)
            {
                return new ForEachCompiler(node as ForEachNode).Compile(generator);
            }
            if (node is WhileNode)
            {
                return new WhileCompiler(node as WhileNode).Compile(generator);
            }
            if (node is DoNode)
            {
                return new DoCompiler(node as DoNode).Compile(generator);
            }
            if (node is TryNode)
            {
                return new TryCompiler(node as TryNode).Compile(generator);
            }
            if (node is SwitchNode)
            {
                return new SwitchCompiler(node as SwitchNode).Compile(generator);
            }
            if (node is SynchronizedNode)
            {
                return new SynchronizedCompiler(node as SynchronizedNode).Compile(generator);
            }
            if (node is ReturnNode)
            {
                return new ReturnCompiler(node as ReturnNode).Compile(generator);
            }
            if (node is ThrowNode)
            {
                return new ThrowCompiler(node as ThrowNode).Compile(generator);
            }
            if (node is BreakNode)
            {
                return new BreakCompiler(node as BreakNode).Compile(generator);
            }
            if (node is ContinueNode)
            {
                return new ContinueCompiler(node as ContinueNode).Compile(generator);
            }
            if (node is LabelNode)
            {
                return new LabelCompiler(node as LabelNode).Compile(generator);
            }

            throw new NotImplementedException();
        }
    }
}