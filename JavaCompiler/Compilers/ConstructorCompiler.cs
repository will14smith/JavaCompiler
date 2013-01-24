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

        private List<CompileAttribute> attributes;
        private ByteCodeGenerator generator;

        public ConstructorCompiler(Constructor constructor)
        {
            this.constructor = constructor;
        }

        public CompileMethodInfo Compile(CompileManager manager)
        {
            constructor.Resolve(manager.Imports);

            var methodInfo = new CompileMethodInfo();

            short nameIndex = manager.AddConstantUtf8(constructor.Name);
            short descriptorIndex = manager.AddConstantUtf8(constructor.GetDescriptor());

            CompileBody(manager);

            methodInfo.Modifiers = constructor.Modifiers;
            methodInfo.Name = nameIndex;
            methodInfo.Descriptor = descriptorIndex;
            methodInfo.Attributes = attributes; //TODO: Code, Exceptions, Synthetic, Deprecated

            return methodInfo;
        }

        private void CompileBody(CompileManager manager)
        {
            attributes = new List<CompileAttribute>();
            generator = new ByteCodeGenerator(manager, (Method)constructor);

            foreach (Method.Parameter parameter in constructor.Parameters)
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
                MaxLocals = generator.MaxVariables,
                MaxStack = generator.MaxStack
            });
        }
    }
}