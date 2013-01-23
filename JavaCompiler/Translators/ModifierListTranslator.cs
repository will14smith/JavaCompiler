using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Translators
{
    public class ModifierListTranslator
    {
        private readonly ITree node;

        public ModifierListTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int) JavaNodeType.MODIFIER_LIST);

            this.node = node;
        }

        public Modifier Walk()
        {
            var modifier = Modifier.None;

            for (int i = 0; i < node.ChildCount; i++)
            {
                modifier |= ConvertNode(node.GetChild(i));
            }

            return modifier;
        }

        private static Modifier ConvertNode(ITree node)
        {
            switch ((JavaNodeType) node.Type)
            {
                case JavaNodeType.PUBLIC:
                    return Modifier.Public;
                case JavaNodeType.PROTECTED:
                    return Modifier.Protected;
                case JavaNodeType.PRIVATE:
                    return Modifier.Private;
                case JavaNodeType.STATIC:
                    return Modifier.Static;
                case JavaNodeType.ABSTRACT:
                    return Modifier.Abstract;
                case JavaNodeType.NATIVE:
                    return Modifier.Native;
                case JavaNodeType.SYNCHRONIZED:
                    return Modifier.Syncronized;
                case JavaNodeType.TRANSIENT:
                    return Modifier.Transient;
                case JavaNodeType.VOLATILE:
                    return Modifier.Volatile;
                case JavaNodeType.STRICTFP:
                    return Modifier.Strict;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}