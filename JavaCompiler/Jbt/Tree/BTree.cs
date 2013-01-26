using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt.Tree
{
    class BTree
    {
        private const int BlockSize = 10;

        private BTreeNode root;

        public BTree()
        {
            root = new BTreeNode(BlockSize, null, 0, 0);
        }

        public void Add(int key, long value)
        {
            root = root.Add(new BTreeNode(BlockSize, null, key, value));
        }

        public BTreeNode Search(int key)
        {
            return root.Search(key);
        }

        public void Write(EndianBinaryWriter writer)
        {
            root.Write(writer);
        }
    }
}
