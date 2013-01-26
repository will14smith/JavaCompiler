using System;
using System.Collections.Generic;
using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt.Tree
{
    public class BTree
    {
        private const int BlockSize = 4;
        private static readonly int HalfBlockSize = (int)Math.Ceiling(BlockSize / 2d);

        private Node root;

        public int Height { get; private set; }
        public int Size { get; private set; }

        private class Node
        {
            public int M;
            public readonly Entry[] Children = new Entry[BlockSize];

            public Node(int k)
            {
                M = k;
            }

            public void Write(EndianBinaryWriter writer, int ht)
            {
                writer.Write(ht);
                writer.Write(M);
                for (var i = 0; i < M; i++)
                {
                    var child = Children[i];
                    child.Write(writer, ht - 1);
                }
            }
        }

        private class Entry
        {
            public int Key;
            public readonly List<long> Value;

            public Node Next;

            public Entry(int key, List<long> value, Node next)
            {
                Key = key;
                Value = value;

                Next = next;
            }

            public void Write(EndianBinaryWriter writer,int ht)
            {
                if(ht == 0)
                {
                    writer.Write(Key);
                }
                else
                {
                    Next.Write(writer, ht);
                }
            }
        }

        // constructor
        public BTree() { root = new Node(0); }

        public List<long> Get(int key) { return Search(root, key, Height); }
        private static List<long> Search(Node x, int key, int ht)
        {
            var children = x.Children;

            // external node
            if (ht == 0)
            {
                for (var j = 0; j < x.M; j++)
                {
                    if (key == children[j].Key) return children[j].Value;
                }
            }

            // internal node
            else
            {
                for (var j = 0; j < x.M; j++)
                {
                    if (j + 1 == x.M || key < children[j + 1].Key)
                    {
                        return Search(children[j].Next, key, ht - 1);
                    }
                }
            }

            return null;
        }


        // insert key-value pair
        // add code to check for duplicate keys
        public void Add(int key, long value)
        {
            var u = Insert(root, key, value, Height);
            Size++;
            if (u == null) return;

            // need to split root
            var t = new Node(2);

            t.Children[0] = new Entry(root.Children[0].Key, null, root);
            t.Children[1] = new Entry(u.Children[0].Key, new List<long>(), u);

            root = t;

            Height++;
        }


        private Node Insert(Node h, int key, long value, int ht)
        {
            int j;
            var t = new Entry(key, new List<long> { value }, null);

            // external node
            if (ht == 0)
            {
                for (j = 0; j < h.M; j++)
                {
                    if (key < h.Children[j].Key) break;
                }
            }

            // internal node
            else
            {
                for (j = 0; j < h.M; j++)
                {
                    if ((j + 1 != h.M) && key >= h.Children[j + 1].Key) continue;

                    var u = Insert(h.Children[j++].Next, key, value, ht - 1);
                    if (u == null) return null;

                    t.Key = u.Children[0].Key;
                    t.Next = u;

                    break;
                }
            }

            for (var i = h.M; i > j; i--)
            {
                h.Children[i] = h.Children[i - 1];
            }

            h.Children[j] = t;
            h.M++;

            return h.M < BlockSize ? null : Split(h);
        }

        // split node in half
        private static Node Split(Node h)
        {
            var t = new Node(BlockSize / 2);

            h.M = BlockSize / 2;

            for (var j = 0; j < BlockSize / 2; j++)
            {
                t.Children[j] = h.Children[BlockSize / 2 + j];
            }

            return t;
        }

        // for debugging
        public override String ToString()
        {
            return ToString(root, Height, "") + "\n";
        }

        private static String ToString(Node h, int ht, String indent)
        {
            var s = "";
            var children = h.Children;

            if (ht == 0)
            {
                for (var j = 0; j < h.M; j++)
                {
                    s += indent + children[j].Key + " " + children[j].Value + "\n";
                }
            }
            else
            {
                for (var j = 0; j < h.M; j++)
                {
                    if (j > 0) s += indent + "(" + children[j].Key + ")\n";
                    s += ToString(children[j].Next, ht - 1, indent + "     ");
                }
            }
            return s;
        }

        public void Write(EndianBinaryWriter writer)
        {
            root.Write(writer, Height);
        }
    }
}
