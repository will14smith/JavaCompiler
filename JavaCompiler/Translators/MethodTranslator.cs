using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Translators.Methods;
using JavaCompiler.Translators.Methods.BlockStatements;

namespace JavaCompiler.Translators
{
    public class MethodTranslator
    {
        private Method method;

        private readonly ITree node;
        public MethodTranslator(ITree node)
        {
            Debug.Assert(
                node.Type == (int)JavaNodeType.VOID_METHOD_DECL ||
                node.Type == (int)JavaNodeType.FUNCTION_METHOD_DECL);

            this.node = node;
        }

        public Method Walk(Class c)
        {
            method = new Method();

            // modifiers
            method.Modifiers = new ModifierListTranslator(node.GetChild(0)).Walk();
            method.DeclaringType = c;

            var i = 1;
            var child = node.GetChild(i++);

            // generic
            if (child.Type == (int)JavaNodeType.GENERIC_TYPE_PARAM_LIST)
            {
                child = node.GetChild(i++);
            }

            // type
            if (child.Type == (int)JavaNodeType.TYPE)
            {
                method.ReturnType = new TypeTranslator(child).Walk();

                child = node.GetChild(i++);
            }
            else
            {
                method.ReturnType = PrimativeTypes.Void;
            }

            // name
            method.Name = new IdentifierTranslator(child).Walk();
            child = node.GetChild(i++);

            // parameters
            method.Parameters.AddRange(new MethodParameterTranslator(child).Walk());
            child = node.GetChild(i++);

            // arrayDeclaratorList
            if (child.Type == (int)JavaNodeType.ARRAY_DECLARATOR_LIST)
            {
                //TODO; method.ArrayLevels = TypeTranslator.ProcessArray(child);

                child = node.GetChild(i++);
            }

            // throws
            if (child.Type == (int)JavaNodeType.THROWS_CLAUSE)
            {
                child = node.GetChild(i);
            }

            // body?
            if (child.Type == (int)JavaNodeType.BLOCK_SCOPE)
            {
                method.Body = new BlockTranslator(child).Walk();
            }

            return method;
        }
    }
}
