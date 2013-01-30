using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class UnaryOtherCompiler
    {
        private readonly UnaryOtherNode node;

        public UnaryOtherCompiler(UnaryOtherNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            if (node is UnaryOtherNode.UnaryCastNode)
            {
                var cast = node as UnaryOtherNode.UnaryCastNode;
                var type = ClassLocator.Find(cast.Type, generator.Manager.Imports);

                return new TranslationCompiler(cast.Expression, type).Compile(generator).Load();
            }
            if (node is UnaryOtherNode.UnaryNotNode)
            {
                var not = node as UnaryOtherNode.UnaryNotNode;

                var item = new TranslationCompiler(not.Expression, PrimativeTypes.Boolean).Compile(generator).Conditional();

                return item.Negate();
            }

            throw new NotImplementedException();
        }
    }
}