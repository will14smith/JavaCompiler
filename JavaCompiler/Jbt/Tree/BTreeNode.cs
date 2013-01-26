using System;
using System.Collections.Generic;
using System.IO;
using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt.Tree
{
    public class BTreeNode
    {
        public int Key { get; protected set; }
        public List<long> Value { get; protected set; }

        internal BTreeNode Parent;

        internal readonly BTreeNode[] Nodes;

        internal int NodeCount;

        internal readonly int MaxNodes;
        internal readonly int MinNodes;

        internal BTreeNode(int blockSize, BTreeNode parent, int key, long value)
            : this(blockSize, parent, key, new List<long> { value })
        {
        }
        internal BTreeNode(int blockSize, BTreeNode parent, int key, List<long> value)
        {
            Parent = parent;

            Key = key;
            Value = value;

            MaxNodes = blockSize;
            MinNodes = (int)Math.Ceiling(blockSize / 2m);

            Nodes = new BTreeNode[MaxNodes];
            NodeCount = 0;
        }

        public BTreeNode Search(int key)
        {
            for (var i = 0; i < NodeCount; i++)
            {
                if (key < Nodes[i].Key)
                {
                    return Search(key);
                }
                if (key == Nodes[i].Key)
                {
                    return Nodes[i];
                }
            }

            return null;
        }

        public BTreeNode Add(BTreeNode node)
        {
            var insertIndex = 0;
            for (var i = 0; i < NodeCount; i++)
            {
                if (node.Key < Nodes[i].Key)
                {
                    // Add before current node
                    insertIndex = i;
                }
                if (node.Key == Nodes[i].Key)
                {
                    Nodes[i].Value.AddRange(node.Value);

                    return this;
                }
                if (node.Key > Nodes[i].Key)
                {
                    // Add after current node
                    insertIndex = i + 1;
                }
            }

            if (NodeCount == MaxNodes)
            {
                var median = (insertIndex == MinNodes) ? node : Nodes[MinNodes];

                var newNode = new BTreeNode(MaxNodes, Parent, median.Key, median.Value);

                for (var i = 0; i < MaxNodes; i++)
                {
                    if (Nodes[i].Key < median.Key)
                    {

                    }
                }
            }
            else
            {
                // insert at index
                Array.Copy(Nodes, insertIndex, Nodes, insertIndex + 1, NodeCount - insertIndex);
                Nodes[insertIndex] = node;

                NodeCount++;

                return this;
            }
        }

        public void Write(EndianBinaryWriter writer)
        {
            var pos = writer.BaseStream.Position;

            // Length placeholder
            writer.Write(0);

            writer.Write(Value.Count);
            foreach (var value in Value)
            {
                writer.Write(value);
            }

            writer.Write(NodeCount);
            for (var i = 0; i < NodeCount; i++)
            {
                Nodes[i].Write(writer);
            }

            var length = (int)(writer.BaseStream.Position - pos);

            writer.Seek(-length, SeekOrigin.Current);
            writer.Write(length);
            writer.Seek(length, SeekOrigin.Current);
        }
    }
}
