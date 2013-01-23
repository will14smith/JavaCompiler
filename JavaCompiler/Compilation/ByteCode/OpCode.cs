namespace JavaCompiler.Compilation.ByteCode
{
    public class OpCode
    {
        private readonly int arg;

        internal OpCode(OpCodeValue bc, OpCodeMode reg, OpCodeModeWide wide, bool cannotThrow)
            : this(bc, (NormalizedOpCodeValues) bc, 0, reg, wide, cannotThrow)
        {
        }

        internal OpCode(OpCodeValue bc, NormalizedOpCodeValues normalizedValue, OpCodeMode reg, OpCodeModeWide wide,
                        bool cannotThrow)
            : this(bc, normalizedValue, 0, reg, wide, cannotThrow)
        {
        }

        internal OpCode(OpCodeValue bc, NormalizedOpCodeValues normalizedValue, int arg, OpCodeMode reg,
                        OpCodeModeWide wide, bool cannotThrow)
        {
            Value = bc;
            Mode = reg;
            WideMode = wide;
            NormalizedValue = normalizedValue;

            this.arg = arg;
            Flags = OpCodeFlags.FixedArg;
            if (cannotThrow)
            {
                Flags |= OpCodeFlags.CannotThrow;
            }
        }

        public OpCodeValue Value { get; private set; }

        public OpCodeMode Mode { get; private set; }
        public OpCodeModeWide WideMode { get; private set; }
        public NormalizedOpCodeValues NormalizedValue { get; private set; }
        public OpCodeFlags Flags { get; private set; }

        internal int GetArg(OpCode bc, int defaultArg)
        {
            return (Flags & OpCodeFlags.FixedArg) != 0 ? arg : defaultArg;
        }

        internal static OpCodeFlowControl FlowControl(NormalizedOpCodeValues bc)
        {
            switch (bc)
            {
                case NormalizedOpCodeValues.tableswitch:
                case NormalizedOpCodeValues.lookupswitch:
                    return OpCodeFlowControl.Switch;

                case NormalizedOpCodeValues.@goto:
                case NormalizedOpCodeValues.goto_finally:
                    return OpCodeFlowControl.Branch;

                case NormalizedOpCodeValues.ifeq:
                case NormalizedOpCodeValues.ifne:
                case NormalizedOpCodeValues.iflt:
                case NormalizedOpCodeValues.ifge:
                case NormalizedOpCodeValues.ifgt:
                case NormalizedOpCodeValues.ifle:
                case NormalizedOpCodeValues.if_icmpeq:
                case NormalizedOpCodeValues.if_icmpne:
                case NormalizedOpCodeValues.if_icmplt:
                case NormalizedOpCodeValues.if_icmpge:
                case NormalizedOpCodeValues.if_icmpgt:
                case NormalizedOpCodeValues.if_icmple:
                case NormalizedOpCodeValues.if_acmpeq:
                case NormalizedOpCodeValues.if_acmpne:
                case NormalizedOpCodeValues.ifnull:
                case NormalizedOpCodeValues.ifnonnull:
                    return OpCodeFlowControl.CondBranch;

                case NormalizedOpCodeValues.ireturn:
                case NormalizedOpCodeValues.lreturn:
                case NormalizedOpCodeValues.freturn:
                case NormalizedOpCodeValues.dreturn:
                case NormalizedOpCodeValues.areturn:
                case NormalizedOpCodeValues.@return:
                    return OpCodeFlowControl.Return;

                case NormalizedOpCodeValues.athrow:
                case NormalizedOpCodeValues.athrow_no_unmap:
                case NormalizedOpCodeValues.static_error:
                    return OpCodeFlowControl.Throw;

                default:
                    return OpCodeFlowControl.Next;
            }
        }

        internal bool CanThrowException(NormalizedOpCodeValues bc)
        {
            switch (bc)
            {
                case NormalizedOpCodeValues.dynamic_invokeinterface:
                case NormalizedOpCodeValues.dynamic_invokestatic:
                case NormalizedOpCodeValues.dynamic_invokevirtual:
                case NormalizedOpCodeValues.dynamic_getstatic:
                case NormalizedOpCodeValues.dynamic_putstatic:
                case NormalizedOpCodeValues.dynamic_getfield:
                case NormalizedOpCodeValues.dynamic_putfield:
                case NormalizedOpCodeValues.clone_array:
                case NormalizedOpCodeValues.static_error:
                case NormalizedOpCodeValues.methodhandle_invoke:
                case NormalizedOpCodeValues.methodhandle_invokeexact:
                    return true;
                case NormalizedOpCodeValues.iconst:
                case NormalizedOpCodeValues.ldc_nothrow:
                    return false;
                default:
                    return (Flags & OpCodeFlags.CannotThrow) == 0;
            }
        }

        internal bool IsBranch(NormalizedOpCodeValues bc)
        {
            switch (Mode)
            {
                case OpCodeMode.Branch_2:
                case OpCodeMode.Branch_4:
                case OpCodeMode.Lookupswitch:
                case OpCodeMode.Tableswitch:
                    return true;
                default:
                    return false;
            }
        }
    }
}