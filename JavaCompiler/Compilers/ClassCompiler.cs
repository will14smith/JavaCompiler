using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection;
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
            short thisClass = manager.AddConstantClass(@class);
            manager.SetThisClass(thisClass);

            // super class
            short superClass = manager.AddConstantClass(@class.Super);
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
            List<short> interfaces = @class.Interfaces.Select(manager.AddConstantClass).ToList();

            manager.SetInterfaces(interfaces);
        }

        private void CompileFields(CompileManager manager)
        {
            foreach (Field field in @class.Fields)
            {
                var fieldInfo = new CompileFieldInfo();

                short nameIndex = manager.AddConstantUtf8(field.Name);
                short descriptorIndex = manager.AddConstantUtf8(field.ReturnType.GetDescriptor());

                fieldInfo.Modifiers = field.Modifiers;
                fieldInfo.Name = nameIndex;
                fieldInfo.Descriptor = descriptorIndex;
                fieldInfo.Attributes = new List<CompileAttribute>(); //TODO: ConstantValue, Synthetic, Deprecated 

                manager.AddField(fieldInfo);
            }
        }

        private void CompileConstructors(CompileManager manager)
        {
            foreach (Constructor constructor in @class.Constructors)
            {
                CompileMethodInfo methodInfo = new ConstructorCompiler(constructor).Compile(manager);

                manager.AddMethod(methodInfo);
            }
        }

        private void CompileMethods(CompileManager manager)
        {
            foreach (Method method in @class.Methods)
            {
                CompileMethodInfo methodInfo = new MethodCompiler(method).Compile(manager);

                manager.AddMethod(methodInfo);
            }
        }
    }
}