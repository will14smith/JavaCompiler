using System;
using System.Collections.Generic;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Translators
{
    public class LocalModifierListTranslator
    {
        private readonly ITree node;

        public LocalModifierListTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int) JavaNodeType.LOCAL_MODIFIER_LIST);

            this.node = node;
        }

        public IEnumerable<LocalModifier> Walk()
        {
            for (int i = 0; i < node.ChildCount; i++)
            {
                yield return ConvertNode(node.GetChild(i));
            }
        }

        private static LocalModifier ConvertNode(ITree node)
        {
            switch ((JavaNodeType) node.Type)
            {
                case JavaNodeType.FINAL:
                    return LocalModifier.Final;
                case JavaNodeType.AT:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}