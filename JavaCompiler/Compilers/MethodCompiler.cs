using System.Collections.Generic;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Compilers
{
    class MethodCompiler
    {
        private readonly Method method;
        public MethodCompiler(Method method)
        {
            this.method = method;
        }

        public CompileMethodInfo Compile(CompileManager manager)
        {
            var methodInfo = new CompileMethodInfo();

            var nameIndex = manager.AddConstantUtf8(method.Name);
            var descriptorIndex = manager.AddConstantUtf8(CompileManager.ProcessMethodDescriptor(method));

            var attributes = CompileBody(manager);

            methodInfo.Modifiers = method.Modifiers;
            methodInfo.Name = nameIndex;
            methodInfo.Descriptor = descriptorIndex;
            methodInfo.Attributes = attributes; //TODO: Code, Exceptions, Synthetic, Deprecated

            return methodInfo;
        }

        private List<CompileAttribute> attributes;
        private ByteCodeGenerator generator;
        private List<CompileAttribute> CompileBody(CompileManager manager)
        {
            attributes = new List<CompileAttribute>();
            generator = new ByteCodeGenerator();

            CompileBlockScope(method.Body);

            attributes.Add(new CompileAttributeCode
            {
                NameIndex = manager.AddConstantUtf8(new CompileAttributeCode().Name),
                Code = generator.GetBytes(),
                Attributes = new List<short>(),
                ExceptionTable = new List<CompileAttributeCode.ExceptionTableEntry>()
            });

            return attributes;
        }

        private void CompileBlockScope(MethodTree node)
        {
        }

        public bool IsLocalVariable(ITree node)
        {
            return node.Type == (int)JavaNodeType.VAR_DECLARATION;
        }
        public void CompileLocalVariable(ITree node)
        {
            // modifiers, type, name
        }
    }
}
