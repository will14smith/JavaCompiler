using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators
{
    public class ClassTranslator
    {
        private JavaClass @class;

        private readonly ITree node;
        public ClassTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int)JavaNodeType.CLASS);

            this.node = node;
        }

        public JavaClass Walk()
        {
            @class = new JavaClass();

            // modifiers
            @class.Modifiers.Clear();
            @class.Modifiers.AddRange(new ModifierListTranslator(node.GetChild(0)).Walk());

            // name
            @class.Name = new IdentifierTranslator(node.GetChild(1)).Walk();

            var i = 2;
            var child = node.GetChild(i++);

            if ((JavaNodeType)node.Type == JavaNodeType.GENERIC_TYPE_PARAM_LIST)
            {
                child = node.GetChild(i++);
            }

            if ((JavaNodeType)node.Type == JavaNodeType.EXTENDS_CLAUSE)
            {
                child = node.GetChild(i++);
            }

            if ((JavaNodeType)node.Type == JavaNodeType.IMPLEMENTS_CLAUSE)
            {
                child = node.GetChild(i);
            }

            var body = child;

            WalkBody(body);
            
            return @class;
        }

        public void WalkBody(ITree body)
        {
            Debug.Assert(body.Type == (int)JavaNodeType.CLASS_TOP_LEVEL_SCOPE);

            for (var i = 0; i < body.ChildCount; i++)
            {
                var child = body.GetChild(i);

                switch ((JavaNodeType)child.Type)
                {
                    case JavaNodeType.CLASS_INSTANCE_INITIALIZER:
                        throw new NotImplementedException();
                    case JavaNodeType.CLASS_STATIC_INITIALIZER:
                        throw new NotImplementedException();
                    case JavaNodeType.FUNCTION_METHOD_DECL:
                    case JavaNodeType.VOID_METHOD_DECL:
                        @class.Methods.Add(new MethodTranslator(child).Walk());
                        break;
                    case JavaNodeType.CONSTRUCTOR_DECL:
                        throw new NotImplementedException();
                    case JavaNodeType.VAR_DECLARATION:
                        @class.Fields.Add(new VarDeclaratorTranlator(child).Walk());
                        break;
                    case JavaNodeType.CLASS:
                    case JavaNodeType.INTERFACE:
                    case JavaNodeType.ENUM:
                    case JavaNodeType.AT:
                        @class.NestedTypes.Add(new TypeDeclarationTranslator(child).Walk());
                        break; 
                    default:
                        throw new NotImplementedException("Unimplemented node type: " + node.Type);
                }
            }
        }
    }
}
