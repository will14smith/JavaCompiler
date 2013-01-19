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
            var typeRef = new PlaceholderClass { Name = ProcessName(node.GetChild(0)) };

            if (node.ChildCount > 1)
            {
                //TODO: typeRef.PlaceholderArray = ProcessArray(node.GetChild(1));
            }

            return typeRef;
        }

        private static string ProcessName(ITree node)
        {
            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.QUALIFIED_TYPE_IDENT:
                    return ProcessQualified(node);
                case JavaNodeType.BOOLEAN:
                    return "boolean";
                case JavaNodeType.CHAR:
                    return "char";
                case JavaNodeType.BYTE:
                    return "byte";
                case JavaNodeType.SHORT:
                    return "short";
                case JavaNodeType.INT:
                    return "int";
                case JavaNodeType.LONG:
                    return "long";
                case JavaNodeType.FLOAT:
                    return "float";
                case JavaNodeType.DOUBLE:
                    return "double";
                default:
                    throw new NotImplementedException();
            }
        }
        private static string ProcessQualified(ITree node)
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

            return type;
        }

        public static int ProcessArray(ITree node)
        {
            if (node == null) return 0;

            Debug.Assert(node.Type == (int)JavaNodeType.ARRAY_DECLARATOR_LIST);

            return node.ChildCount;
        }
    }
}
