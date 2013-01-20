using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Internal;

namespace JavaCompiler.Translators
{
    public class TypeTranslator
    {
        private readonly ITree node;
        public TypeTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.TYPE);

            this.node = node;
        }

        public Class Walk()
        {
            var typeRef = ProcessClass(node.GetChild(0));

            if (node.ChildCount > 1)
            {
                //TODO: typeRef.PlaceholderArray = ProcessArray(node.GetChild(1));
            }

            return typeRef;
        }

        private static Class ProcessClass(ITree node)
        {
            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.QUALIFIED_TYPE_IDENT:
                    return ProcessQualified(node);
                case JavaNodeType.BOOLEAN:
                    return PrimativeClasses.Boolean;
                case JavaNodeType.CHAR:
                    return PrimativeClasses.Char;
                case JavaNodeType.BYTE:
                    return PrimativeClasses.Byte;
                case JavaNodeType.SHORT:
                    return PrimativeClasses.Short;
                case JavaNodeType.INT:
                    return PrimativeClasses.Int;
                case JavaNodeType.LONG:
                    return PrimativeClasses.Long;
                case JavaNodeType.FLOAT:
                    return PrimativeClasses.Float;
                case JavaNodeType.DOUBLE:
                    return PrimativeClasses.Double;
                default:
                    throw new NotImplementedException();
            }
        }
        private static Class ProcessQualified(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.QUALIFIED_TYPE_IDENT);

            var type = "";
            for (var i = 0; i < node.ChildCount; i++)
            {
                if (i != 0)
                {
                    type += ".";
                }

                type += node.GetChild(i).Text;
            }

            return new PlaceholderClass { Name = type };
        }

        public static int ProcessArray(ITree node)
        {
            if (node == null) return 0;

            Debug.Assert(node.Type == (int)JavaNodeType.ARRAY_DECLARATOR_LIST);

            return node.ChildCount;
        }
    }
}
