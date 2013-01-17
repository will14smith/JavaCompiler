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

        public IEnumerable<JavaParameter> Walk()
        {
            for (var i = 0; i < node.ChildCount; i++)
            {
                yield return ConvertNode(node.GetChild(i));
            }
        }

        private static JavaParameter ConvertNode(ITree node)
        {
            var parameter = new JavaParameter();

            // modifiers
            parameter.Modifiers.Clear();
            parameter.Modifiers.AddRange(new LocalModifierListTranslator(node.GetChild(0)).Walk());

            // type
            parameter.Type = new TypeTranslator(node.GetChild(1)).Walk();

            // name
            parameter.Name = new IdentifierTranslator(node.GetChild(2)).Walk();

            return parameter;
        }
    }
}
