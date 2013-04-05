using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class RelationCompiler
    {
        private readonly RelationNode node;

        public RelationCompiler(RelationNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            var type = node.GetType(generator);

            if (!type.Primitive)
            {
                throw new InvalidOperationException();
            }

            new TranslationCompiler(node.LeftChild, type).Compile(generator).Load();
            new TranslationCompiler(node.RightChild, type).Compile(generator).Load();

            OpCodeValue opcode = CompileRelation(generator, type);


            return new ConditionalItem(generator, opcode);
        }

        private OpCodeValue CompileRelation(ByteCodeGenerator generator, Type type)
        {
            switch (TypeCodeHelper.Truncate(type))
            {
                case ItemTypeCode.Int:
                    return CompileInt(generator);
                case ItemTypeCode.Long:
                    CompileLong(generator);
                    break;
                case ItemTypeCode.Float:
                    CompileFloat(generator);
                    break;
                case ItemTypeCode.Double:
                    CompileDouble(generator);
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (node is RelationNode.LessThanEqNode)
            {
                return OpCodeValue.ifle;
            }
            if (node is RelationNode.GreaterThanEqNode)
            {
                return OpCodeValue.ifge;
            }
            if (node is RelationNode.LessThanNode)
            {
                return OpCodeValue.iflt;
            }
            if (node is RelationNode.GreaterThanNode)
            {
                return OpCodeValue.ifgt;
            }

            throw new NotImplementedException();
        }

        private OpCodeValue CompileInt(ByteCodeGenerator generator)
        {
            if (node is RelationNode.LessThanEqNode)
            {
                return OpCodeValue.if_icmple;
            }
            if (node is RelationNode.GreaterThanEqNode)
            {
                return OpCodeValue.if_icmpge;
            }
            if (node is RelationNode.LessThanNode)
            {
                return OpCodeValue.if_icmplt;
            }
            if (node is RelationNode.GreaterThanNode)
            {
                return OpCodeValue.if_icmpgt;
            }
            throw new NotImplementedException();
        }

        private void CompileLong(ByteCodeGenerator generator)
        {
            generator.Emit(OpCodeValue.lcmp);
        }
        private void CompileFloat(ByteCodeGenerator generator)
        {
            generator.Emit(OpCodeValue.fcmpl);
        }
        private void CompileDouble(ByteCodeGenerator generator)
        {
            generator.Emit(OpCodeValue.dcmpl);
        }
    }
}