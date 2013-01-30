using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilers.Items
{
    public class ConditionalItem : Item
    {
        public OpCodeValue OpCode { get; private set; }

        public Label TrueLabel { get; private set; }
        public Label FalseLabel { get; private set; }

        public ConditionalItem(ByteCodeGenerator generator, OpCodeValue opCode)
            : this(generator, opCode, null, null)
        {
            OpCode = opCode;
        }
        public ConditionalItem(ByteCodeGenerator generator, OpCodeValue opCode, Label trueLabel, Label falseLabel)
            : base(generator, PrimativeTypes.Boolean)
        {
            OpCode = opCode;

            TrueLabel = trueLabel;
            FalseLabel = falseLabel;
        }

        public override Item Load()
        {
            Label trueChain = null;
            Label falseChain = JumpFalse();
            if (!IsFalse())
            {
                Generator.MarkLabel(TrueLabel);
                Generator.Emit(OpCodeValue.iconst_1);

                trueChain = Generator.DefineLabel();
            }
            if (falseChain != null)
            {
                Generator.MarkLabel(falseChain);
                Generator.Emit(OpCodeValue.iconst_0);
            }

            Generator.MarkLabel(trueChain);

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

        public Label JumpTrue()
        {
            var label = Generator.DefineLabel();

            Generator.Emit(OpCode, label);

            return label;
        }
        public Label JumpFalse()
        {
            var label = Generator.DefineLabel();

            Generator.Emit(OpCodes.Negate(OpCode), label);

            return label;
        }

        public ConditionalItem Negate()
        {
            var c = new ConditionalItem(Generator, OpCodes.Negate(OpCode), FalseLabel, TrueLabel);
            return c;
        }

        public override int Width()
        {
            // a ConditionalItem doesn't have a size on the stack per se.
            throw new InvalidOperationException();
        }

        private bool IsTrue()
        {
            return FalseLabel == null && OpCode == OpCodeValue.@goto;
        }
        private bool IsFalse()
        {
            return TrueLabel == null && OpCode == OpCodeValue.jsr;
        }

        public new String ToString()
        {
            return "cond(" + OpCode + ")";
        }
    }
}
