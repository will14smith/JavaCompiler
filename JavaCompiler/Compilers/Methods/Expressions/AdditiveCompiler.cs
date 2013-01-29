﻿using System;
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
            generator.Kill();
            var lhs = new ExpressionCompiler(node.LeftChild).Compile(generator);
            var rhs = new ExpressionCompiler(node.RightChild).Compile(generator);
            generator.Revive();

            if (lhs.Type.Primitive && rhs.Type.Primitive)
            {
                lhs = new ExpressionCompiler(node.LeftChild).Compile(generator);
                rhs = new ExpressionCompiler(node.RightChild).Compile(generator);

                var resultType = lhs.Type.FindCommonType(rhs.Type);

                lhs.Coerce(resultType).Load();
                rhs.Coerce(resultType).Load();

                if (node is AdditiveNode.AdditivePlusNode)
                {
                    CompileAddition(generator, resultType);
                }
                else
                {
                    CompileSubtraction(generator, resultType);
                }

                return new StackItem(generator, resultType);
            }

            // string addition
            return CompileString(generator);
        }

        private static void CompileAddition(ByteCodeGenerator generator, Type type)
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
        private static void CompileSubtraction(ByteCodeGenerator generator, Type type)
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

            var items = GetItems(generator, node.LeftChild)
                .Concat(GetItems(generator, node.RightChild));

            MakeStringBuffer(generator, sb);
            AppendStrings(generator, sb, items);
            BufferToString(generator, sb);

            return new StackItem(generator, new PlaceholderType { Name = "java.lang.String" });
        }

        private static IEnumerable<Item> GetItems(ByteCodeGenerator generator, ExpressionNode node)
        {
            var addNode = node as AdditiveNode;
            if (addNode != null)
            {
                return GetItems(generator, addNode.LeftChild)
                    .Concat(GetItems(generator, addNode.RightChild));
            }

            return new[] { new ExpressionCompiler(node).Compile(generator) };
        }

        private static void MakeStringBuffer(ByteCodeGenerator generator, Class sb)
        {
            var sbInit = (Method)sb.Constructors.First(x => x.Parameters.Count == 0);

            var sbIndex = generator.Manager.AddConstantClass(sb);

            generator.EmitNew(sbIndex, sb);
            generator.Emit(OpCodeValue.dup);

            new MemberItem(generator, sbInit, true).Invoke();
        }
        private static void AppendStrings(ByteCodeGenerator generator, DefinedType sb, IEnumerable<Item> items)
        {
            var append = new Func<Type, Method>(t => sb.Methods.FirstOrDefault(
                          x => x.Name == "append" && x.Parameters.Count == 1 && x.Parameters[0].Type.CanAssignFrom(t)));

            foreach (var item in items)
            {
                var appendMethod = append(item.Type);
                if (appendMethod == null) throw new InvalidOperationException();

                item.Load();
                new MemberItem(generator, appendMethod, false).Invoke();
            }
        }
        private static void BufferToString(ByteCodeGenerator generator, DefinedType sb)
        {
            var toString = sb.Methods.SingleOrDefault(x => x.Name == "toString" && x.Parameters.Count == 0);
            if (toString == null) throw new InvalidOperationException();

            new MemberItem(generator, toString, false).Invoke();
        }
    }
}