using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.BlockStatements;

namespace JavaCompiler.Translators
{
    class FieldDeclarationTranslator
    {
        private readonly ITree node;
        public FieldDeclarationTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.VAR_DECLARATION);

            this.node = node;
        }

        public List<Field> Walk(Class c)
        {
            var varDeclarations = new VarDeclarationTranslator(node).Walk();

            // TODO: Field initialization

            return varDeclarations.Select(declaration =>
                new Field
                {
                    Name = declaration.Name,
                    DeclaringType = c,
                    Type = declaration.Type,
                    Modifiers = declaration.Modifiers
                }).ToList();
        }

    }
}
