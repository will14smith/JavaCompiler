using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Reflection;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilation
{
    public abstract class CompileAttribute
    {
        public abstract string Name { get; }
        public abstract int Length { get; }

        public short NameIndex { get; set; }

        public abstract void Write(EndianBinaryWriter writer);
    }

    public class CompileAttributeConstantValue : CompileAttribute
    {
        public override string Name { get { return "ConstantValue"; } }
        public override int Length { get { return 2; } }

        public short ValueIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(ValueIndex);
        }
    }
    public class CompileAttributeCode : CompileAttribute
    {
        public struct ExceptionTableEntry
        {
            public short StartPC;
            public short EndPC;
            public short HandlerPC;
            public short CatchType;
        }

        public override string Name { get { return "Code"; } }
        public override int Length { get { return 4 + 3 + Code.Length + ExceptionTable.Count() * 8 + Attributes.Count() * 2; } }

        public short MaxStack { get; set; }
        public short MaxLocals { get; set; }

        public byte[] Code { get; set; }
        public List<ExceptionTableEntry> ExceptionTable { get; set; }
        public List<short> Attributes { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(MaxStack);
            writer.Write(MaxLocals);

            writer.Write(Code.Length);
            writer.Write(Code);

            writer.Write(ExceptionTable.Count());
            foreach (var ex in ExceptionTable)
            {
                writer.Write(ex.StartPC);
                writer.Write(ex.EndPC);
                writer.Write(ex.HandlerPC);
                writer.Write(ex.CatchType);
            }

            writer.Write(Attributes.Count());

            foreach (var attr in Attributes)
            {
                writer.Write(attr);
            }
        }
    }
    public class CompileAttributeExceptions : CompileAttribute
    {
        public override string Name { get { return "Exceptions"; } }
        public override int Length { get { return ExceptionTable.Count() * 2; } }

        public List<short> ExceptionTable { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(ExceptionTable.Count());

            foreach (var ex in ExceptionTable)
            {
                writer.Write(ex);
            }
        }
    }
    public class CompileAttributeInnerClasses : CompileAttribute
    {
        public struct InnerClass
        {
            public short InnerClassInfo;
            public short OuterClassInfo;
            public short InnerName;
            public List<JavaModifier> InnerModifiers;
        }

        public override string Name { get { return "InnerClasses"; } }
        public override int Length { get { return Classes.Count() * 8; } }

        public List<InnerClass> Classes { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(Classes.Count());

            foreach (var c in Classes)
            {
                var modifierValue = (short)(c.InnerModifiers.Aggregate<JavaModifier, short>(0, (current, modifier) => (short)(current | (short)modifier)) & 0x631);

                writer.Write(c.InnerClassInfo);
                writer.Write(c.OuterClassInfo);
                writer.Write(c.InnerName);
                writer.Write(modifierValue);
            }
        }
    }
    public class CompileAttributeSynthetic : CompileAttribute
    {
        public override string Name { get { return "Synthetic"; } }
        public override int Length { get { return 0; } }

        public override void Write(EndianBinaryWriter writer)
        {
        }
    }
    public class CompileAttributeSourceFile : CompileAttribute
    {
        public override string Name { get { return "SourceFile"; } }
        public override int Length { get { return 2; } }

        public short SourceFile { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(SourceFile);
        }
    }
    public class CompileAttributeLineNumberTable : CompileAttribute
    {
        public class LineNumberTableEntry
        {
            public short StartPC;
            public short LineNumber;
        }

        public override string Name { get { return "LineNumberTable"; } }
        public override int Length { get { return LineNumbers.Count() * 4; } }

        public List<LineNumberTableEntry> LineNumbers { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write((short)LineNumbers.Count());

            foreach (var ln in LineNumbers)
            {
                writer.Write(ln.StartPC);
                writer.Write(ln.LineNumber);
            }
        }
    }
    public class CompileAttributeLineLocalVariableTable : CompileAttribute
    {
        public class VariableTableEntry
        {
            public short StartPC;
            public short Length;
            public short Name;
            public short Descriptor;
            public short Index;
        }

        public override string Name { get { return "LocalVariableTable"; } }
        public override int Length { get { return Variables.Count() * 10; } }

        public List<VariableTableEntry> Variables { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write((short)Variables.Count());

            foreach (var ln in Variables)
            {
                writer.Write(ln.StartPC);
                writer.Write(ln.Length);
                writer.Write(ln.Name);
                writer.Write(ln.Descriptor);
                writer.Write(ln.Index);
            }
        }
    }
    public class CompileAttributeDeprecated : CompileAttribute
    {
        public override string Name { get { return "Deprecated"; } }
        public override int Length { get { return 0; } }

        public override void Write(EndianBinaryWriter writer)
        {
        }
    }
}
