using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators
{
    public class ModifierListTranslator
    {
        private readonly ITree node;
        public ModifierListTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.MODIFIER_LIST);

            this.node = node;
        }

        public IEnumerable<JavaModifier> Walk()
        {
            for (var i = 0; i < node.ChildCount; i++)
            {
                yield return ConvertNode(node.GetChild(i));
            }
        }

        private static JavaModifier ConvertNode(ITree node)
        {
            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.PUBLIC:
                    return JavaModifier.Public;
                case JavaNodeType.PROTECTED:
                    return JavaModifier.Protected;
                case JavaNodeType.PRIVATE:
                    return JavaModifier.Private;
                case JavaNodeType.STATIC:
                    return JavaModifier.Static;
                case JavaNodeType.ABSTRACT:
                    return JavaModifier.Abstract;
                case JavaNodeType.NATIVE:
                    return JavaModifier.Native;
                case JavaNodeType.SYNCHRONIZED:
                    return JavaModifier.Syncronized;
                case JavaNodeType.TRANSIENT:
                    return JavaModifier.Transient;
                case JavaNodeType.VOLATILE:
                    return JavaModifier.Volatile;
                case JavaNodeType.STRICTFP:
                    return JavaModifier.Strictfp;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
