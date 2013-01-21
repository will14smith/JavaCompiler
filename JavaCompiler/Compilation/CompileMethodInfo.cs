using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Utilities;

namespace JavaCompiler.Compilation
{
    public class CompileMethodInfo
    {
        public CompileMethodInfo()
        {
            Attributes = new List<CompileAttribute>();
        }

        public Modifier Modifiers { get; set; }

        public short Name { get; set; }
        public short Descriptor { get; set; }

        public List<CompileAttribute> Attributes { get; set; }

        public void Write(EndianBinaryWriter writer)
        {
            var modifierValue = (short)((int)Modifiers & 0xD3F);

            writer.Write(modifierValue);
            writer.Write(Name);
            writer.Write(Descriptor);

            writer.Write((short)Attributes.Count());

            foreach (var attribute in Attributes)
            {
                writer.Write(attribute.NameIndex);
                writer.Write(attribute.Length);

                attribute.Write(writer);
            }
        }
    }
}
