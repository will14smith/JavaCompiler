using System;
using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilation
{
    public abstract class CompileAttribute
    {
        public abstract string Name { get; }
        public abstract int Length { get; }

        public short NameIndex { get; set; }

        public abstract void Write(EndianBinaryWriter writer);
        public abstract CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length);

        public static CompileAttribute ReadAttribute(EndianBinaryReader reader, CompileConstant[] constants)
        {
            var nameIndex = reader.ReadInt16();
            var attributeLength = reader.ReadInt32();

            var nameConstant = constants[nameIndex] as CompileConstantUtf8;
            if (nameConstant == null) throw new InvalidOperationException();

            var name = new string(new JavaTextEncoding().GetChars(nameConstant.Value));

            switch (name)
            {
                case "ConstantValue":
                    return new CompileAttributeConstantValue().Read(reader, constants, attributeLength);
                case "Code":
                    return new CompileAttributeCode().Read(reader, constants, attributeLength);
                case "Exceptions":
                    return new CompileAttributeExceptions().Read(reader, constants, attributeLength);
                case "InnerClasses":
                    return new CompileAttributeInnerClasses().Read(reader, constants, attributeLength);
                case "Synthetic":
                    return new CompileAttributeSynthetic().Read(reader, constants, attributeLength);
                case "SourceFile":
                    return new CompileAttributeSourceFile().Read(reader, constants, attributeLength);
                case "LineNumberTable":
                    return new CompileAttributeLineNumberTable().Read(reader, constants, attributeLength);
                case "LocalVariableTable":
                    return new CompileAttributeLocalVariableTable().Read(reader, constants, attributeLength);
                case "Deprecated":
                    return new CompileAttributeDeprecated().Read(reader, constants, attributeLength);
                case "StackMapTable":
                    return new CompileAttributeStackMapTable().Read(reader, constants, attributeLength);
                case "EnclosingMethod":
                    return new CompileAttributeEnclosingMethod().Read(reader, constants, attributeLength);
                case "Signature":
                    return new CompileAttributeSignature().Read(reader, constants, attributeLength);
                case "SourceDebugExtension":
                    return new CompileAttributeSourceDebugExtension().Read(reader, constants, attributeLength);
                case "LocalVariableTypeTable":
                    return new CompileAttributeLocalVariableTypeTable().Read(reader, constants, attributeLength);
                case "RuntimeVisibleAnnotations":
                    return new CompileAttributeRuntimeVisibleAnnotations().Read(reader, constants, attributeLength);
                default:
                    throw new NotImplementedException();
            }

        }
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
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            ValueIndex = reader.ReadInt16();

            return this;
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
        public override int Length { get { return 12 + Code.Length + ExceptionTable.Count() * 8 + Attributes.Sum(x => x.Length); } }

        public short MaxStack { get; set; }
        public short MaxLocals { get; set; }

        public byte[] Code { get; set; }
        public List<ExceptionTableEntry> ExceptionTable { get; set; }
        public List<CompileAttribute> Attributes { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(MaxStack);
            writer.Write(MaxLocals);

            writer.Write(Code.Length);
            writer.Write(Code);

            writer.Write((short)ExceptionTable.Count());
            foreach (var ex in ExceptionTable)
            {
                writer.Write(ex.StartPC);
                writer.Write(ex.EndPC);
                writer.Write(ex.HandlerPC);
                writer.Write(ex.CatchType);
            }

            writer.Write((short)Attributes.Count());
            foreach (var attr in Attributes)
            {
                attr.Write(writer);
            }
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            MaxStack = reader.ReadInt16();
            MaxLocals = reader.ReadInt16();

            var codeLength = reader.ReadInt32();
            Code = reader.ReadBytes(codeLength);

            ExceptionTable = new List<ExceptionTableEntry>();
            var exceptionCount = reader.ReadInt16();
            for (var i = 0; i < exceptionCount; i++)
            {
                var exception = new ExceptionTableEntry();

                exception.StartPC = reader.ReadInt16();
                exception.EndPC = reader.ReadInt16();
                exception.HandlerPC = reader.ReadInt16();
                exception.CatchType = reader.ReadInt16();

                ExceptionTable.Add(exception);
            }

            Attributes = new List<CompileAttribute>();
            var attributeCount = reader.ReadInt16();
            for (var i = 0; i < attributeCount; i++)
            {
                Attributes.Add(ReadAttribute(reader, constants));
            }

            return this;
        }
    }
    public class CompileAttributeExceptions : CompileAttribute
    {
        public override string Name { get { return "Exceptions"; } }
        public override int Length { get { return 2 + ExceptionTable.Count() * 2; } }

        public List<short> ExceptionTable { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write((short)ExceptionTable.Count());
            foreach (var ex in ExceptionTable)
            {
                writer.Write(ex);
            }
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            ExceptionTable = new List<short>();

            var exceptionCount = reader.ReadInt16();
            for (var i = 0; i < exceptionCount; i++)
            {
                ExceptionTable.Add(reader.ReadInt16());
            }

            return this;
        }
    }
    public class CompileAttributeInnerClasses : CompileAttribute
    {
        public struct InnerClass
        {
            public short InnerClassInfo;
            public short OuterClassInfo;
            public short InnerName;
            public Modifier InnerModifier;
        }

        public override string Name { get { return "InnerClasses"; } }
        public override int Length { get { return 2 + Classes.Count() * 8; } }

        public List<InnerClass> Classes { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write((short)Classes.Count());
            foreach (var c in Classes)
            {
                var modifierValue = (short)c.InnerModifier & 0x631;

                writer.Write(c.InnerClassInfo);
                writer.Write(c.OuterClassInfo);
                writer.Write(c.InnerName);
                writer.Write(modifierValue);
            }
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            Classes = new List<InnerClass>();

            var classCount = reader.ReadInt16();
            for (var i = 0; i < classCount; i++)
            {
                var c = new InnerClass();

                c.InnerClassInfo = reader.ReadInt16();
                c.OuterClassInfo = reader.ReadInt16();
                c.InnerName = reader.ReadInt16();
                c.InnerModifier = (Modifier)reader.ReadInt16();

                Classes.Add(c);
            }

            return this;
        }
    }
    public class CompileAttributeSynthetic : CompileAttribute
    {
        public override string Name { get { return "Synthetic"; } }
        public override int Length { get { return 0; } }

        public override void Write(EndianBinaryWriter writer)
        {
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            return this;
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
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            SourceFile = reader.ReadInt16();

            return this;
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
        public override int Length { get { return 2 + LineNumbers.Count() * 4; } }

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
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            LineNumbers = new List<LineNumberTableEntry>();

            var lineCount = reader.ReadInt16();
            for (var i = 0; i < lineCount; i++)
            {
                var line = new LineNumberTableEntry();

                line.StartPC = reader.ReadInt16();
                line.LineNumber = reader.ReadInt16();

                LineNumbers.Add(line);
            }

            return this;
        }
    }
    public class CompileAttributeLocalVariableTable : CompileAttribute
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
        public override int Length { get { return 2 + Variables.Count() * 10; } }

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
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            Variables = new List<VariableTableEntry>();

            var variableCount = reader.ReadInt16();
            for (var i = 0; i < variableCount; i++)
            {
                var variable = new VariableTableEntry();

                variable.StartPC = reader.ReadInt16();
                variable.Length = reader.ReadInt16();
                variable.Name = reader.ReadInt16();
                variable.Descriptor = reader.ReadInt16();
                variable.Index = reader.ReadInt16();

                Variables.Add(variable);
            }

            return this;
        }
    }
    public class CompileAttributeDeprecated : CompileAttribute
    {
        public override string Name { get { return "Deprecated"; } }
        public override int Length { get { return 0; } }

        public override void Write(EndianBinaryWriter writer)
        {
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            return this;
        }
    }

    public class CompileAttributeStackMapTable : CompileAttribute
    {
        public enum VerificationType
        {
            Top = 0,
            Integer = 1,
            Float = 2,
            Long = 4,
            Double = 3,
            Null = 5,
            UninitializedThis = 6,
            Object = 7,
            Uninitialized = 8
        }
        public class StackFrame
        {
            public StackFrame()
            {
                Locals = new List<VerificationTypeInfo>();
                Stack = new List<VerificationTypeInfo>();
            }

            public byte Type { get; set; }
            public short OffsetDelta { get; set; }
            public List<VerificationTypeInfo> Locals { get; set; }
            public List<VerificationTypeInfo> Stack { get; set; }

            public int Length
            {
                get { throw new NotImplementedException(); }
            }
        }
        public class VerificationTypeInfo
        {
            public VerificationType Tag { get; set; }
            public short Value { get; set; }

            public void Write(EndianBinaryWriter writer)
            {
                writer.Write((byte)Tag);

                if (Tag == VerificationType.Uninitialized ||
                    Tag == VerificationType.Object)
                {
                    writer.Write(Value);
                }
            }
            public void Read(EndianBinaryReader reader)
            {
                Tag = (VerificationType)reader.ReadByte();

                if (Tag == VerificationType.Uninitialized ||
                    Tag == VerificationType.Object)
                {
                    Value = reader.ReadInt16();
                }
            }
        }

        public override string Name { get { return "StackMapTable"; } }
        public override int Length { get { return 2 + Entries.Sum(x => x.Length); } }

        public List<StackFrame> Entries { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write((short)Entries.Count());

            foreach (var entry in Entries)
            {
                writer.Write(entry.Type);
                if (entry.Type <= 63)
                {
                    // SAME
                }
                else if (entry.Type >= 64 && entry.Type <= 127)
                {
                    // SAME_LOCALS_1_STACK_ITEM
                    entry.Stack[0].Write(writer);
                }
                else if (entry.Type == 247)
                {
                    // SAME_LOCALS_1_STACK_ITEM_EXTENDED
                    writer.Write(entry.OffsetDelta);
                    entry.Stack[0].Write(writer);
                }
                else if (entry.Type >= 248 && entry.Type <= 250)
                {
                    // CHOP
                    writer.Write(entry.OffsetDelta);
                }
                else if (entry.Type == 251)
                {
                    // SAME_FRAME_EXTENDED
                    writer.Write(entry.OffsetDelta);
                }
                else if (entry.Type >= 252 && entry.Type <= 254)
                {
                    // APPEND
                    writer.Write(entry.OffsetDelta);
                    var type = (short)entry.Type;
                    for (var i = 251; i < type; i++)
                    {
                        entry.Locals[i - 251].Write(writer);

                        if (entry.Locals[i - 251].Tag == VerificationType.Long ||
                            entry.Locals[i - 251].Tag == VerificationType.Double)
                        {
                            i++;
                            type++;
                        }
                    }
                }
                else if (entry.Type == 255)
                {
                    // FULL_FRAME
                    writer.Write(entry.OffsetDelta);

                    writer.Write((short)entry.Locals.Count());
                    for (var i = 0; i < entry.Locals.Count(); i++)
                    {
                        entry.Locals[i].Write(writer);
                    }

                    writer.Write((short)entry.Stack.Count());
                    for (var i = 0; i < entry.Stack.Count(); i++)
                    {
                        entry.Stack[i].Write(writer);
                    }
                }
            }
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            Entries = new List<StackFrame>();

            var entryCount = reader.ReadInt16();
            for (var i = 0; i < entryCount; i++)
            {
                var entry = new StackFrame();

                entry.Type = reader.ReadByte();
                if (entry.Type <= 63)
                {
                    // SAME
                }
                else if (entry.Type >= 64 && entry.Type <= 127)
                {
                    // SAME_LOCALS_1_STACK_ITEM
                    var item = new VerificationTypeInfo();
                    item.Read(reader);

                    entry.Stack.Add(item);
                }
                else if (entry.Type == 247)
                {
                    // SAME_LOCALS_1_STACK_ITEM_EXTENDED
                    entry.OffsetDelta = reader.ReadInt16();

                    var item = new VerificationTypeInfo();
                    item.Read(reader);

                    entry.Stack.Add(item);
                }
                else if (entry.Type >= 248 && entry.Type <= 250)
                {
                    // CHOP
                    entry.OffsetDelta = reader.ReadInt16();
                }
                else if (entry.Type == 251)
                {
                    // SAME_FRAME_EXTENDED
                    entry.OffsetDelta = reader.ReadInt16();
                }
                else if (entry.Type >= 252 && entry.Type <= 254)
                {
                    // APPEND
                    entry.OffsetDelta = reader.ReadInt16();

                    var type = (short)entry.Type;
                    for (var x = 251; x < type; x++)
                    {
                        var item = new VerificationTypeInfo();
                        item.Read(reader);

                        entry.Locals.Add(item);
                    }
                }
                else if (entry.Type == 255)
                {
                    // FULL_FRAME
                    entry.OffsetDelta = reader.ReadInt16();

                    var localCount = reader.ReadInt16();
                    for (var x = 0; x < localCount; x++)
                    {
                        var item = new VerificationTypeInfo();
                        item.Read(reader);

                        entry.Locals.Add(item);
                    }

                    var stackCount = reader.ReadInt16();
                    for (var x = 0; x < stackCount; x++)
                    {
                        var item = new VerificationTypeInfo();
                        item.Read(reader);

                        entry.Stack.Add(item);
                    }
                }

                Entries.Add(entry);
            }

            return this;
        }
    }

    public class CompileAttributeEnclosingMethod : CompileAttribute
    {
        public override string Name { get { return "EnclosingMethod"; } }
        public override int Length { get { return 4; } }

        public short ClassIndex { get; set; }
        public short MethodIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(ClassIndex);
            writer.Write(MethodIndex);
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            ClassIndex = reader.ReadInt16();
            MethodIndex = reader.ReadInt16();

            return this;
        }
    }
    public class CompileAttributeSignature : CompileAttribute
    {
        public override string Name { get { return "Signature"; } }
        public override int Length { get { return 2; } }

        public short SignatureIndex { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(SignatureIndex);
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            SignatureIndex = reader.ReadInt16();

            return this;
        }
    }
    public class CompileAttributeSourceDebugExtension : CompileAttribute
    {
        public override string Name { get { return "SourceDebugExtension"; } }
        public override int Length { get { return DebugExtension.Length; } }

        public byte[] DebugExtension { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write(DebugExtension);
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            DebugExtension = reader.ReadBytes(length);

            return this;
        }
    }
    public class CompileAttributeLocalVariableTypeTable : CompileAttribute
    {
        public class VariableTypeTableEntry
        {
            public short StartPC;
            public short Length;
            public short Name;
            public short Signature;
            public short Index;
        }

        public override string Name { get { return "LocalVariableTypeTable"; } }
        public override int Length { get { return 2 + Variables.Count() * 10; } }

        public List<VariableTypeTableEntry> Variables { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write((short)Variables.Count());
            foreach (var ln in Variables)
            {
                writer.Write(ln.StartPC);
                writer.Write(ln.Length);
                writer.Write(ln.Name);
                writer.Write(ln.Signature);
                writer.Write(ln.Index);
            }
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            Variables = new List<VariableTypeTableEntry>();

            var variableCount = reader.ReadInt16();
            for (var i = 0; i < variableCount; i++)
            {
                var variable = new VariableTypeTableEntry();

                variable.StartPC = reader.ReadInt16();
                variable.Length = reader.ReadInt16();
                variable.Name = reader.ReadInt16();
                variable.Signature = reader.ReadInt16();
                variable.Index = reader.ReadInt16();

                Variables.Add(variable);
            }

            return this;
        }
    }

    public class CompileAttributeRuntimeVisibleAnnotations : CompileAttribute
    {
        public class Annotation
        {
            public Annotation()
            {
                ElementValues = new List<Tuple<short, ElementValue>>();
            }

            public short TypeIndex { get; set; }
            public List<Tuple<short, ElementValue>> ElementValues { get; set; }
        }
        public class ElementValue
        {
            public ElementValue()
            {
                Values = new List<ElementValue>();
            }

            public byte Tag { get; set; }

            public short ConstValueIndex { get; set; }

            public short TypeNameIndex { get; set; }
            public short ConstNameIndex { get; set; }

            public short ClassInfoIndex { get; set; }

            public Annotation AnnotationValue { get; set; }

            public List<ElementValue> Values { get; set; }
        }

        public CompileAttributeRuntimeVisibleAnnotations()
        {
            Annotations = new List<Annotation>();
        }

        public override string Name { get { return "RuntimeVisibleAnnotations"; } }
        public override int Length { get { throw new NotImplementedException(); } }

        public List<Annotation> Annotations { get; set; }

        public override void Write(EndianBinaryWriter writer)
        {
            writer.Write((short)Annotations.Count());
            foreach (var annotation in Annotations)
            {
                WriteAnnotation(annotation, writer);
            }
        }
        public override CompileAttribute Read(EndianBinaryReader reader, CompileConstant[] constants, int length)
        {
            var annotationCount = reader.ReadInt16();
            for (var i = 0; i < annotationCount; i++)
            {
                Annotations.Add(ReadAnnotation(reader, constants));
            }

            return this;
        }

        private void WriteAnnotation(Annotation annotation, EndianBinaryWriter writer)
        {
            writer.Write(annotation.TypeIndex);

            writer.Write((short)annotation.ElementValues.Count());
            foreach (var value in annotation.ElementValues)
            {
                writer.Write(value.Item1);

                WriteElementValue(value.Item2, writer);
            }
        }
        private void WriteElementValue(ElementValue value, EndianBinaryWriter writer)
        {
            switch ((char)value.Tag)
            {
                case 'B':
                case 'C':
                case 'D':
                case 'F':
                case 'I':
                case 'J':
                case 'S':
                case 'Z':
                case 's':
                    writer.Write(value.ConstValueIndex);
                    break;
                case 'e':
                    writer.Write(value.TypeNameIndex);
                    writer.Write(value.ConstNameIndex);
                    break;
                case 'c':
                    writer.Write(value.ClassInfoIndex);
                    break;
                case '@':
                    WriteAnnotation(value.AnnotationValue, writer);
                    break;
                case '[':
                    writer.Write((short)value.Values.Count());
                    foreach (var ev in value.Values)
                    {
                        WriteElementValue(ev, writer);
                    }
                    break;
            }
        }

        private Annotation ReadAnnotation(EndianBinaryReader reader, CompileConstant[] constants)
        {
            var annotation = new Annotation();

            annotation.TypeIndex = reader.ReadInt16();

            var valueCount = reader.ReadInt16();
            for (var i = 0; i < valueCount; i++)
            {
                var index = reader.ReadInt16();
                var value = ReadElementValue(reader, constants);

                annotation.ElementValues.Add(new Tuple<short, ElementValue>(index, value));
            }


            return annotation;
        }
        private ElementValue ReadElementValue(EndianBinaryReader reader, CompileConstant[] constants)
        {
            var value = new ElementValue();

            value.Tag = reader.ReadByte();

            switch ((char)value.Tag)
            {
                case 'B':
                case 'C':
                case 'D':
                case 'F':
                case 'I':
                case 'J':
                case 'S':
                case 'Z':
                case 's':
                    value.ConstValueIndex = reader.ReadInt16();
                    break;
                case 'e':
                    value.TypeNameIndex = reader.ReadInt16();
                    value.ConstNameIndex = reader.ReadInt16();
                    break;
                case 'c':
                    value.ClassInfoIndex = reader.ReadInt16();
                    break;
                case '@':
                    value.AnnotationValue = ReadAnnotation(reader, constants);
                    break;
                case '[':
                    var valueCount = reader.ReadInt16();
                    for (var i = 0; i < valueCount; i++)
                    {
                        value.Values.Add(ReadElementValue(reader, constants));
                    }
                    break;
            }

            return value;
        }
    }
}
