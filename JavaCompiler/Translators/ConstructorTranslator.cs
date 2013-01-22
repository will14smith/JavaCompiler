using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.BlockStatements;

namespace JavaCompiler.Translators
{
    class ConstructorTranslator
    {
        private readonly ITree node;
        public ConstructorTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.CONSTRUCTOR_DECL);

            this.node = node;
        }

        public Constructor Walk(Class c)
        {
            var constructor = new Constructor();

            constructor.Modifiers = new ModifierListTranslator(node.GetChild(0)).Walk();
            constructor.DeclaringType = c;

            constructor.Parameters.AddRange(new MethodParameterTranslator(node.GetChild(1)).Walk());

            constructor.Body = new ConstructorBlockTranslator(node.GetChild(2)).Walk();

            return constructor;
        }
    }
}
