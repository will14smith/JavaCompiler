using System;
using System.IO;
using JavaCompiler.Jbt.Tree;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Utilities;
using Type = JavaCompiler.Reflection.Types.Type;

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

            var pos = reader.ReadInt64();

            reader.Seek((int)pos, SeekOrigin.Begin);

            tree = new BTree();
            tree.Read(reader);
        }

        public Type Find(string typeName)
        {
            var locations = tree.Get(typeName.GetHashCode());
            if (locations == null || locations.Count == 0) return null;

            foreach (var location in locations)
            {
                var stream = reader.BaseStream;

                reader.Seek((int)location, SeekOrigin.Begin);

                var length = reader.ReadInt32();

                var type = ClassLoader.Load(stream);
                if (type != null && type.GetDescriptor(true) == typeName)
                {
                    return type;
                }
            }

            return null;
        }
    }
}
