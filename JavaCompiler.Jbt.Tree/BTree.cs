using System;
using System.Collections.Generic;
using System.IO;

namespace JavaCompiler.Jbt.Tree
{
    public class BTree : IDisposable
    {
        internal int Order;

        public BTree()
            : this(10)
        {
        }
        public BTree(int order)
        {
            Order = order;
        }

        private unsafe BTreeNode* root;

        public unsafe List<long> Find(int key)
        {
            return PointerToList(Find(root, key));
        }
        private unsafe static long* Find(BTreeNode* root, int key)
        {
            int i;

            var node = FindLeaf(root, key);
            if (node == null) return null;

            for (i = 0; i < node->NumKeys; i++)
            {
                if (node->Keys[i] == key)
                {
                    break;
                }
            }
            return i == node->NumKeys ? null : (*((BTreeRecord*)node->Pointers[i])).Value;
        }
        private static unsafe BTreeNode* FindLeaf(BTreeNode* root, int key)
        {
            var node = root;

            if (node == null) return null;

            while (!node->IsLeaf)
            {
                var i = 0;
                while (i < node->NumKeys)
                {
                    if (key >= node->Keys[i]) i++;
                    else break;
                }

                node = (BTreeNode*)node->Pointers[i];
            }

            return node;
        }

        public unsafe void Insert(int key, long value)
        {
            if (Find(root, key) != null)
            {
                //TODO: insert value into existing leaf
                throw new NotImplementedException();
            }

            BTreeRecord* pointer = MakeRecord(value);

            if (root == null)
            {
                root = StartNewTree(key, pointer);
                return;
            }

            var leaf = FindLeaf(root, key);

            if (leaf->NumKeys < Order - 1)
            {
                InsertIntoLeaf(leaf, key, pointer);
            }
            else
            {
                root = InsertIntoLeafAfterSplitting(root, leaf, key, pointer);
            }
        }

        private static unsafe BTreeNode* InsertIntoLeaf(BTreeNode* leaf, int key, BTreeRecord* pointer)
        {
            var insertionPoint = 0;
            while (insertionPoint < leaf->NumKeys && leaf->Keys[insertionPoint] < key)
            {
                insertionPoint++;
            }

            for (var i = leaf->NumKeys; i > insertionPoint; i--)
            {
                leaf->Keys[i] = leaf->Keys[i - 1];
                leaf->Pointers[i] = leaf->Pointers[i - 1];
            }

            leaf->Keys[insertionPoint] = key;
            leaf->Pointers[insertionPoint] = pointer;

            leaf->NumKeys++;

            return leaf;
        }
        private unsafe BTreeNode* InsertIntoLeafAfterSplitting(BTreeNode* root, BTreeNode* leaf, int key, BTreeRecord* pointer)
        {
            BTreeNode* newLeaf;
            int* tempKeys;
            void** tempPointers;

            int insertionIndex, split, newKey, i, j;

            newLeaf = MakeLeaf();

            tempKeys = (int*)Memory.Alloc<int>(Order);
            tempPointers = Memory.AllocVoid(Order + 1);

            insertionIndex = 0;
            while (insertionIndex < Order - 1 && leaf->Keys[insertionIndex] < key)
            {
                insertionIndex++;
            }

            for (i = 0, j = 0; i < leaf->NumKeys; i++, j++)
            {
                if (j == insertionIndex) j++;
                tempKeys[j] = leaf->Keys[i];
                tempPointers[j] = leaf->Pointers[i];
            }

            tempKeys[insertionIndex] = key;
            tempPointers[insertionIndex] = pointer;

            leaf->NumKeys = 0;

            split = Cut(Order - 1);

            for (i = 0; i < split; i++)
            {
                leaf->Keys[i] = tempKeys[i];
                leaf->Pointers[i] = tempPointers[i];

                leaf->NumKeys++;
            }
            for (i = split, j = 0; i < Order; i++, j++)
            {
                newLeaf->Keys[j] = tempKeys[i];
                newLeaf->Pointers[j] = tempPointers[i];

                newLeaf->NumKeys++;
            }

            Memory.Free(tempKeys);
            Memory.Free(tempPointers);

            newLeaf->Pointers[Order - 1] = leaf->Pointers[Order - 1];
            leaf->Pointers[Order - 1] = newLeaf;

            for (i = leaf->NumKeys; i < Order - 1; i++)
            {
                leaf->Pointers[i] = null;
            }
            for (i = newLeaf->NumKeys; i < Order - 1; i++)
            {
                newLeaf->Pointers[i] = null;
            }

            newLeaf->Parent = leaf->Parent;
            newKey = newLeaf->Keys[0];

            return InsertIntoParent(root, leaf, newKey, newLeaf);
        }

        private unsafe BTreeNode* InsertIntoParent(BTreeNode* root, BTreeNode* left, int key, BTreeNode* right)
        {
            int leftIndex;
            BTreeNode* parent;

            parent = left->Parent;

            if (parent == null)
            {
                return InsertIntoNewRoot(left, key, right);
            }

            leftIndex = GetLeftIndex(parent, left);

            if (parent->NumKeys < Order - 1)
            {
                InsertIntoNode(parent, leftIndex, key, right);

                return root;
            }

            return InsertIntoNodeAfterSplitting(root, parent, leftIndex, key, right);
        }

        private unsafe BTreeNode* InsertIntoNewRoot(BTreeNode* left, int key, BTreeNode* right)
        {
            BTreeNode* root = MakeNode();

            root->Keys[0] = key;

            root->Pointers[0] = left;
            root->Pointers[1] = right;

            root->NumKeys++;

            root->Parent = null;
            left->Parent = root;
            right->Parent = root;

            return root;
        }
        private unsafe void InsertIntoNode(BTreeNode* node, int leftIndex, int key, BTreeNode* right)
        {
            int i;

            for (i = node->NumKeys; i > leftIndex; i--)
            {
                node->Keys[i] = node->Keys[i - 1];
                node->Pointers[i + 1] = node->Pointers[i];
            }

            node->Keys[leftIndex] = key;
            node->Pointers[leftIndex + 1] = right;

            node->NumKeys++;
        }
        private unsafe BTreeNode* InsertIntoNodeAfterSplitting(BTreeNode* root, BTreeNode* oldNode, int leftIndex, int key, BTreeNode* right)
        {
            int i, j, split, kPrime;
            BTreeNode* newNode, child;
            int* tempKeys;
            BTreeNode** tempPointers;

            tempKeys = (int*)Memory.Alloc<int>(Order);
            tempPointers = (BTreeNode**)Memory.Alloc(typeof(BTreeNode*), Order + 1);

            for (i = 0, j = 0; i < oldNode->NumKeys; i++, j++)
            {
                if (j == leftIndex) j++;
                tempKeys[j] = oldNode->Keys[i];
            }
            for (i = 0, j = 0; i < oldNode->NumKeys + 1; i++, j++)
            {
                if (j == leftIndex + 1) j++;
                tempPointers[j] = (BTreeNode*)oldNode->Pointers[i];
            }

            tempKeys[leftIndex] = key;
            tempPointers[leftIndex + 1] = right;

            split = Cut(Order);

            newNode = MakeNode();
            oldNode->NumKeys = 0;

            for (i = 0; i < split - 1; i++)
            {
                oldNode->Keys[i] = tempKeys[i];
                oldNode->Pointers[i] = tempPointers[i];

                oldNode->NumKeys++;
            }

            oldNode->Pointers[i] = tempPointers[i];
            kPrime = tempKeys[split - 1];

            for (++i, j = 0; i < Order; i++, j++)
            {
                newNode->Keys[j] = tempKeys[i];
                newNode->Pointers[j] = tempPointers[i];

                newNode->NumKeys++;
            }

            newNode->Pointers[j] = tempPointers[i];

            Memory.Free(tempKeys);
            Memory.Free(tempPointers);

            newNode->Parent = oldNode->Parent;

            for (i = 0; i <= newNode->NumKeys; i++)
            {
                child = (BTreeNode*)newNode->Pointers[i];
                child->Parent = newNode;
            }

            return InsertIntoParent(root, oldNode, kPrime, newNode);
        }

        private unsafe BTreeNode* StartNewTree(int key, BTreeRecord* pointer)
        {
            var root = MakeLeaf();

            root->Keys[0] = key;
            root->Pointers[0] = pointer;
            root->Pointers[Order - 1] = null;
            root->Parent = null;
            root->NumKeys++;

            return root;
        }
        private unsafe BTreeNode* MakeNode()
        {
            var node = (BTreeNode*)Memory.Alloc<BTreeNode>(1);

            node->Keys = (int*)Memory.Alloc<int>(Order - 1);
            node->Pointers = Memory.AllocVoid(Order);
            node->IsLeaf = false;
            node->NumKeys = 0;
            node->Parent = null;

            return node;
        }
        private unsafe BTreeNode* MakeLeaf()
        {
            BTreeNode* leaf = MakeNode();

            leaf->IsLeaf = true;

            return leaf;
        }
        private static unsafe BTreeRecord* MakeRecord(long value)
        {
            var record = (BTreeRecord*)Memory.Alloc<BTreeRecord>(1);

            record->Value = (long*)Memory.Alloc<long>(2);

            record->Value[0] = 1;
            record->Value[1] = value;

            return record;
        }

        private unsafe int GetLeftIndex(BTreeNode* parent, BTreeNode* left)
        {
            int leftIndex = 0;

            while (leftIndex <= parent->NumKeys && parent->Pointers[leftIndex] != left)
            {
                leftIndex++;
            }

            return leftIndex;
        }
        private static int Cut(int length)
        {
            if (length % 2 == 0)
            {
                return length / 2;
            }
            return length / 2 + 1;
        }
        private static unsafe List<long> PointerToList(long* find)
        {
            var list = new List<long>();

            if (find == null) return list;

            var count = find[0];
            for (var i = 0; i < count; i++)
            {
                list.Add(find[i + 1]);
            }

            return list;
        }

        public unsafe void Write(BinaryWriter writer)
        {
            WriteKeys(writer, root);
        }

        private unsafe void WriteKeys(BinaryWriter writer, BTreeNode* node)
        {
            writer.Write(node->IsLeaf);
            writer.Write(node->NumKeys);
            for (var i = 0; i < node->NumKeys; i++)
            {
                writer.Write(node->Keys[i]);

                if (!node->IsLeaf)
                {
                    WriteKeys(writer, (BTreeNode*)node->Pointers[i]);
                }
                else
                {
                    WriteValues(writer, (BTreeRecord*)node->Pointers[i]);
                }
            }

            if (!node->IsLeaf)
            {
                WriteKeys(writer, (BTreeNode*)node->Pointers[node->NumKeys]);
            }
        }

        private unsafe void WriteValues(BinaryWriter writer, BTreeRecord* record)
        {
            var count = record->Value[0];
            writer.Write(count);

            for (var i = 0; i < count; i++)
            {
                writer.Write(record->Value[i + 1]);
            }
        }

        public unsafe void Read(BinaryReader reader)
        {
            root = ReadKeys(reader, null);
        }
        private unsafe BTreeNode* ReadKeys(BinaryReader reader, BTreeNode* parent)
        {
            BTreeNode* node;

            var isLeaf = reader.ReadBoolean();
            if (isLeaf)
            {
                node = MakeLeaf();
            }
            else
            {
                node = MakeNode();
            }

            node->Parent = parent;

            var numKeys = reader.ReadInt32();
            node->NumKeys = numKeys;

            for (var i = 0; i < numKeys; i++)
            {
                node->Keys[i] = reader.ReadInt32();

                if (!node->IsLeaf)
                {
                    var child = ReadKeys(reader, node);

                    if (i > 0)
                    {
                        //var previous = (BTreeNode*)node->Pointers[i - 1];
                        //previous->Pointers[previous->NumKeys] = child;
                    }

                    node->Pointers[i] = child;
                }
                else
                {
                    node->Pointers[i] = ReadValues(reader);
                }
            }

            if (!node->IsLeaf)
            {

                var child = ReadKeys(reader, node);

                //var previous = (BTreeNode*)node->Pointers[node->NumKeys - 1];
                //previous->Pointers[previous->NumKeys] = child;

                node->Pointers[node->NumKeys] = child;
            }

            return node;
        }
        private unsafe BTreeRecord* ReadValues(BinaryReader reader)
        {
            var record = MakeRecord(0);

            var count = (int)reader.ReadInt64();

            Memory.Free(record->Value);
            record->Value = (long*)Memory.Alloc<long>(count + 1);

            record->Value[0] = count;
            for (var i = 0; i < count; i++)
            {
                record->Value[i + 1] = reader.ReadInt64();
            }

            return record;
        }

        public unsafe void Dispose()
        {
            DisposeTree(root);

            root = null;
        }

        private static unsafe void DisposeTree(BTreeNode* root)
        {
            int i;
            if (root->IsLeaf)
            {
                for (i = 0; i < root->NumKeys; i++)
                {
                    Memory.Free(root->Pointers[i]);
                }
            }
            else
            {
                for (i = 0; i < root->NumKeys + 1; i++)
                {
                    DisposeTree((BTreeNode*)root->Pointers[i]);
                }
            }

            Memory.Free(root->Keys);
            Memory.Free(root->Pointers);

            Memory.Free(root);
        }
    }
}
