using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Reflection
{
    public static class CommonFinder
    {
        public static Type FindCommonType(this Type c1, Type c2)
        {
            if (c1.IsAssignableTo(c2))
            {
                return c2;
            }
            if (c2.IsAssignableTo(c1))
            {
                return c1;
            }

            // No EASY common type found
            // will have to look harder??
            return null;
        }

        public static Method FindMethod(this DefinedType type, ByteCodeGenerator generator, string name, List<Type> args)
        {
            type.Resolve(generator.Manager.Imports);

            var argCount = args == null ? 0 : args.Count;
            var methods = (name == "<init>"
                ? ((Class)type).Constructors.Select(x => (Method)x)
                : type.Methods)
                    .Where(x => x.Name == name && x.Parameters.Count == argCount);

            if (args == null || argCount == 0)
            {
                return methods.SingleOrDefault();
            }

            var method = methods
                .Where(x => x.Parameters.Zip(args, (p, a) => a.IsAssignableTo(p.Type)).All(i => i))
                // find the method with the fewest casts
                .Select(
                    x =>
                    new
                        {
                            method = x,
                            casts = x.Parameters.Zip(args, (p, a) => a.GetDescriptor() == p.Type.GetDescriptor() ? 0 : 1).Sum()
                        })
                .OrderBy(x => x.casts)
                .Select(x => x.method)
                .FirstOrDefault();

            return method;
        }
    }
}