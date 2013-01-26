using System;
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
    }
}
