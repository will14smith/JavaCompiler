namespace JavaCompiler.Compilation.ByteCode
{
    public class OpCodes
    {
// ReSharper disable InconsistentNaming
                public static OpCode nop = new OpCode(OpCodeValues.nop, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode aconst_null = new OpCode(OpCodeValues.aconst_null, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iconst_m1 = new OpCode(OpCodeValues.iconst_m1, NormalizedOpCodeValues.iconst, -1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iconst_0 = new OpCode(OpCodeValues.iconst_0, NormalizedOpCodeValues.iconst, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iconst_1 = new OpCode(OpCodeValues.iconst_1, NormalizedOpCodeValues.iconst, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iconst_2 = new OpCode(OpCodeValues.iconst_2, NormalizedOpCodeValues.iconst, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iconst_3 = new OpCode(OpCodeValues.iconst_3, NormalizedOpCodeValues.iconst, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iconst_4 = new OpCode(OpCodeValues.iconst_4, NormalizedOpCodeValues.iconst, 4, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iconst_5 = new OpCode(OpCodeValues.iconst_5, NormalizedOpCodeValues.iconst, 5, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lconst_0 = new OpCode(OpCodeValues.lconst_0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lconst_1 = new OpCode(OpCodeValues.lconst_1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fconst_0 = new OpCode(OpCodeValues.fconst_0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fconst_1 = new OpCode(OpCodeValues.fconst_1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fconst_2 = new OpCode(OpCodeValues.fconst_2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dconst_0 = new OpCode(OpCodeValues.dconst_0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dconst_1 = new OpCode(OpCodeValues.dconst_1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode bipush = new OpCode(OpCodeValues.bipush, NormalizedOpCodeValues.iconst, OpCodeMode.Immediate_1, OpCodeModeWide.Unused, true);

                public static OpCode sipush = new OpCode(OpCodeValues.sipush, NormalizedOpCodeValues.iconst, OpCodeMode.Immediate_2, OpCodeModeWide.Unused, true);

                public static OpCode ldc = new OpCode(OpCodeValues.ldc, OpCodeMode.Constant_1, OpCodeModeWide.Unused, false);

                public static OpCode ldc_w = new OpCode(OpCodeValues.ldc_w, NormalizedOpCodeValues.ldc, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode ldc2_w = new OpCode(OpCodeValues.ldc2_w, NormalizedOpCodeValues.ldc, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode iload = new OpCode(OpCodeValues.iload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode lload = new OpCode(OpCodeValues.lload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode fload = new OpCode(OpCodeValues.fload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode dload = new OpCode(OpCodeValues.dload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode aload = new OpCode(OpCodeValues.aload, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode iload_0 = new OpCode(OpCodeValues.iload_0, NormalizedOpCodeValues.iload, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iload_1 = new OpCode(OpCodeValues.iload_1, NormalizedOpCodeValues.iload, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iload_2 = new OpCode(OpCodeValues.iload_2, NormalizedOpCodeValues.iload, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iload_3 = new OpCode(OpCodeValues.iload_3, NormalizedOpCodeValues.iload, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lload_0 = new OpCode(OpCodeValues.lload_0, NormalizedOpCodeValues.lload, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lload_1 = new OpCode(OpCodeValues.lload_1, NormalizedOpCodeValues.lload, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lload_2 = new OpCode(OpCodeValues.lload_2, NormalizedOpCodeValues.lload, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lload_3 = new OpCode(OpCodeValues.lload_3, NormalizedOpCodeValues.lload, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fload_0 = new OpCode(OpCodeValues.fload_0, NormalizedOpCodeValues.fload, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fload_1 = new OpCode(OpCodeValues.fload_1, NormalizedOpCodeValues.fload, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fload_2 = new OpCode(OpCodeValues.fload_2, NormalizedOpCodeValues.fload, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fload_3 = new OpCode(OpCodeValues.fload_3, NormalizedOpCodeValues.fload, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dload_0 = new OpCode(OpCodeValues.dload_0, NormalizedOpCodeValues.dload, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dload_1 = new OpCode(OpCodeValues.dload_1, NormalizedOpCodeValues.dload, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dload_2 = new OpCode(OpCodeValues.dload_2, NormalizedOpCodeValues.dload, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dload_3 = new OpCode(OpCodeValues.dload_3, NormalizedOpCodeValues.dload, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode aload_0 = new OpCode(OpCodeValues.aload_0, NormalizedOpCodeValues.aload, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode aload_1 = new OpCode(OpCodeValues.aload_1, NormalizedOpCodeValues.aload, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode aload_2 = new OpCode(OpCodeValues.aload_2, NormalizedOpCodeValues.aload, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode aload_3 = new OpCode(OpCodeValues.aload_3, NormalizedOpCodeValues.aload, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iaload = new OpCode(OpCodeValues.iaload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode laload = new OpCode(OpCodeValues.laload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode faload = new OpCode(OpCodeValues.faload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode daload = new OpCode(OpCodeValues.daload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode aaload = new OpCode(OpCodeValues.aaload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode baload = new OpCode(OpCodeValues.baload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode caload = new OpCode(OpCodeValues.caload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode saload = new OpCode(OpCodeValues.saload, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode istore = new OpCode(OpCodeValues.istore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode lstore = new OpCode(OpCodeValues.lstore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode fstore = new OpCode(OpCodeValues.fstore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode dstore = new OpCode(OpCodeValues.dstore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode astore = new OpCode(OpCodeValues.astore, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode istore_0 = new OpCode(OpCodeValues.istore_0, NormalizedOpCodeValues.istore, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode istore_1 = new OpCode(OpCodeValues.istore_1, NormalizedOpCodeValues.istore, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode istore_2 = new OpCode(OpCodeValues.istore_2, NormalizedOpCodeValues.istore, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode istore_3 = new OpCode(OpCodeValues.istore_3, NormalizedOpCodeValues.istore, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lstore_0 = new OpCode(OpCodeValues.lstore_0, NormalizedOpCodeValues.lstore, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lstore_1 = new OpCode(OpCodeValues.lstore_1, NormalizedOpCodeValues.lstore, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lstore_2 = new OpCode(OpCodeValues.lstore_2, NormalizedOpCodeValues.lstore, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lstore_3 = new OpCode(OpCodeValues.lstore_3, NormalizedOpCodeValues.lstore, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fstore_0 = new OpCode(OpCodeValues.fstore_0, NormalizedOpCodeValues.fstore, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fstore_1 = new OpCode(OpCodeValues.fstore_1, NormalizedOpCodeValues.fstore, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fstore_2 = new OpCode(OpCodeValues.fstore_2, NormalizedOpCodeValues.fstore, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fstore_3 = new OpCode(OpCodeValues.fstore_3, NormalizedOpCodeValues.fstore, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dstore_0 = new OpCode(OpCodeValues.dstore_0, NormalizedOpCodeValues.dstore, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dstore_1 = new OpCode(OpCodeValues.dstore_1, NormalizedOpCodeValues.dstore, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dstore_2 = new OpCode(OpCodeValues.dstore_2, NormalizedOpCodeValues.dstore, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dstore_3 = new OpCode(OpCodeValues.dstore_3, NormalizedOpCodeValues.dstore, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode astore_0 = new OpCode(OpCodeValues.astore_0, NormalizedOpCodeValues.astore, 0, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode astore_1 = new OpCode(OpCodeValues.astore_1, NormalizedOpCodeValues.astore, 1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode astore_2 = new OpCode(OpCodeValues.astore_2, NormalizedOpCodeValues.astore, 2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode astore_3 = new OpCode(OpCodeValues.astore_3, NormalizedOpCodeValues.astore, 3, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iastore = new OpCode(OpCodeValues.iastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode lastore = new OpCode(OpCodeValues.lastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode fastore = new OpCode(OpCodeValues.fastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode dastore = new OpCode(OpCodeValues.dastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode aastore = new OpCode(OpCodeValues.aastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode bastore = new OpCode(OpCodeValues.bastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode castore = new OpCode(OpCodeValues.castore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode sastore = new OpCode(OpCodeValues.sastore, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode pop = new OpCode(OpCodeValues.pop, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode pop2 = new OpCode(OpCodeValues.pop2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dup = new OpCode(OpCodeValues.dup, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dup_x1 = new OpCode(OpCodeValues.dup_x1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dup_x2 = new OpCode(OpCodeValues.dup_x2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dup2 = new OpCode(OpCodeValues.dup2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dup2_x1 = new OpCode(OpCodeValues.dup2_x1, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dup2_x2 = new OpCode(OpCodeValues.dup2_x2, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode swap = new OpCode(OpCodeValues.swap, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iadd = new OpCode(OpCodeValues.iadd, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode ladd = new OpCode(OpCodeValues.ladd, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fadd = new OpCode(OpCodeValues.fadd, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dadd = new OpCode(OpCodeValues.dadd, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode isub = new OpCode(OpCodeValues.isub, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lsub = new OpCode(OpCodeValues.lsub, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fsub = new OpCode(OpCodeValues.fsub, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dsub = new OpCode(OpCodeValues.dsub, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode imul = new OpCode(OpCodeValues.imul, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lmul = new OpCode(OpCodeValues.lmul, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fmul = new OpCode(OpCodeValues.fmul, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dmul = new OpCode(OpCodeValues.dmul, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode idiv = new OpCode(OpCodeValues.idiv, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode ldiv = new OpCode(OpCodeValues.ldiv, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode fdiv = new OpCode(OpCodeValues.fdiv, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode ddiv = new OpCode(OpCodeValues.ddiv, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode irem = new OpCode(OpCodeValues.irem, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode lrem = new OpCode(OpCodeValues.lrem, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode frem = new OpCode(OpCodeValues.frem, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode drem = new OpCode(OpCodeValues.drem, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode ineg = new OpCode(OpCodeValues.ineg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lneg = new OpCode(OpCodeValues.lneg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fneg = new OpCode(OpCodeValues.fneg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dneg = new OpCode(OpCodeValues.dneg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode ishl = new OpCode(OpCodeValues.ishl, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lshl = new OpCode(OpCodeValues.lshl, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode ishr = new OpCode(OpCodeValues.ishr, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lshr = new OpCode(OpCodeValues.lshr, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iushr = new OpCode(OpCodeValues.iushr, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lushr = new OpCode(OpCodeValues.lushr, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iand = new OpCode(OpCodeValues.iand, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode land = new OpCode(OpCodeValues.land, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode ior = new OpCode(OpCodeValues.ior, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lor = new OpCode(OpCodeValues.lor, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode ixor = new OpCode(OpCodeValues.ixor, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lxor = new OpCode(OpCodeValues.lxor, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode iinc = new OpCode(OpCodeValues.iinc, OpCodeMode.Local_1_Immediate_1, OpCodeModeWide.Local_2_Immediate_2, true);

                public static OpCode i2l = new OpCode(OpCodeValues.i2l, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode i2f = new OpCode(OpCodeValues.i2f, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode i2d = new OpCode(OpCodeValues.i2d, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode l2i = new OpCode(OpCodeValues.l2i, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode l2f = new OpCode(OpCodeValues.l2f, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode l2d = new OpCode(OpCodeValues.l2d, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode f2i = new OpCode(OpCodeValues.f2i, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode f2l = new OpCode(OpCodeValues.f2l, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode f2d = new OpCode(OpCodeValues.f2d, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode d2i = new OpCode(OpCodeValues.d2i, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode d2l = new OpCode(OpCodeValues.d2l, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode d2f = new OpCode(OpCodeValues.d2f, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode i2b = new OpCode(OpCodeValues.i2b, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode i2c = new OpCode(OpCodeValues.i2c, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode i2s = new OpCode(OpCodeValues.i2s, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lcmp = new OpCode(OpCodeValues.lcmp, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fcmpl = new OpCode(OpCodeValues.fcmpl, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode fcmpg = new OpCode(OpCodeValues.fcmpg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dcmpl = new OpCode(OpCodeValues.dcmpl, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dcmpg = new OpCode(OpCodeValues.dcmpg, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode ifeq = new OpCode(OpCodeValues.ifeq, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode ifne = new OpCode(OpCodeValues.ifne, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode iflt = new OpCode(OpCodeValues.iflt, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode ifge = new OpCode(OpCodeValues.ifge, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode ifgt = new OpCode(OpCodeValues.ifgt, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode ifle = new OpCode(OpCodeValues.ifle, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode if_icmpeq = new OpCode(OpCodeValues.if_icmpeq, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode if_icmpne = new OpCode(OpCodeValues.if_icmpne, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode if_icmplt = new OpCode(OpCodeValues.if_icmplt, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode if_icmpge = new OpCode(OpCodeValues.if_icmpge, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode if_icmpgt = new OpCode(OpCodeValues.if_icmpgt, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode if_icmple = new OpCode(OpCodeValues.if_icmple, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode if_acmpeq = new OpCode(OpCodeValues.if_acmpeq, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode if_acmpne = new OpCode(OpCodeValues.if_acmpne, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode @goto = new OpCode(OpCodeValues.@goto, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode jsr = new OpCode(OpCodeValues.jsr, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode ret = new OpCode(OpCodeValues.ret, OpCodeMode.Local_1, OpCodeModeWide.Local_2, true);

                public static OpCode tableswitch = new OpCode(OpCodeValues.tableswitch, OpCodeMode.Tableswitch, OpCodeModeWide.Unused, true);

                public static OpCode lookupswitch = new OpCode(OpCodeValues.lookupswitch, OpCodeMode.Lookupswitch, OpCodeModeWide.Unused, true);

                public static OpCode ireturn = new OpCode(OpCodeValues.ireturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode lreturn = new OpCode(OpCodeValues.lreturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode freturn = new OpCode(OpCodeValues.freturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode dreturn = new OpCode(OpCodeValues.dreturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode areturn = new OpCode(OpCodeValues.areturn, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode @return = new OpCode(OpCodeValues.@return, OpCodeMode.Simple, OpCodeModeWide.Unused, true);

                public static OpCode getstatic = new OpCode(OpCodeValues.getstatic, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode putstatic = new OpCode(OpCodeValues.putstatic, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode getfield = new OpCode(OpCodeValues.getfield, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode putfield = new OpCode(OpCodeValues.putfield, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode invokevirtual = new OpCode(OpCodeValues.invokevirtual, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode invokespecial = new OpCode(OpCodeValues.invokespecial, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode invokestatic = new OpCode(OpCodeValues.invokestatic, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode invokeinterface = new OpCode(OpCodeValues.invokeinterface, OpCodeMode.Constant_2_1_1, OpCodeModeWide.Unused, false);

                public static OpCode invokedynamic = new OpCode(OpCodeValues.invokedynamic, OpCodeMode.Constant_2_1_1, OpCodeModeWide.Unused, false);

                public static OpCode @new = new OpCode(OpCodeValues.@new, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode newarray = new OpCode(OpCodeValues.newarray, OpCodeMode.Immediate_1, OpCodeModeWide.Unused, false);

                public static OpCode anewarray = new OpCode(OpCodeValues.anewarray, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode arraylength = new OpCode(OpCodeValues.arraylength, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode athrow = new OpCode(OpCodeValues.athrow, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode checkcast = new OpCode(OpCodeValues.checkcast, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode instanceof = new OpCode(OpCodeValues.instanceof, OpCodeMode.Constant_2, OpCodeModeWide.Unused, false);

                public static OpCode monitorenter = new OpCode(OpCodeValues.monitorenter, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode monitorexit = new OpCode(OpCodeValues.monitorexit, OpCodeMode.Simple, OpCodeModeWide.Unused, false);

                public static OpCode wide = new OpCode(OpCodeValues.wide, NormalizedOpCodeValues.nop, OpCodeMode.WidePrefix, OpCodeModeWide.Unused, true);

                public static OpCode multianewarray = new OpCode(OpCodeValues.multianewarray, OpCodeMode.Constant_2_Immediate_1, OpCodeModeWide.Unused, false);

                public static OpCode ifnull = new OpCode(OpCodeValues.ifnull, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode ifnonnull = new OpCode(OpCodeValues.ifnonnull, OpCodeMode.Branch_2, OpCodeModeWide.Unused, true);

                public static OpCode goto_w = new OpCode(OpCodeValues.goto_w, NormalizedOpCodeValues.@goto, OpCodeMode.Branch_4, OpCodeModeWide.Unused, true);

                public static OpCode jsr_w = new OpCode(OpCodeValues.jsr_w, NormalizedOpCodeValues.jsr, OpCodeMode.Branch_4, OpCodeModeWide.Unused, true);
        // ReSharper restore InconsistentNaming
    }
}
