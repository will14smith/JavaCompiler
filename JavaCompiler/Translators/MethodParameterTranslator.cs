using System.Collections.Generic;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators
{
    class MethodParameterTranslator
    {
        private readonly ITree node;
        public MethodParameterTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.FORMAL_PARAM_LIST);

            this.node = node;
        }

        public IEnumerable<Method.Parameter> Walk()
        {
            for (var i = 0; i < node.ChildCount; i++)
            {
                var child = node.GetChild(i);

                yield return ConvertNode(child);
            }
        }

        private static Method.Parameter ConvertNode(ITree node)
        {
            var parameter = new Method.Parameter();

            // modifiers
            parameter.Modifiers.AddRange(new LocalModifierListTranslator(node.GetChild(0)).Walk());

            // type
            parameter.Type = new TypeTranslator(node.GetChild(1)).Walk();

            // name
            parameter.Name = new IdentifierTranslator(node.GetChild(2)).Walk();

            return parameter;
        }
    }
}
