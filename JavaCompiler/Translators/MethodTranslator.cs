using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators
{
    class MethodTranslator
    {
        private JavaMethod method;

        private readonly ITree node;
        public MethodTranslator(ITree node)
        {
            Debug.Assert(
                node.Type == (int)JavaNodeType.VOID_METHOD_DECL ||
                node.Type == (int)JavaNodeType.FUNCTION_METHOD_DECL);

            this.node = node;
        }

        public JavaMethod Walk()
        {
            method = new JavaMethod();

            // modifiers
            method.Modifiers.Clear();
            method.Modifiers.AddRange(new ModifierListTranslator(node.GetChild(0)).Walk());

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
                method.ReturnType = "void";
            }

            // name
            method.Name = new IdentifierTranslator(child).Walk();
            child = node.GetChild(i++);

            // parameters
            method.Parameters.Clear();
            method.Parameters.AddRange(new MethodParameterTranslator(child).Walk());
            child = node.GetChild(i++);

            // arrayDeclaratorList
            if (child.Type == (int)JavaNodeType.ARRAY_DECLARATOR_LIST)
            {
                method.ArrayLevels = TypeTranslator.ProcessArray(child);

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
