using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators
{
    public class LocalModifierListTranslator
    {
        private readonly ITree node;
        public LocalModifierListTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.LOCAL_MODIFIER_LIST);

            this.node = node;
        }

        public IEnumerable<JavaLocalModifier> Walk()
        {
            for (var i = 0; i < node.ChildCount; i++)
            {
                yield return ConvertNode(node.GetChild(i));
            }
        }

        private static JavaLocalModifier ConvertNode(ITree node)
        {
            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.FINAL:
                    return JavaLocalModifier.FINAL;
                case JavaNodeType.AT:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
