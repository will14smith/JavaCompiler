using System;
using System.IO;
using JavaCompiler.Compilation;
using JavaCompiler.Jbt.Tree;
using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt.IO
{
    public class JbtWriter
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

        public void Write(CompileTypeInfo type)
        {
            if (hasFlushed) throw new InvalidOperationException();

            var key = type.GetHashCode();

            var pos = writer.BaseStream.Position;

            // Placeholder for length
            writer.Write(0);

            // Write Type
            type.Write(writer);

            var length = (int)(writer.BaseStream.Position - pos);

            writer.Seek(-length, SeekOrigin.Current);
            writer.Write(length);
            writer.Seek(length, SeekOrigin.Current);

            // Add Leaf to Tree
            tree.Add(key, pos);
        }

        public void Flush()
        {
            if (hasFlushed) throw new InvalidOperationException();

            var treePointer = writer.BaseStream.Position;
            // Write Tree
            tree.Write(writer);
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
    }
}
