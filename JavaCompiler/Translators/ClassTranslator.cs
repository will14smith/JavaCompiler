using System;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Translators
{
    public class ClassTranslator
    {
        private readonly ITree node;
        private Class @class;

        public ClassTranslator(ITree node)
        {
            Debug.Assert(node.Type == (int) JavaNodeType.CLASS);

            this.node = node;
        }

        public Class Walk()
        {
            @class = new Class
                         {
                             Modifiers = new ClassModifierListTranslator(node.GetChild(0)).Walk(),
                             Name = new IdentifierTranslator(node.GetChild(1)).Walk()
                         };

            int i = 2;
            ITree child = node.GetChild(i++);

            if ((JavaNodeType) child.Type == JavaNodeType.GENERIC_TYPE_PARAM_LIST)
            {
                child = node.GetChild(i++);
            }

            if ((JavaNodeType) child.Type == JavaNodeType.EXTENDS_CLAUSE)
            {
                @class.Super = new TypeTranslator(child.GetChild(0)).Walk() as Class;

                child = node.GetChild(i++);
            }
            else
            {
                @class.Super = new PlaceholderType {Name = "java.lang.Object"};
            }

            if ((JavaNodeType) child.Type == JavaNodeType.IMPLEMENTS_CLAUSE)
            {
                child = node.GetChild(i);
            }

            ITree body = child;

            WalkBody(body);

            if (@class.Constructors.Count == 0)
            {
                @class.Constructors.Add(new Constructor {DeclaringType = @class, Body = new MethodTree()});
            }

            return @class;
        }

        public void WalkBody(ITree body)
        {
            Debug.Assert(body.Type == (int) JavaNodeType.CLASS_TOP_LEVEL_SCOPE);

            for (int i = 0; i < body.ChildCount; i++)
            {
                ITree child = body.GetChild(i);

                switch ((JavaNodeType) child.Type)
                {
                    case JavaNodeType.CLASS_INSTANCE_INITIALIZER:
                        throw new NotImplementedException();
                    case JavaNodeType.CLASS_STATIC_INITIALIZER:
                        throw new NotImplementedException();
                    case JavaNodeType.FUNCTION_METHOD_DECL:
                    case JavaNodeType.VOID_METHOD_DECL:
                        @class.Methods.Add(new MethodTranslator(child).Walk(@class));
                        break;
                    case JavaNodeType.CONSTRUCTOR_DECL:
                        @class.Constructors.Add(new ConstructorTranslator(child).Walk(@class));
                        break;
                    case JavaNodeType.VAR_DECLARATION:
                        @class.Fields.AddRange(new FieldDeclarationTranslator(child).Walk(@class));
                        break;
                    case JavaNodeType.CLASS:
                    case JavaNodeType.INTERFACE:
                    case JavaNodeType.ENUM:
                    case JavaNodeType.AT:
                        DefinedType type = new TypeDeclarationTranslator(child).Walk();

                        @class.Types.Add(type);
                        break;
                    default:
                        throw new NotImplementedException("Unimplemented node type: " + node.Type);
                }
            }
        }
    }
}