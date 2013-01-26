using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt.Tree
{
    class BTreeNode
    {

        // Last slot is a placeholder
        public readonly BTreeEntry[] Entries = new BTreeEntry[BTree.Order];
        public int EntryCount;

        public readonly BTreeNode[] Values = new BTreeNode[BTree.Order];
        
        public BTreeNode(int entryCount)
        {
            EntryCount = entryCount;
        }

        public void Write(EndianBinaryWriter writer)
        {
            writer.Write(EntryCount);
            if (EntryCount == 0) return;

            for (var i = 0; i < EntryCount; i++)
            {
                Entries[i].Write(writer);
            }
            for (var i = 0; i < EntryCount + 1; i++)
            {
                if (Values[i] == null) Values[i] = new BTreeNode(0);

                Values[i].Write(writer);
            }
        }

        public void Read(EndianBinaryReader reader)
        {
            EntryCount = reader.ReadInt32();
            if (EntryCount == 0) return;

            for (var i = 0; i < EntryCount; i++)
            {
                Entries[i] = new BTreeEntry(0, null);
                Entries[i].Read(reader);
            }

            for (var i = 0; i < EntryCount + 1; i++)
            {
                Values[i] = new BTreeNode(0);
                Values[i].Read(reader);
            }
        }
    }
}
