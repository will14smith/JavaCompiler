using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators
{
    public class TypeDeclarationTranslator
    {
        private readonly ITree node;
        public TypeDeclarationTranslator(ITree node)
        {
            Debug.Assert(
                node.Type == (int)JavaNodeType.CLASS ||
                node.Type == (int)JavaNodeType.INTERFACE ||
                node.Type == (int)JavaNodeType.ENUM ||
                node.Type == (int)JavaNodeType.AT );

            this.node = node;
        }

        public JavaType Walk()
        {
            switch((JavaNodeType)node.Type)
            {
                case JavaNodeType.CLASS:
                    return new ClassTranslator(node).Walk();
                case JavaNodeType.INTERFACE:
                    throw new NotImplementedException();
                case JavaNodeType.ENUM:
                    throw new NotImplementedException();
                case JavaNodeType.AT:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException("Unimplemented node type: " + node.Type);
            }
        }
    }
}
