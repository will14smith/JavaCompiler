using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
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
            var lhs = new ExpressionCompiler(node.LeftChild).Compile(generator);
            var rhs = new ExpressionCompiler(node.RightChild).Compile(generator);

            lhs.Load();
            rhs.Load();

            if (!(lhs.Type.Primitive && rhs.Type.Primitive))
            {
                throw new InvalidOperationException();
            }

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