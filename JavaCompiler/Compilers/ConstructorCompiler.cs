using System.Collections.Generic;
using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Methods.BlockStatements;
using JavaCompiler.Reflection;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Compilers
{
    public class ConstructorCompiler
    {
        private readonly Constructor constructor;
        public ConstructorCompiler(Constructor constructor)
        {
            this.constructor = constructor;
        }

        public CompileMethodInfo Compile(CompileManager manager)
        {
            constructor.Resolve(manager.Imports);

            var methodInfo = new CompileMethodInfo();

            var nameIndex = manager.AddConstantUtf8(constructor.Name);
            var descriptorIndex = manager.AddConstantUtf8(constructor.GetDescriptor());

            CompileBody(manager);

            methodInfo.Modifiers = constructor.Modifiers;
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
            generator = new ByteCodeGenerator(manager, (Method)constructor);

            constructor.Body.ValidateType();

            foreach (var parameter in constructor.Parameters)
            {
                generator.DefineVariable(parameter.Name, parameter.Type);
            }

            new ConstructorBlockCompiler(constructor.Body).Compile(generator);

            attributes.Add(new CompileAttributeCode
            {
                NameIndex = manager.AddConstantUtf8(new CompileAttributeCode().Name),
                Code = generator.GetBytes(),
                Attributes = new List<CompileAttribute>(),
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
