using System.Collections.Generic;
using JavaCompiler.Compilation;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Methods.BlockStatements;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
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
            method.Resolve(manager.Imports);

            var methodInfo = new CompileMethodInfo();

            var nameIndex = manager.AddConstantUtf8(method.Name);
            var descriptorIndex = manager.AddConstantUtf8(method.GetDescriptor());

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
            generator = new ByteCodeGenerator(manager, method);

            method.Body.ValidateType();

            foreach(var parameter in method.Parameters)
            {
                generator.DefineVariable(parameter.Name, parameter.Type);
            }

            new BlockCompiler(method.Body).Compile(generator);

            if(method.ReturnType.Name == "void")
            {
                generator.Emit(OpCodes.@return);
            }

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
