using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree.Expressions;

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
            var lType = new TranslationCompiler(node.LeftChild).GetType(generator, false);
            var rType = new TranslationCompiler(node.RightChild).GetType(generator, false);

            var type = lType.FindCommonType(rType);

            if (!type.Primitive)
            {
                throw new InvalidOperationException();
            }

            new TranslationCompiler(node.LeftChild, type).Compile(generator).Load();
            new TranslationCompiler(node.RightChild, type).Compile(generator).Load();
            
            OpCodeValue opcode;
            if (node is RelationNode.LessThanEqNode)
            {
                opcode = OpCodeValue.if_icmple;
            }
            else if (node is RelationNode.GreaterThanEqNode)
            {
                opcode = OpCodeValue.if_icmpge;
            }
            else if (node is RelationNode.LessThanNode)
            {
                opcode = OpCodeValue.if_icmplt;
            }
            else if (node is RelationNode.GreaterThanNode)
            {
                opcode = OpCodeValue.if_icmpgt;
            }
            else
            {
                throw new NotImplementedException();
            }

            return new ConditionalItem(generator, opcode);
        }
    }
}