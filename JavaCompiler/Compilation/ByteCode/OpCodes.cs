using System;

namespace JavaCompiler.Compilation.ByteCode
{
    public class OpCodes
    {
        // ReSharper disable InconsistentNaming
        public static OpCode nop = new OpCode(OpCodeValue.nop, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode aconst_null = new OpCode(OpCodeValue.aconst_null, OpCodeMode.Simple, OpCodeModeWide.Unused,
                                                      true);

        public static OpCode iconst_m1 = new OpCode(OpCodeValue.iconst_m1, NormalizedOpCodeValues.iconst, -1,
                                                    OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iconst_0 = new OpCode(OpCodeValue.iconst_0, NormalizedOpCodeValues.iconst, 0,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iconst_1 = new OpCode(OpCodeValue.iconst_1, NormalizedOpCodeValues.iconst, 1,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iconst_2 = new OpCode(OpCodeValue.iconst_2, NormalizedOpCodeValues.iconst, 2,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iconst_3 = new OpCode(OpCodeValue.iconst_3, NormalizedOpCodeValues.iconst, 3,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iconst_4 = new OpCode(OpCodeValue.iconst_4, NormalizedOpCodeValues.iconst, 4,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iconst_5 = new OpCode(OpCodeValue.iconst_5, NormalizedOpCodeValues.iconst, 5,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lconst_0 = new OpCode(OpCodeValue.lconst_0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lconst_1 = new OpCode(OpCodeValue.lconst_1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fconst_0 = new OpCode(OpCodeValue.fconst_0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fconst_1 = new OpCode(OpCodeValue.fconst_1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fconst_2 = new OpCode(OpCodeValue.fconst_2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dconst_0 = new OpCode(OpCodeValue.dconst_0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dconst_1 = new OpCode(OpCodeValue.dconst_1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode bipush = new OpCode(OpCodeValue.bipush, NormalizedOpCodeValues.iconst,
                                                 OpCodeMode.Immediate_1, OpCodeModeWide.Unused, true);

        public static OpCode sipush = new OpCode(OpCodeValue.sipush, NormalizedOpCodeValues.iconst,
                                                 OpCodeMode.Immediate_2, OpCodeModeWide.Unused, true);

        public static OpCode ldc = new OpCode(OpCodeValue.ldc, OpCodeMode.Constant_1, OpCodeModeWide.Unused, false);

        public static OpCode ldc_w = new OpCode(OpCodeValue.ldc_w, NormalizedOpCodeValues.ldc, OpCodeMode.Constant_2,
                                                OpCodeModeWide.Unused, false);

        public static OpCode ldc2_w = new OpCode(OpCodeValue.ldc2_w, NormalizedOpCodeValues.ldc, OpCodeMode.Constant_2,
                                                 OpCodeModeWide.Unused, false);

        public static OpCode iload = new OpCode(OpCodeValue.iload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode lload = new OpCode(OpCodeValue.lload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode fload = new OpCode(OpCodeValue.fload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode dload = new OpCode(OpCodeValue.dload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode aload = new OpCode(OpCodeValue.aload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode iload_0 = new OpCode(OpCodeValue.iload_0, NormalizedOpCodeValues.iload, 0,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iload_1 = new OpCode(OpCodeValue.iload_1, NormalizedOpCodeValues.iload, 1,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iload_2 = new OpCode(OpCodeValue.iload_2, NormalizedOpCodeValues.iload, 2,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iload_3 = new OpCode(OpCodeValue.iload_3, NormalizedOpCodeValues.iload, 3,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lload_0 = new OpCode(OpCodeValue.lload_0, NormalizedOpCodeValues.lload, 0,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lload_1 = new OpCode(OpCodeValue.lload_1, NormalizedOpCodeValues.lload, 1,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lload_2 = new OpCode(OpCodeValue.lload_2, NormalizedOpCodeValues.lload, 2,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lload_3 = new OpCode(OpCodeValue.lload_3, NormalizedOpCodeValues.lload, 3,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fload_0 = new OpCode(OpCodeValue.fload_0, NormalizedOpCodeValues.fload, 0,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fload_1 = new OpCode(OpCodeValue.fload_1, NormalizedOpCodeValues.fload, 1,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fload_2 = new OpCode(OpCodeValue.fload_2, NormalizedOpCodeValues.fload, 2,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fload_3 = new OpCode(OpCodeValue.fload_3, NormalizedOpCodeValues.fload, 3,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dload_0 = new OpCode(OpCodeValue.dload_0, NormalizedOpCodeValues.dload, 0,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dload_1 = new OpCode(OpCodeValue.dload_1, NormalizedOpCodeValues.dload, 1,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dload_2 = new OpCode(OpCodeValue.dload_2, NormalizedOpCodeValues.dload, 2,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dload_3 = new OpCode(OpCodeValue.dload_3, NormalizedOpCodeValues.dload, 3,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode aload_0 = new OpCode(OpCodeValue.aload_0, NormalizedOpCodeValues.aload, 0,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode aload_1 = new OpCode(OpCodeValue.aload_1, NormalizedOpCodeValues.aload, 1,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode aload_2 = new OpCode(OpCodeValue.aload_2, NormalizedOpCodeValues.aload, 2,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode aload_3 = new OpCode(OpCodeValue.aload_3, NormalizedOpCodeValues.aload, 3,
                                                  OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iaload = new OpCode(OpCodeValue.iaload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode laload = new OpCode(OpCodeValue.laload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode faload = new OpCode(OpCodeValue.faload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode daload = new OpCode(OpCodeValue.daload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode aaload = new OpCode(OpCodeValue.aaload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode baload = new OpCode(OpCodeValue.baload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode caload = new OpCode(OpCodeValue.caload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode saload = new OpCode(OpCodeValue.saload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode istore = new OpCode(OpCodeValue.istore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode lstore = new OpCode(OpCodeValue.lstore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode fstore = new OpCode(OpCodeValue.fstore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode dstore = new OpCode(OpCodeValue.dstore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode astore = new OpCode(OpCodeValue.astore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode istore_0 = new OpCode(OpCodeValue.istore_0, NormalizedOpCodeValues.istore, 0,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode istore_1 = new OpCode(OpCodeValue.istore_1, NormalizedOpCodeValues.istore, 1,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode istore_2 = new OpCode(OpCodeValue.istore_2, NormalizedOpCodeValues.istore, 2,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode istore_3 = new OpCode(OpCodeValue.istore_3, NormalizedOpCodeValues.istore, 3,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lstore_0 = new OpCode(OpCodeValue.lstore_0, NormalizedOpCodeValues.lstore, 0,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lstore_1 = new OpCode(OpCodeValue.lstore_1, NormalizedOpCodeValues.lstore, 1,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lstore_2 = new OpCode(OpCodeValue.lstore_2, NormalizedOpCodeValues.lstore, 2,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lstore_3 = new OpCode(OpCodeValue.lstore_3, NormalizedOpCodeValues.lstore, 3,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fstore_0 = new OpCode(OpCodeValue.fstore_0, NormalizedOpCodeValues.fstore, 0,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fstore_1 = new OpCode(OpCodeValue.fstore_1, NormalizedOpCodeValues.fstore, 1,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fstore_2 = new OpCode(OpCodeValue.fstore_2, NormalizedOpCodeValues.fstore, 2,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fstore_3 = new OpCode(OpCodeValue.fstore_3, NormalizedOpCodeValues.fstore, 3,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dstore_0 = new OpCode(OpCodeValue.dstore_0, NormalizedOpCodeValues.dstore, 0,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dstore_1 = new OpCode(OpCodeValue.dstore_1, NormalizedOpCodeValues.dstore, 1,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dstore_2 = new OpCode(OpCodeValue.dstore_2, NormalizedOpCodeValues.dstore, 2,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dstore_3 = new OpCode(OpCodeValue.dstore_3, NormalizedOpCodeValues.dstore, 3,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode astore_0 = new OpCode(OpCodeValue.astore_0, NormalizedOpCodeValues.astore, 0,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode astore_1 = new OpCode(OpCodeValue.astore_1, NormalizedOpCodeValues.astore, 1,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode astore_2 = new OpCode(OpCodeValue.astore_2, NormalizedOpCodeValues.astore, 2,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode astore_3 = new OpCode(OpCodeValue.astore_3, NormalizedOpCodeValues.astore, 3,
                                                   OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iastore = new OpCode(OpCodeValue.iastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode lastore = new OpCode(OpCodeValue.lastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode fastore = new OpCode(OpCodeValue.fastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode dastore = new OpCode(OpCodeValue.dastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode aastore = new OpCode(OpCodeValue.aastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode bastore = new OpCode(OpCodeValue.bastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode castore = new OpCode(OpCodeValue.castore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode sastore = new OpCode(OpCodeValue.sastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode pop = new OpCode(OpCodeValue.pop, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode pop2 = new OpCode(OpCodeValue.pop2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dup = new OpCode(OpCodeValue.dup, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dup_x1 = new OpCode(OpCodeValue.dup_x1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dup_x2 = new OpCode(OpCodeValue.dup_x2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dup2 = new OpCode(OpCodeValue.dup2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dup2_x1 = new OpCode(OpCodeValue.dup2_x1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dup2_x2 = new OpCode(OpCodeValue.dup2_x2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode swap = new OpCode(OpCodeValue.swap, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iadd = new OpCode(OpCodeValue.iadd, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode ladd = new OpCode(OpCodeValue.ladd, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fadd = new OpCode(OpCodeValue.fadd, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dadd = new OpCode(OpCodeValue.dadd, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode isub = new OpCode(OpCodeValue.isub, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lsub = new OpCode(OpCodeValue.lsub, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fsub = new OpCode(OpCodeValue.fsub, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dsub = new OpCode(OpCodeValue.dsub, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode imul = new OpCode(OpCodeValue.imul, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lmul = new OpCode(OpCodeValue.lmul, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fmul = new OpCode(OpCodeValue.fmul, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dmul = new OpCode(OpCodeValue.dmul, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode idiv = new OpCode(OpCodeValue.idiv, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode ldiv = new OpCode(OpCodeValue.ldiv, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode fdiv = new OpCode(OpCodeValue.fdiv, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode ddiv = new OpCode(OpCodeValue.ddiv, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode irem = new OpCode(OpCodeValue.irem, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode lrem = new OpCode(OpCodeValue.lrem, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode frem = new OpCode(OpCodeValue.frem, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode drem = new OpCode(OpCodeValue.drem, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode ineg = new OpCode(OpCodeValue.ineg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lneg = new OpCode(OpCodeValue.lneg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fneg = new OpCode(OpCodeValue.fneg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dneg = new OpCode(OpCodeValue.dneg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode ishl = new OpCode(OpCodeValue.ishl, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lshl = new OpCode(OpCodeValue.lshl, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode ishr = new OpCode(OpCodeValue.ishr, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lshr = new OpCode(OpCodeValue.lshr, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iushr = new OpCode(OpCodeValue.iushr, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lushr = new OpCode(OpCodeValue.lushr, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iand = new OpCode(OpCodeValue.iand, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode land = new OpCode(OpCodeValue.land, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode ior = new OpCode(OpCodeValue.ior, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lor = new OpCode(OpCodeValue.lor, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode ixor = new OpCode(OpCodeValue.ixor, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lxor = new OpCode(OpCodeValue.lxor, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode iinc = new OpCode(OpCodeValue.iinc, OpCodeMode.Local_1_Immediate_1,
                                               OpCodeModeWide.Local_2_Immediate_2, true);

        public static OpCode i2l = new OpCode(OpCodeValue.i2l, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode i2f = new OpCode(OpCodeValue.i2f, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode i2d = new OpCode(OpCodeValue.i2d, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode l2i = new OpCode(OpCodeValue.l2i, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode l2f = new OpCode(OpCodeValue.l2f, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode l2d = new OpCode(OpCodeValue.l2d, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode f2i = new OpCode(OpCodeValue.f2i, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode f2l = new OpCode(OpCodeValue.f2l, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode f2d = new OpCode(OpCodeValue.f2d, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode d2i = new OpCode(OpCodeValue.d2i, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode d2l = new OpCode(OpCodeValue.d2l, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode d2f = new OpCode(OpCodeValue.d2f, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode i2b = new OpCode(OpCodeValue.i2b, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode i2c = new OpCode(OpCodeValue.i2c, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode i2s = new OpCode(OpCodeValue.i2s, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lcmp = new OpCode(OpCodeValue.lcmp, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fcmpl = new OpCode(OpCodeValue.fcmpl, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode fcmpg = new OpCode(OpCodeValue.fcmpg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dcmpl = new OpCode(OpCodeValue.dcmpl, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dcmpg = new OpCode(OpCodeValue.dcmpg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode ifeq = new OpCode(OpCodeValue.ifeq, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

        public static OpCode ifne = new OpCode(OpCodeValue.ifne, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

        public static OpCode iflt = new OpCode(OpCodeValue.iflt, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

        public static OpCode ifge = new OpCode(OpCodeValue.ifge, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

        public static OpCode ifgt = new OpCode(OpCodeValue.ifgt, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

        public static OpCode ifle = new OpCode(OpCodeValue.ifle, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

        public static OpCode if_icmpeq = new OpCode(OpCodeValue.if_icmpeq, OpCodeMode.Branch_2, OpCodeModeWide.Unused,
                                                    true);

        public static OpCode if_icmpne = new OpCode(OpCodeValue.if_icmpne, OpCodeMode.Branch_2, OpCodeModeWide.Unused,
                                                    true);

        public static OpCode if_icmplt = new OpCode(OpCodeValue.if_icmplt, OpCodeMode.Branch_2, OpCodeModeWide.Unused,
                                                    true);

        public static OpCode if_icmpge = new OpCode(OpCodeValue.if_icmpge, OpCodeMode.Branch_2, OpCodeModeWide.Unused,
                                                    true);

        public static OpCode if_icmpgt = new OpCode(OpCodeValue.if_icmpgt, OpCodeMode.Branch_2, OpCodeModeWide.Unused,
                                                    true);

        public static OpCode if_icmple = new OpCode(OpCodeValue.if_icmple, OpCodeMode.Branch_2, OpCodeModeWide.Unused,
                                                    true);

        public static OpCode if_acmpeq = new OpCode(OpCodeValue.if_acmpeq, OpCodeMode.Branch_2, OpCodeModeWide.Unused,
                                                    true);

        public static OpCode if_acmpne = new OpCode(OpCodeValue.if_acmpne, OpCodeMode.Branch_2, OpCodeModeWide.Unused,
                                                    true);

        public static OpCode @goto = new OpCode(OpCodeValue.@goto, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

        public static OpCode jsr = new OpCode(OpCodeValue.jsr, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

        public static OpCode ret = new OpCode(OpCodeValue.ret, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

        public static OpCode tableswitch = new OpCode(OpCodeValue.tableswitch, OpCodeMode.Tableswitch,
                                                      OpCodeModeWide.Unused, true);

        public static OpCode lookupswitch = new OpCode(OpCodeValue.lookupswitch, OpCodeMode.Lookupswitch,
                                                       OpCodeModeWide.Unused, true);

        public static OpCode ireturn = new OpCode(OpCodeValue.ireturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode lreturn = new OpCode(OpCodeValue.lreturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode freturn = new OpCode(OpCodeValue.freturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode dreturn = new OpCode(OpCodeValue.dreturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode areturn = new OpCode(OpCodeValue.areturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode @return = new OpCode(OpCodeValue.@return, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

        public static OpCode getstatic = new OpCode(OpCodeValue.getstatic, OpCodeMode.Constant_2, OpCodeModeWide.Unused,
                                                    false);

        public static OpCode putstatic = new OpCode(OpCodeValue.putstatic, OpCodeMode.Constant_2, OpCodeModeWide.Unused,
                                                    false);

        public static OpCode getfield = new OpCode(OpCodeValue.getfield, OpCodeMode.Constant_2, OpCodeModeWide.Unused,
                                                   false);

        public static OpCode putfield = new OpCode(OpCodeValue.putfield, OpCodeMode.Constant_2, OpCodeModeWide.Unused,
                                                   false);

        public static OpCode invokevirtual = new OpCode(OpCodeValue.invokevirtual, OpCodeMode.Constant_2,
                                                        OpCodeModeWide.Unused, false);

        public static OpCode invokespecial = new OpCode(OpCodeValue.invokespecial, OpCodeMode.Constant_2,
                                                        OpCodeModeWide.Unused, false);

        public static OpCode invokestatic = new OpCode(OpCodeValue.invokestatic, OpCodeMode.Constant_2,
                                                       OpCodeModeWide.Unused, false);

        public static OpCode invokeinterface = new OpCode(OpCodeValue.invokeinterface, OpCodeMode.Constant_2_1_1,
                                                          OpCodeModeWide.Unused, false);

        public static OpCode invokedynamic = new OpCode(OpCodeValue.invokedynamic, OpCodeMode.Constant_2_1_1,
                                                        OpCodeModeWide.Unused, false);

        public static OpCode @new = new OpCode(OpCodeValue.@new, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

        public static OpCode newarray = new OpCode(OpCodeValue.newarray, OpCodeMode.Immediate_1, OpCodeModeWide.Unused,
                                                   false);

        public static OpCode anewarray = new OpCode(OpCodeValue.anewarray, OpCodeMode.Constant_2, OpCodeModeWide.Unused,
                                                    false);

        public static OpCode arraylength = new OpCode(OpCodeValue.arraylength, OpCodeMode.Simple, OpCodeModeWide.Unused,
                                                      false);

        public static OpCode athrow = new OpCode(OpCodeValue.athrow, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

        public static OpCode checkcast = new OpCode(OpCodeValue.checkcast, OpCodeMode.Constant_2, OpCodeModeWide.Unused,
                                                    false);

        public static OpCode instanceof = new OpCode(OpCodeValue.instanceof, OpCodeMode.Constant_2,
                                                     OpCodeModeWide.Unused, false);

        public static OpCode monitorenter = new OpCode(OpCodeValue.monitorenter, OpCodeMode.Simple,
                                                       OpCodeModeWide.Unused, false);

        public static OpCode monitorexit = new OpCode(OpCodeValue.monitorexit, OpCodeMode.Simple, OpCodeModeWide.Unused,
                                                      false);

        public static OpCode wide = new OpCode(OpCodeValue.wide, NormalizedOpCodeValues.nop, OpCodeMode.WidePrefix,
                                               OpCodeModeWide.Unused, true);

        public static OpCode multianewarray = new OpCode(OpCodeValue.multianewarray, OpCodeMode.Constant_2_Immediate_1,
                                                         OpCodeModeWide.Unused, false);

        public static OpCode ifnull = new OpCode(OpCodeValue.ifnull, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

        public static OpCode ifnonnull = new OpCode(OpCodeValue.ifnonnull, OpCodeMode.Branch_2, OpCodeModeWide.Unused,
                                                    true);

        public static OpCode goto_w = new OpCode(OpCodeValue.goto_w, NormalizedOpCodeValues.@goto, OpCodeMode.Branch_4,
                                                 OpCodeModeWide.Unused, true);

        public static OpCode jsr_w = new OpCode(OpCodeValue.jsr_w, NormalizedOpCodeValues.jsr, OpCodeMode.Branch_4,
                                                OpCodeModeWide.Unused, true);

        // ReSharper restore InconsistentNaming
        public static OpCode Negate(OpCode opCode)
        {
            if (opCode.Value == OpCodeValue.ifnull) return ifnonnull;
            if (opCode.Value == OpCodeValue.ifnonnull) return ifnull;

            throw new NotImplementedException();
        }
    }
}