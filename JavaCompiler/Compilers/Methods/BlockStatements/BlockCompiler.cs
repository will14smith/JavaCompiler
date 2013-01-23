using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;

namespace JavaCompiler.Compilers.Methods.BlockStatements
{
    public class BlockCompiler
    {
        private readonly MethodTree tree;

        public BlockCompiler(MethodTree tree)
        {
            this.tree = tree;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            foreach (MethodTreeNode node in tree)
            {
                if (node is StatementNode)
                {
                    new StatementCompiler(node as StatementNode).Compile(generator);
                }
                else if (node is VarDeclarationNode)
                {
                    new VarDeclarationCompiler(node as VarDeclarationNode).Compile(generator);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}