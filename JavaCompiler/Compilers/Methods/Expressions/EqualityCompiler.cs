using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class EqualityCompiler
    {
        private readonly EqualityNode node;

        public EqualityCompiler(EqualityNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            var lhs = new ExpressionCompiler(node.LeftChild).Compile(generator);
            var rhs = new ExpressionCompiler(node.RightChild).Compile(generator);

            lhs.Load();
            rhs.Load();

            if ((!lhs.Type.Primitive || !rhs.Type.Primitive) && (lhs.Type.Primitive || rhs.Type.Primitive))
            {
                throw new InvalidOperationException();
            }

            OpCode opcode;
            if (node is EqualityNode.EqualityEqualNode)
            {
                if (lhs.Type.Primitive && rhs.Type.Primitive)
                {
                    opcode = OpCodes.if_icmpeq;
                }
                else
                {
                    opcode = OpCodes.if_acmpeq;
                }
            }
            else if (node is EqualityNode.EqualityNotEqualNode)
            {
                if (lhs.Type.Primitive && rhs.Type.Primitive)
                {
                    opcode = OpCodes.if_icmpne;
                }
                else
                {
                    opcode = OpCodes.if_acmpne;
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            return new ConditionalItem(generator, opcode);
        }
    }
}