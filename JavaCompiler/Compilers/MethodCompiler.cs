using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection;

namespace JavaCompiler.Compilers
{
    class MethodCompiler
    {
        private readonly JavaMethod method;
        public MethodCompiler(JavaMethod method)
        {
            this.method = method;
        }

        public CompileMethodInfo Compile(CompileManager manager)
        {
            var methodInfo = new CompileMethodInfo();

            var nameIndex = manager.AddConstantUtf8(method.Name);
            var descriptorIndex = manager.AddConstantUtf8(CompileManager.ProcessMethodDescriptor(method));

            CompileBody(manager);

            methodInfo.Modifiers = method.Modifiers;
            methodInfo.Name = nameIndex;
            methodInfo.Descriptor = descriptorIndex;
            methodInfo.Attributes = new List<short>(); //TODO: Code, Exceptions, Synthetic, Deprecated

            return methodInfo;
        }

        private Dictionary<string, byte> variableIndex = new Dictionary<string, byte>();
        private void CompileBody(CompileManager manager)
        {
            Debug.Assert(method.Body.Type == (int)JavaNodeType.BLOCK_SCOPE);

            
        }
    }
}
