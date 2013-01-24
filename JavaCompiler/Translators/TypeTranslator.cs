using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using Array = JavaCompiler.Reflection.Types.Array;
using Type = JavaCompiler.Reflection.Types.Type;

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

        public Type Walk()
        {
            var typeRef = ProcessClass(node.GetChild(0));

            if (node.ChildCount > 1)
            {
                var arrayLevels = ProcessArray(node.GetChild(1));

                for (var i = 0; i < arrayLevels; i++)
                {
                    typeRef = new Array(typeRef);
                }
            }

            return typeRef;
        }

        private static Type ProcessClass(ITree node)
        {
            switch ((JavaNodeType)node.Type)
            {
                case JavaNodeType.QUALIFIED_TYPE_IDENT:
                    return ProcessQualified(node);
                case JavaNodeType.BOOLEAN:
                    return PrimativeTypes.Boolean;
                case JavaNodeType.CHAR:
                    return PrimativeTypes.Char;
                case JavaNodeType.BYTE:
                    return PrimativeTypes.Byte;
                case JavaNodeType.SHORT:
                    return PrimativeTypes.Short;
                case JavaNodeType.INT:
                    return PrimativeTypes.Int;
                case JavaNodeType.LONG:
                    return PrimativeTypes.Long;
                case JavaNodeType.FLOAT:
                    return PrimativeTypes.Float;
                case JavaNodeType.DOUBLE:
                    return PrimativeTypes.Double;
                default:
                    throw new NotImplementedException();
            }
        }

        private static Class ProcessQualified(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.QUALIFIED_TYPE_IDENT);

            string type = "";
            for (int i = 0; i < node.ChildCount; i++)
            {
                if (i != 0)
                {
                    type += ".";
                }

                type += node.GetChild(i).Text;
            }

            return new PlaceholderType { Name = type };
        }

        public static int ProcessArray(ITree node)
        {
            if (node == null) return 0;

            Debug.Assert(node.Type == (int)JavaNodeType.ARRAY_DECLARATOR_LIST);

            return node.ChildCount;
        }
    }
}