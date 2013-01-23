using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection.Types;

namespace JavaCompiler.Compilers
{
    public class ClassCompiler
    {
        private readonly Class @class;
        public ClassCompiler(Class @class)
        {
            this.@class = @class;
        }

        public void Compile(CompileManager manager)
        {
            // this class
            var thisClass = manager.AddConstantClass(@class);
            manager.SetThisClass(thisClass);

            // super class
            var superClass = manager.AddConstantClass(@class.Super);
            manager.SetSuperClass(superClass);

            // modifiers
            manager.SetModifiers(@class.Modifiers);

            // interfaces
            CompileInterfaces(manager);

            // fields
            CompileFields(manager);

            // constructors
            CompileConstructors(manager);

            // methods
            CompileMethods(manager);

            //TODO: attributes: SourceFile, Deprecated
        }

        private void CompileInterfaces(CompileManager manager)
        {
            var interfaces = @class.Interfaces.Select(manager.AddConstantClass).ToList();

            manager.SetInterfaces(interfaces);
        }
        private void CompileFields(CompileManager manager)
        {
            foreach (var field in @class.Fields)
            {
                var fieldInfo = new CompileFieldInfo();

                var nameIndex = manager.AddConstantUtf8(field.Name);
                var descriptorIndex = manager.AddConstantUtf8(field.ReturnType.GetDescriptor());

                fieldInfo.Modifiers = field.Modifiers;
                fieldInfo.Name = nameIndex;
                fieldInfo.Descriptor = descriptorIndex;
                fieldInfo.Attributes = new List<CompileAttribute>(); //TODO: ConstantValue, Synthetic, Deprecated 

                manager.AddField(fieldInfo);
            }
        }
        private void CompileConstructors(CompileManager manager)
        {
            foreach (var constructor in @class.Constructors)
            {
                var methodInfo = new ConstructorCompiler(constructor).Compile(manager);

                manager.AddMethod(methodInfo);
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
