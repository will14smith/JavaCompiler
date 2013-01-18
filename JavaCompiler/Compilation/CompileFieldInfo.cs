using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JavaCompiler.Reflection;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilation
{
    public class CompileFieldInfo
    {
        public List<JavaModifier> Modifiers { get; set; }

        public short Name { get; set; }
        public short Descriptor { get; set; }

        public List<short> Attributes { get; set; }

        public void Write(EndianBinaryWriter writer)
        {
            var modifierValue = (short)(Modifiers.Aggregate<JavaModifier, short>(0, (current, modifier) => (short)(current | (short)modifier)) & 0xAF);

            writer.Write(modifierValue);
            writer.Write(Name);
            writer.Write(Descriptor);

            writer.Write((short)Attributes.Count());

            foreach (var attr in Attributes)
            {
                writer.Write(attr);
            }
        }
    }
}
