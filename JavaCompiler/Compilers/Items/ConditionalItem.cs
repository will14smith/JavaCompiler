using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilers.Items
{
    public class ConditionalItem : Item
    {
        public OpCode OpCode { get; private set; }

        public Label TrueLabel { get; private set; }
        public Label FalseLabel { get; private set; }

        public ConditionalItem(ByteCodeGenerator generator, OpCode opCode)
            : this(generator, opCode, null, null)
        {
            OpCode = opCode;
        }
        public ConditionalItem(ByteCodeGenerator generator, OpCode opCode, Label trueLabel, Label falseLabel)
            : base(generator, PrimativeTypes.Byte)
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
                Generator.Emit(OpCodes.iconst_1);
                //TODO: trueChain = code.branch(goto_);
            }

            if (falseChain != null)
            {
                Generator.MarkLabel(falseChain);
                Generator.Emit(OpCodes.iconst_0);
            }

            if (trueChain != null)
            {
                Generator.MarkLabel(trueChain);
            }

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
            if (TrueLabel != null) throw new NotImplementedException();

            TrueLabel = Generator.DefineLabel();

            return TrueLabel;
        }
        public Label JumpFalse()
        {
            if(FalseLabel != null) throw new NotImplementedException();

            FalseLabel = Generator.DefineLabel();

            return FalseLabel;
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
            return FalseLabel == null && OpCode.Value == OpCodeValue.@goto;
        }
        private bool IsFalse()
        {
            return TrueLabel == null && OpCode.Value == OpCodeValue.jsr;
        }

        public new String ToString()
        {
            return "cond(" + OpCode + ")";
        }
    }
}
