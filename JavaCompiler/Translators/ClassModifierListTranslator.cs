using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Translators
{
    public class ClassModifierListTranslator
    {
        private readonly ITree node;
        public ClassModifierListTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.MODIFIER_LIST);

            this.node = node;
        }

        public ClassModifier Walk()
        {
            var modifier = ClassModifier.None;

            for (var i = 0; i < node.ChildCount; i++)
            {
                modifier |= ConvertNode(node.GetChild(i));
            }

            return modifier;
        }

        private static ClassModifier ConvertNode(ITree node)
        {
            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.PUBLIC:
                    return ClassModifier.Public;
                case JavaNodeType.FINAL:
                    return ClassModifier.Final;
                case JavaNodeType.SUPER:
                    return ClassModifier.Super;
                case JavaNodeType.INTERFACE:
                    return ClassModifier.Interface;
                case JavaNodeType.ABSTRACT:
                    return ClassModifier.Abstract;
                case JavaNodeType.AT:
                    return ClassModifier.Annotation;
                case JavaNodeType.ENUM:
                    return ClassModifier.Enum;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
