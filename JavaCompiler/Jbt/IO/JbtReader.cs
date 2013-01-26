using System;
using System.IO;
using JavaCompiler.Jbt.Tree;
using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt.IO
{
    class JbtReader
    {
        private readonly BTree tree;

        private readonly MemoryStream memoryStream;
        private readonly EndianBinaryReader reader;

        public JbtReader(EndianBinaryReader reader)
        {
            if (reader.BaseStream.CanSeek)
            {
                this.reader = reader;
            }
            else
            {
                memoryStream = new MemoryStream();

                memoryStream.Write(reader.ReadBytes((int)reader.BaseStream.Length), 0, (int)reader.BaseStream.Length);

                this.reader = new EndianBinaryReader(reader.BitConverter, memoryStream);
            }

            tree = new BTree();
            tree.Read(reader);
        }

        public Stream Find(string type)
        {
            throw new NotImplementedException();
        }
    }
}
