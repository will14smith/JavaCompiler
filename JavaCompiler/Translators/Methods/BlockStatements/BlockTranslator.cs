using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.BlockStatements
{
    public class BlockTranslator
    {
        private readonly ITree node;

        public BlockTranslator(ITree node)
        {
            Debug.Assert(node.IsBlock());

            this.node = node;
        }

        public MethodTree Walk()
        {
            var method = new MethodTree();

            for (int i = 0; i < node.ChildCount; i++)
            {
                ITree child = node.GetChild(i);

                if (child.IsStatement())
                {
                    method.Add(new StatementTranslator(child).Walk());
                }
                else if (child.IsTypeDeclaration())
                {
                    //TODO: Special Case!
                    new TypeDeclarationTranslator(child).Walk();
                }
                else if (child.IsVarDeclaration())
                {
                    List<VarDeclarationNode> decls = new VarDeclarationTranslator(child).Walk();

                    foreach (VarDeclarationNode decl in decls)
                    {
                        method.Add(decl);
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return method;
        }
    }
}