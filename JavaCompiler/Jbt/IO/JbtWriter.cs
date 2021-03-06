﻿using System;
using System.IO;
using JavaCompiler.Jbt.Tree;
using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt.IO
{
    public class JbtWriter : IDisposable
    {
        private bool hasFlushed;
        private readonly BTree tree;

        private readonly bool usingWrapper;
        private readonly MemoryStream memoryStream;
        private readonly EndianBinaryWriter wrappedWriter;

        private readonly EndianBinaryWriter writer;

        public JbtWriter(EndianBinaryWriter writer)
        {
            if (writer.BaseStream.CanSeek)
            {
                usingWrapper = false;

                this.writer = writer;
            }
            else
            {
                usingWrapper = true;
                wrappedWriter = writer;
                memoryStream = new MemoryStream();

                this.writer = new EndianBinaryWriter(writer.BitConverter, memoryStream);
            }

            // Placeholder for pointer
            this.writer.Write((long)0);

            tree = new BTree();
        }

        public void Write(string name, byte[] bytes)
        {
            if (hasFlushed) throw new InvalidOperationException();

            var key = name.Hash();

            // Placeholder for length
            writer.Write(bytes.Length);

            var pos = writer.BaseStream.Position;
            // Write Type
            writer.Write(bytes);

            // Add Leaf to Tree
            tree.Insert(key, (ulong) (pos - 4));
        }

        public void Flush()
        {
            if (hasFlushed) throw new InvalidOperationException();

            writer.Flush();

            var treePointer = writer.BaseStream.Position;
            // Write Tree
            tree.Write(new BinaryWriter(writer.BaseStream));
            // Set pointer to Tree
            writer.Seek(0, SeekOrigin.Begin);
            writer.Write(treePointer);

            writer.Flush();

            if (usingWrapper)
            {
                wrappedWriter.Write(memoryStream.GetBuffer());
                wrappedWriter.Flush();

                wrappedWriter.Dispose();
                memoryStream.Dispose();
            }

            hasFlushed = true;
        }

        public void Dispose()
        {
            if (!hasFlushed)
            {

            }
        }
    }
}
