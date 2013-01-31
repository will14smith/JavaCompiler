using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilers.Items
{
    public class ConditionalItem : Item
    {
        public OpCodeValue OpCode { get; private set; }

        public Chain TrueJumps { get; private set; }
        public Chain FalseJumps { get; private set; }

        public ConditionalItem(ByteCodeGenerator generator, OpCodeValue opCode)
            : this(generator, opCode, null, null)
        {
            OpCode = opCode;
        }
        public ConditionalItem(ByteCodeGenerator generator, OpCodeValue opCode, Chain trueChain, Chain falseChain)
            : base(generator, PrimativeTypes.Boolean)
        {
            OpCode = opCode;

            TrueJumps = trueChain;
            FalseJumps = falseChain;
        }

        public override Item Load()
        {
            Chain trueChain = null;
            Chain falseChain = JumpFalse();

            if (!IsFalse())
            {
                Generator.ResolveChain(TrueJumps);
                Generator.Emit(OpCodeValue.iconst_1);

                trueChain = Generator.Branch(OpCodeValue.@goto);
            }
            if (falseChain != null)
            {
                Generator.ResolveChain(falseChain);
                Generator.Emit(OpCodeValue.iconst_0);
            }

            Generator.ResolveChain(trueChain);

            return TypeCodeHelper.StackItem(Generator, Type);
        }

        public override void Duplicate()
        {
            Load().Duplicate();
        }
        public override void Drop()
        {
            Load().Drop();
        }

        public override void Stash(ItemTypeCode typecode)
        {
            throw new InvalidOperationException();
        }

        public override ConditionalItem Conditional()
        {
            return this;
        }

        public Chain JumpTrue()
        {
            return ByteCodeGenerator.MergeChains(TrueJumps, Generator.Branch(OpCode));
        }
        public Chain JumpFalse()
        {
            return ByteCodeGenerator.MergeChains(FalseJumps, Generator.Branch(OpCodes.Negate(OpCode)));
        }

        public ConditionalItem Negate()
        {
            var c = new ConditionalItem(Generator, OpCodes.Negate(OpCode), FalseJumps, TrueJumps);
            return c;
        }

        public override int Width()
        {
            // a ConditionalItem doesn't have a size on the stack per se.
            throw new InvalidOperationException();
        }

        private bool IsTrue()
        {
            return FalseJumps == null && OpCode == OpCodeValue.@goto;
        }

        public bool IsFalse()
        {
            return TrueJumps == null && OpCode == OpCodeValue.jsr;
        }

        public new String ToString()
        {
            return "cond(" + OpCode + ")";
        }
    }
}
