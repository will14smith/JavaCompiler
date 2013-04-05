using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;
using Array = JavaCompiler.Reflection.Types.Array;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class NewCompiler
    {
        private readonly NewNode node;

        public NewCompiler(NewNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            if (node is NewNode.NewArrayNode)
            {
                return CompileNewArray(generator, node as NewNode.NewArrayNode);
            }
            if (node is NewNode.NewClassNode)
            {
                return CompileNewClass(generator, node as NewNode.NewClassNode);
            }

            throw new NotImplementedException();
        }

        private static Item CompileNewArray(ByteCodeGenerator generator, NewNode.NewArrayNode node)
        {
            var elemType = node.GetType(generator);
            var type = node.GetType(generator);

            foreach (var expression in node.Dimensions)
            {
                new ExpressionCompiler(expression).Compile(generator).Coerce(PrimativeTypes.Int).Load();

                type = new Array(type);
            }

            var ndims = (byte)node.Dimensions.Count;

            var elemcode = TypeCodeHelper.ArrayCode((type as Array).ArrayType);
            if (elemcode == 0 || (elemcode == 1 && ndims == 1))
            {
                generator.EmitAnewarray(generator.Manager.AddConstantClass(elemType), type);
            }
            else if (elemcode == 1)
            {
                generator.EmitMultianewarray(ndims, generator.Manager.AddConstantClass(type), type);
            }
            else
            {
                generator.EmitNewarray(elemcode, type);
            }

            return new StackItem(generator, type);
        }

        private static Item CompileNewClass(ByteCodeGenerator generator, NewNode.NewClassNode node)
        {
            node.Type = ClassLocator.Find(node.GetType(generator), generator.Manager.Imports);

            generator.Emit(OpCodeValue.@new, generator.Manager.AddConstantClass(node.GetType(generator) as DefinedType));
            generator.Emit(OpCodeValue.dup);

            new PrimaryCompiler(new PrimaryNode.TermMethodExpression { Identifier = "<init>", Arguments = node.Arguments }).Compile(generator, new StackItem(generator, node.GetType(generator)));

            return new StackItem(generator, node.GetType(generator));
        }
    }
}