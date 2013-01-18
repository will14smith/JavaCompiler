using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection;

namespace JavaCompiler.Compilers
{
    class ClassCompiler
    {
        private readonly JavaClass @class;
        public ClassCompiler(JavaClass @class)
        {
            this.@class = @class;
        }

        public void Compile(CompileManager manager)
        {
            // this class
            var thisClass = manager.AddConstantClass(@class.Name);
            manager.SetThisClass(thisClass);

            // super class
            var superClass = manager.AddConstantClass(@class.SuperType);
            manager.SetSuperClass(superClass);

            // modifiers
            manager.SetModifiers(@class.Modifiers);

            // interfaces
            CompileInterfaces(manager);

            // fields
            CompileFields(manager);

            // methods
            CompileMethods(manager);

            //TODO: attributes: SourceFile, Deprecated
        }

        private void CompileInterfaces(CompileManager manager)
        {
            var interfaces = @class.Interfaces.Select(i => manager.AddConstantClass(i.Name)).ToList();

            manager.SetInterfaces(interfaces);
        }
        private void CompileFields(CompileManager manager)
        {
            foreach (var field in @class.Fields)
            {
                var fieldInfo = new CompileFieldInfo();

                var nameIndex = manager.AddConstantUtf8(field.Name);
                var descriptorIndex = manager.AddConstantUtf8Type(field.Type);

                fieldInfo.Modifiers = field.Modifiers;
                fieldInfo.Name = nameIndex;
                fieldInfo.Descriptor = descriptorIndex;
                fieldInfo.Attributes = new List<short>(); //TODO: ConstantValue, Synthetic, Deprecated 

                manager.AddField(fieldInfo);
            }
        }
        private void CompileMethods(CompileManager manager)
        {
            foreach (var method in @class.Methods)
            {
                var methodInfo = new MethodCompiler(method).Compile(manager);

                manager.AddMethod(methodInfo);
            }
        }
    }
}
