using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.BlockStatements
{
    class BlockTranslator
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
                    method.Add(new VarDeclarationTranslator(child).Walk());
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
