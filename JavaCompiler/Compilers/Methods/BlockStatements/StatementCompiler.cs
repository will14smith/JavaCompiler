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

        public void Compile(ByteCodeGenerator generator)
        {
            Item item = null;

            if (node is MethodTree)
            {
                new BlockCompiler(node as MethodTree).Compile(generator);
            }
            else if (node is ExpressionNode)
            {
                item = new ExpressionCompiler(node as ExpressionNode).Compile(generator);
            }
            else if (node is AssertNode)
            {
                item = new AssertCompiler(node as AssertNode).Compile(generator);
            }
            else if (node is IfNode)
            {
                item = new IfCompiler(node as IfNode).Compile(generator);
            }
            else if (node is ForNode)
            {
                item = new ForCompiler(node as ForNode).Compile(generator);
            }
            else if (node is ForEachNode)
            {
                item = new ForEachCompiler(node as ForEachNode).Compile(generator);
            }
            else if (node is WhileNode)
            {
                item = new WhileCompiler(node as WhileNode).Compile(generator);
            }
            else if (node is DoNode)
            {
                item = new DoCompiler(node as DoNode).Compile(generator);
            }
            else if (node is TryNode)
            {
                item = new TryCompiler(node as TryNode).Compile(generator);
            }
            else if (node is SwitchNode)
            {
                item = new SwitchCompiler(node as SwitchNode).Compile(generator);
            }
            else if (node is SynchronizedNode)
            {
                item = new SynchronizedCompiler(node as SynchronizedNode).Compile(generator);
            }
            else if (node is ReturnNode)
            {
                item = new ReturnCompiler(node as ReturnNode).Compile(generator);
            }
            else if (node is ThrowNode)
            {
                item = new ThrowCompiler(node as ThrowNode).Compile(generator);
            }
            else if (node is BreakNode)
            {
                item = new BreakCompiler(node as BreakNode).Compile(generator);
            }
            else if (node is ContinueNode)
            {
                item = new ContinueCompiler(node as ContinueNode).Compile(generator);
            }
            else if (node is LabelNode)
            {
                item = new LabelCompiler(node as LabelNode).Compile(generator);
            }
            else
            {
                throw new NotImplementedException();
            }

            if (item != null)
            {
                item.Drop();
            }
        }
    }
}