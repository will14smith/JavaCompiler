using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    class TranslationCompiler
    {
        private readonly ExpressionNode expression;
        private readonly Type type;

        public TranslationCompiler(TranslateNode node)
        {
            expression = node.Child;
        }
        public TranslationCompiler(TranslateNode node, Type type)
        {
            expression = node.Child;
            this.type = type;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            var item = new ExpressionCompiler(expression).Compile(generator);

            if (type == null) return item;


            if (item.Type.IsAssignableTo(type))
            {
                return item;
            }

            if (item.Type.Primitive && !type.Primitive)
            {
                // box!
                var primative = item.Type as PrimativeTypes.PrimativeType;

                return primative.Box(generator, item, type as DefinedType);
            }
            if (!item.Type.Primitive && type.Primitive)
            {
                // unbox!
                var primative = type as PrimativeTypes.PrimativeType;

                return primative.Unbox(generator, item);
            }

            throw new InvalidOperationException();
        }

        public Type GetType(ByteCodeGenerator generator, bool boxing)
        {
            generator.Kill();

            var item = new ExpressionCompiler(expression).Compile(generator);

            var type = item.Type;

            if (boxing && type.Primitive)
            {
                // try boxing
                var primative = type as PrimativeTypes.PrimativeType;

                type = primative.Box(generator, item).Type;
            }
            else if (!boxing && !type.Primitive)
            {
                // try to unbox
                type = PrimativeTypes.UnboxType(type);
            }

            generator.Revive();

            return type;
        }
    }
}
