namespace JavaCompiler.Jbt.Tree
{
    internal unsafe struct BTreeNode
    {
        internal void** Pointers;
        internal int* Keys;
        internal BTreeNode* Parent;
        internal bool IsLeaf;
        internal int NumKeys;
        // internal BTreeNode* Next;
    }
}
