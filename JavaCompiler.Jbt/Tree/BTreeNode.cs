using System.Collections.Generic;

namespace JavaCompiler.Jbt.Tree
{
    public class BTreeNode
    {
        internal List<BTreeNode> Keys { get; set; }

        internal BTreeNode() { }
        
        internal readonly int BlockSize;
        internal BTreeNode(int blockSize)
        {
            BlockSize = blockSize;
        }


    }
}
