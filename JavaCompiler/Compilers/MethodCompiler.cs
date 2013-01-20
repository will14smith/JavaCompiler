using System.Collections.Generic;
using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Methods.BlockStatements;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Compilers
{
    public class MethodCompiler
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

            CompileBody(manager);

            methodInfo.Modifiers = method.Modifiers;
            methodInfo.Name = nameIndex;
            methodInfo.Descriptor = descriptorIndex;
            methodInfo.Attributes = attributes; //TODO: Code, Exceptions, Synthetic, Deprecated

            return methodInfo;
        }

        private List<CompileAttribute> attributes;
        private ByteCodeGenerator generator;
        private void CompileBody(CompileManager manager)
        {
            attributes = new List<CompileAttribute>();
            generator = new ByteCodeGenerator(manager);

            method.Body.ValidateType();

            new BlockCompiler(method.Body).Compile(generator);

            attributes.Add(new CompileAttributeCode
            {
                NameIndex = manager.AddConstantUtf8(new CompileAttributeCode().Name),
                Code = generator.GetBytes(),
                Attributes = new List<short>(),
                ExceptionTable = new List<CompileAttributeCode.ExceptionTableEntry>(),

                MaxLocals = 4,
                MaxStack = 2
            });
        }

        private void CompileMethodTree(MethodTree node)
        {

        }
    }
}
