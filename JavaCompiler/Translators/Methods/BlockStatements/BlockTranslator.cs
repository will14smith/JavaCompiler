using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;
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

            for (var i = 0; i < node.ChildCount; i++)
            {
                var child = node.GetChild(i);

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
                    var decls = new VarDeclarationTranslator(child).Walk();

                    foreach (var decl in decls)
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
