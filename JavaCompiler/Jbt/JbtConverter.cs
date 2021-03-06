﻿using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using JavaCompiler.Compilation;
using JavaCompiler.Jbt.IO;
using JavaCompiler.Utilities;

namespace JavaCompiler.Jbt
{
    public class JbtConverter
    {
        private readonly Stream jarFile;
        public JbtConverter(Stream jarFile)
        {
            this.jarFile = jarFile;
        }

        public void Convert(EndianBinaryWriter writer)
        {
            var jbtWriter = new JbtWriter(writer);

            var zf = new ZipFile(jarFile);

            foreach (ZipEntry ze in zf)
            {
                if (!ze.IsFile) continue;
                if (!ze.Name.EndsWith(".class")) continue;

                var type = new CompileTypeInfo();

                type.Read(zf.GetInputStream(ze));

                var reader = new BinaryReader(zf.GetInputStream(ze));

                var buffer = new byte[ze.Size];
                reader.Read(buffer, 0, (int)ze.Size);

                jbtWriter.Write(type.Name, buffer);
            }

            jbtWriter.Flush();
        }
    }
}
