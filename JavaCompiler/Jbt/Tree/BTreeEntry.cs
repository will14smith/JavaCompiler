using System.Collections.Generic;
using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt.Tree
{
    class BTreeEntry
    {
        public int Key { get; private set; }
        public List<long> Value { get; private set; }

        public BTreeEntry(int key, List<long> value)
        {
            Key = key;
            Value = value;
        }

        public void Write(EndianBinaryWriter writer)
        {
            writer.Write(Key);

            writer.Write(Value.Count);
            foreach (var t in Value)
            {
                writer.Write(t);
            }
        }

        public override string ToString()
        {
            return "Leaf - Key: " + Key;
        }
    }
}
