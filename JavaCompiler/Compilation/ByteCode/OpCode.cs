namespace JavaCompiler.Compilation.ByteCode
{
    public class OpCode
    {
        private readonly OpCodeMode reg;
        private readonly OpCodeModeWide wide;
        private readonly NormalizedOpCodeValues normbc;
        private readonly OpCodeFlags flags;
        private readonly int arg;

        internal OpCode(OpCodeValues bc, OpCodeMode reg, OpCodeModeWide wide, bool cannotThrow)
        {
            this.reg = reg;
            this.wide = wide;
            this.normbc = (NormalizedOpCodeValues)bc;
            this.arg = 0;
            this.flags = OpCodeFlags.None;
            if (cannotThrow)
            {
                this.flags |= OpCodeFlags.CannotThrow;
            }
        }

        internal OpCode(OpCodeValues bc, NormalizedOpCodeValues normbc, OpCodeMode reg, OpCodeModeWide wide, bool cannotThrow)
        {
            this.reg = reg;
            this.wide = wide;
            this.normbc = normbc;
            this.arg = 0;
            this.flags = OpCodeFlags.None;
            if (cannotThrow)
            {
                this.flags |= OpCodeFlags.CannotThrow;
            }
        }

        internal OpCode(OpCodeValues bc, NormalizedOpCodeValues normbc, int arg, OpCodeMode reg, OpCodeModeWide wide, bool cannotThrow)
        {
            this.reg = reg;
            this.wide = wide;
            this.normbc = normbc;
            this.arg = arg;
            this.flags = OpCodeFlags.FixedArg;
            if (cannotThrow)
            {
                this.flags |= OpCodeFlags.CannotThrow;
            }
        }

        public NormalizedOpCodeValues GetNormalizedOpCodeValues(OpCode bc)
        {
            return normbc;
        }

        internal int GetArg(OpCode bc, int defaultArg)
        {
            return (flags & OpCodeFlags.FixedArg) != 0 ? arg : defaultArg;
        }

        internal OpCodeMode GetMode(OpCode bc)
        {
            return reg;
        }

        internal OpCodeModeWide GetWideMode(OpCode bc)
        {
            return wide;
        }

        internal OpCodeFlowControl GetFlowControl(NormalizedOpCodeValues bc)
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
                    return (flags & OpCodeFlags.CannotThrow) == 0;
            }
        }

        internal bool IsBranch(NormalizedOpCodeValues bc)
        {
            switch (reg)
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
