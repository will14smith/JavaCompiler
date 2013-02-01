using System;
using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class AdditiveCompiler
    {
        private readonly AdditiveNode node;

        public AdditiveCompiler(AdditiveNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            var lType = new TranslationCompiler(node.LeftChild).GetType(generator, false);
            var rType = new TranslationCompiler(node.RightChild).GetType(generator, false);

            var type = lType.FindCommonType(rType);
            if (type != null && type.Primitive)
            {
                new TranslationCompiler(node.LeftChild, type).Compile(generator).Load();
                new TranslationCompiler(node.RightChild, type).Compile(generator).Load();

                if (node is AdditiveNode.AdditivePlusNode)
                {
                    CompileAddition(generator, type);
                }
                else
                {
                    CompileSubtraction(generator, type);
                }

                return new StackItem(generator, type);
            }

            // string addition
            return CompileString(generator);
        }

        internal static void CompileAddition(ByteCodeGenerator generator, Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    generator.Emit(OpCodeValue.iadd);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodeValue.ladd);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodeValue.fadd);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodeValue.dadd);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
        internal static void CompileSubtraction(ByteCodeGenerator generator, Type type)
        {
            var typeCode = TypeCodeHelper.Truncate(PrimativeTypes.TypeCode(type));

            switch (typeCode)
            {
                case ItemTypeCode.Int:
                    generator.Emit(OpCodeValue.isub);
                    break;
                case ItemTypeCode.Long:
                    generator.Emit(OpCodeValue.lsub);
                    break;
                case ItemTypeCode.Float:
                    generator.Emit(OpCodeValue.fsub);
                    break;
                case ItemTypeCode.Double:
                    generator.Emit(OpCodeValue.dsub);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private Item CompileString(ByteCodeGenerator generator)
        {
            var sb = ClassLocator.Find(new PlaceholderType { Name = "java.lang.StringBuilder" }, generator.Manager.Imports) as Class;
            if (sb == null) throw new InvalidOperationException();

            MakeStringBuffer(generator, sb);
            AppendStrings(generator, sb, node.LeftChild.Child);
            AppendStrings(generator, sb, node.RightChild.Child);
            BufferToString(generator, sb);

            return new StackItem(generator, new PlaceholderType { Name = "java.lang.String" });
        }

        public static void MakeStringBuffer(ByteCodeGenerator generator, Class sb)
        {
            var sbInit = (Method)sb.Constructors.First(x => x.Parameters.Count == 0);

            var sbIndex = generator.Manager.AddConstantClass(sb);

            generator.EmitNew(sbIndex, sb);
            generator.Emit(OpCodeValue.dup);

            new MemberItem(generator, sbInit, true).Invoke();
        }
        public static void AppendStrings(ByteCodeGenerator generator, DefinedType sb, ExpressionNode node)
        {
            if (node is AdditiveNode)
            {
                var addNode = node as AdditiveNode;

                generator.Kill();
                var addType = new AdditiveCompiler(addNode).Compile(generator).Type;
                generator.Revive();

                if (addType.Name == "java.lang.String")
                {
                    AppendStrings(generator, sb, addNode.LeftChild.Child);
                    AppendStrings(generator, sb, addNode.RightChild.Child);

                    return;
                }
            }

            var item = new ExpressionCompiler(node).Compile(generator);

            var appendMethod = sb.FindMethod(generator, "append", new List<Type> { item.Type });
            if (appendMethod == null) throw new InvalidOperationException();

            item.Load();
            new MemberItem(generator, appendMethod, false).Invoke();
        }
        public static void BufferToString(ByteCodeGenerator generator, DefinedType sb)
        {
            var toString = sb.FindMethod(generator, "toString", null);
            if (toString == null) throw new InvalidOperationException();

            new MemberItem(generator, toString, false).Invoke();
        }
    }
}