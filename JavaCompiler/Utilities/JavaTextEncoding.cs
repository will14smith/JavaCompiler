using System;
using System.IO;
using System.Text;

namespace JavaCompiler.Utilities
{
    public class JavaTextEncoding : Encoding
    {
        public override int GetByteCount(char[] chars, int charIndex, int charCount)
        {
            var count = 0;

            for (var i = charIndex; i < (charIndex + charCount); i++)
            {
                var c = chars[i];

                if (c >= '\u0001' && c <= '\u007F')
                {
                    count += 1;
                }
                else if (c == '\u0000' || (c >= '\u0080' && c <= '\u07FF'))
                {
                    count += 2;
                }
                else
                {
                    count += 3;
                }
            }

            return count;
        }
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            var buffer = new MemoryStream();
            var writer = new BinaryWriter(buffer);

            for (var i = charIndex; i < (charIndex + charCount); i++)
            {
                var c = chars[i];

                if (c >= '\u0001' && c <= '\u007F')
                {
                    writer.Write((byte)(c & 0x7F));
                }
                else if (c == '\u0000' || (c >= '\u0080' && c <= '\u07FF'))
                {
                    writer.Write((byte)(((c >> 6) & 0x1F) | 0xC0));
                    writer.Write((byte)((c & 0x3F) | 0x80));
                }
                else
                {
                    writer.Write((byte)(((c >> 12) & 0xF) | 0xE0));
                    writer.Write((byte)(((c >> 6) & 0x3F) | 0x80));
                    writer.Write((byte)((c & 0x3F) | 0x80));
                }
            }

            writer.Flush();

            var bufferBytes = buffer.GetBuffer();
            Array.Copy(bufferBytes, 0, bytes, byteIndex, buffer.Length);

            return bufferBytes.Length;
        }

        public override int GetCharCount(byte[] bytes, int byteIndex, int byteCount)
        {
            var count = 0;

            for (var i = byteIndex; i < (byteIndex + byteCount); i++)
            {
                var b1 = bytes[i];

                if ((b1 & 0x80) == 0x80)
                {
                    i += (b1 & 0xC0) == 0xC0 ? 1 : 2;
                }

                count++;
            }

            return count;
        }
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            var count = 0;

            for (var i = byteIndex; i < (byteIndex + byteCount); i++)
            {
                var b1 = bytes[i];

                char c;
                if ((b1 & 0x80) == 0x0)
                {
                    c = (char)b1;
                }
                else if ((b1 & 0xC0) == 0xC0)
                {
                    var b2 = bytes[++i];

                    c = (char)(((b1 & 0x1f) << 6) + (b2 & 0x3f));
                }
                else
                {
                    var b2 = bytes[++i];
                    var b3 = bytes[++i];

                    c = (char)(((b1 & 0xf) << 12) + ((b2 & 0x3f) << 6) + (b3 & 0x3f));
                }

                chars[charIndex++] = c;

                count++;
            }

            return count;
        }

        public override int GetMaxByteCount(int charCount)
        {
            return charCount * 3;
        }
        public override int GetMaxCharCount(int byteCount)
        {
            return byteCount;
        }
    }
}
