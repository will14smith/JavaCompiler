using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
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
            var lType = new TranslationCompiler(node.LeftChild).GetType(generator, false);
            var rType = new TranslationCompiler(node.RightChild).GetType(generator, false);

            var type = lType.FindCommonType(rType);

            var lhs = new TranslationCompiler(node.LeftChild, type).Compile(generator);
            var rhs = new TranslationCompiler(node.RightChild, type).Compile(generator);

            lhs.Load();
            rhs.Load();

            if ((!lhs.Type.Primitive || !rhs.Type.Primitive) && (lhs.Type.Primitive || rhs.Type.Primitive))
            {
                throw new InvalidOperationException();
            }

            OpCodeValue opcode;
            if (node is EqualityNode.EqualityEqualNode)
            {
                if (type.Primitive)
                {
                    opcode = OpCodeValue.if_icmpeq;
                }
                else
                {
                    opcode = OpCodeValue.if_acmpeq;
                }
            }
            else if (node is EqualityNode.EqualityNotEqualNode)
            {
                opcode = type.Primitive ? OpCodeValue.if_icmpne : OpCodeValue.if_acmpne;
            }
            else
            {
                throw new NotImplementedException();
            }

            return new ConditionalItem(generator, opcode);
        }
    }
}