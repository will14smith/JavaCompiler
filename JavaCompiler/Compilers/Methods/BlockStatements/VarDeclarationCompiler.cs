﻿using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.BlockStatements
{
    public class VarDeclarationCompiler
    {
        private readonly VarDeclarationNode node;

        public VarDeclarationCompiler(VarDeclarationNode node)
        {
            this.node = node;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            var variable = generator.DefineVariable(node.Name, node.Type);

            if (node.Initialiser != null)
            {
                new AssignmentCompiler(
                    new AssignmentNode.NormalAssignNode
                    {
                        Left = new PrimaryNode.TermIdentifierExpression { Identifier = node.Name },
                        Right = new TranslateNode { Child = node.Initialiser }
                    }).Compile(generator);

                new LocalItem(generator, variable).Store();
            }
        }
    }
}