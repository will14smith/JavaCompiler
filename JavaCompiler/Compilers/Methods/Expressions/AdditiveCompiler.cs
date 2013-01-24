using System;
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
            var lhs = new ExpressionCompiler(node.LeftChild).Compile(generator);
            var rhs = new ExpressionCompiler(node.RightChild).Compile(generator);

            if (lhs.Type.Primitive && rhs.Type.Primitive)
            {
                var resultType = lhs.Type.FindCommonType(rhs.Type);

                lhs.Coerce(resultType).Load();
                rhs.Coerce(resultType).Load();

                CompileAddition(generator, resultType);

                return new StackItem(generator, resultType);
            }

            // string addition
            return CompileString(generator, lhs, rhs);
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
                    throw new NotImplementedException();
            }
        }
        private Item CompileString(ByteCodeGenerator generator, Item lhs, Item rhs)
        {
            var sb = ClassLocator.Find(new PlaceholderType { Name = "java.lang.StringBuilder" }, generator.Manager.Imports) as Class;
            if (sb == null) throw new InvalidOperationException();

            MakeStringBuffer(generator, sb);
            AppendStrings(generator, sb, lhs, rhs);
            BufferToString(generator, sb);

            return new StackItem(generator, new PlaceholderType { Name = "java.lang.String" });
        }

        private void MakeStringBuffer(ByteCodeGenerator generator, Class sb)
        {
            var sbInit = (Method)sb.Constructors.First(x => x.Parameters.Count == 0);

            var sbIndex = generator.Manager.AddConstantClass(sb);

            generator.EmitNew(sbIndex, sb);
            generator.Emit(OpCodeValue.dup);

            new MemberItem(generator, sbInit, true).Invoke();
        }
        private void AppendStrings(ByteCodeGenerator generator, DefinedType sb, params Item[] items)
        {
            var append = new Func<Type, Method>(t => sb.Methods.FirstOrDefault(
                          x => x.Name == "append" && x.Parameters.Count == 1 && x.Parameters[0].Type.GetDescriptor() == t.GetDescriptor()));

            foreach(var item in items)
            {
                var appendMethod = append(item.Type);
                if(appendMethod == null) throw new InvalidOperationException();
                
                item.Load();
                new MemberItem(generator, appendMethod, false).Invoke();
            }
        }
        private void BufferToString(ByteCodeGenerator generator, DefinedType sb)
        {
            var toString = sb.Methods.SingleOrDefault(x => x.Name == "toString" && x.Parameters.Count == 0);
            if (toString == null) throw new InvalidOperationException();

            new MemberItem(generator, toString, false).Invoke();
        }
    }
}