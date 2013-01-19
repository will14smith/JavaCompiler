using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Utilities;

namespace JavaCompiler.Translators.Methods.BlockStatements
{
    class VarDeclarationTranslator
    {
        private readonly ITree node;
        public VarDeclarationTranslator(ITree node)
        {
            Debug.Assert(node.IsVarDeclaration());

            this.node = node;
        }


        public VarDeclarationNode Walk()
        {
            var varDecl = new VarDeclarationNode();

            // TODO

            // (local?)modiferList
            // type
            // declaratorList

            return varDecl;
        }
    }
}
