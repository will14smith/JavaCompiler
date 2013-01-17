using System.Collections.Generic;
using System.Text;

namespace JavaCompiler.Compilation
{
    public class CompileManager
    {
        public CompileManager()
        {
            ConstantPool = new List<CompileConstant>();
        }

        public List<CompileConstant> ConstantPool { get; private set; }

        public short AddConstantClass(string className)
        {
            var nameIndex = AddConstantUtf8(className);
            var classConst = new CompileConstantClass { NameIndex = nameIndex };

            ConstantPool.Add(classConst);

            return (short)ConstantPool.IndexOf(classConst);
        }

        public short AddConstantUtf8(string s)
        {
            var value = Encoding.UTF8.GetBytes(s);
            var utf8Const = new CompileConstantUtf8 { Length = (short) value.Length, Value = value};

            ConstantPool.Add(utf8Const);

            return (short)ConstantPool.IndexOf(utf8Const);
        }
    }
}
