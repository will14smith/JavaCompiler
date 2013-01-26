using System;
using System.Collections.Generic;
using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt.Tree
{
    public class BTree
    {
        internal const int Order = 3;

        internal static readonly int SplitMedian = (int)Math.Floor(Order / 2d);
        internal static readonly int SplitUpper = SplitMedian + 1;

        private BTreeNode root;

        public int Height { get; private set; }
        public int Size { get; private set; }

        // constructor
        public BTree() { root = new BTreeNode(0); }

        public List<long> Get(int key) { return Search(root, key); }
        private static List<long> Search(BTreeNode x, int key)
        {
            if (x == null) return null;

            for (var j = 0; j < x.EntryCount; j++)
            {
                if (key == x.Entries[j].Key)
                {
                    return x.Entries[j].Value;
                }

                if (key < x.Entries[j].Key)
                {
                    return Search(x.Values[j], key);
                }

            }

            return Search(x.Values[x.EntryCount], key);
        }


        // insert key-value pair
        // add code to check for duplicate keys
        public void Add(int key, long value)
        {
            var u = Insert(root, key, value, Height);
            Size++;
            if (u == null) return;

            // need to split root
            var t = new BTreeNode(1);

            t.Entries[0] = root.Entries[SplitMedian]; // median value

            t.Values[0] = new BTreeNode(SplitMedian); // lt nodes
            t.Values[1] = u; // gt nodes

            for (var i = 0; i <= SplitMedian; i++)
            {
                t.Values[0].Entries[i] = root.Entries[i];
                t.Values[0].Values[i] = root.Values[i];
            }

            //t.Children[0] = new BTreeEntry(root.Children[0].Key, root);
            //t.Children[1] = new BTreeEntry(u.Children[0].Key, u);

            root = t;

            Height++;
        }


        private BTreeNode Insert(BTreeNode h, int key, long value, int ht)
        {
            int j;
            var t = new BTreeEntry(key, new List<long> { value });

            // external BTreeNode
            if (ht == 0)
            {
                for (j = 0; j < h.EntryCount; j++)
                {
                    if (key == h.Entries[j].Key)
                    {
                        h.Entries[j].Value.Add(value);

                        return null;
                    }

                    if (key <= h.Entries[j].Key) break;
                }
            }
            // internal BTreeNode
            else
            {
                for (j = 0; j < h.EntryCount; j++)
                {
                    if ((j + 1 != h.EntryCount) && key >= h.Entries[j + 1].Key) continue;

                    if (key == h.Entries[j].Key)
                    {
                        h.Entries[j].Value.Add(value);

                        return null;
                    }

                    var offs = (key >= h.Entries[j].Key ? 1 : 0);

                    if (h.Values[j + offs] == null) h.Values[j + offs] = new BTreeNode(0);

                    var u = Insert(h.Values[j + offs], key, value, ht - 1);
                    if (u == null) return null;

                    j = j + offs;

                    if (j + 1 == Order)
                    {
                        var t1 = new BTreeNode(1);

                        t1.Entries[0] = h.Values[j].Entries[SplitMedian]; // median value

                        t1.Values[0] = new BTreeNode(SplitMedian); // lt nodes
                        t1.Values[1] = u; // gt nodes

                        for (var i = 0; i < SplitMedian; i++)
                        {
                            t1.Values[0].Entries[i] = h.Values[j].Entries[i];
                            t1.Values[0].Values[i] = h.Values[j].Values[i];
                        }

                        return t1;
                    }

                    t = h.Values[j].Entries[SplitMedian];

                    h.Values[j].EntryCount = SplitMedian;
                    h.Values[j + 1] = u;

                    break;
                }
            }

            for (var i = h.EntryCount; i > j; i--)
            {
                h.Entries[i] = h.Entries[i - 1];
                h.Values[i] = h.Values[i - 1];
            }

            h.Entries[j] = t;

            h.EntryCount++;

            return h.EntryCount < Order ? null : Split(h);
        }

        // split BTreeNode in half
        private static BTreeNode Split(BTreeNode h)
        {
            var t = new BTreeNode(Order - SplitUpper);

            h.EntryCount = SplitMedian;

            for (var j = SplitUpper; j < Order; j++)
            {
                t.Entries[j - SplitUpper] = h.Entries[j];
            }

            return t;
        }

        public void Write(EndianBinaryWriter writer)
        {
            root.Write(writer);
        }

        public void Read(EndianBinaryReader reader)
        {
            root = new BTreeNode(0);

            root.Read(reader);
        }
    }
}
