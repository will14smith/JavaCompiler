using System;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using Array = JavaCompiler.Reflection.Types.Array;
using Type = JavaCompiler.Reflection.Types.Type;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class PrimaryCompiler
    {
        private readonly PrimaryNode node;

        public PrimaryCompiler(PrimaryNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            return Compile(generator, null);
        }

        public Item Compile(ByteCodeGenerator generator, Item scope)
        {
            var scopeType = (scope == null
                ? generator.Method.DeclaringType
                : ClassLocator.Find(scope.Type, generator.Manager.Imports)) as DefinedType;

            if (node is PrimaryNode.TermIdentifierExpression)
            {
                var id = node as PrimaryNode.TermIdentifierExpression;

                return CompileIdentifier(generator, scope, id);
            }
            if (node is PrimaryNode.TermFieldExpression)
            {
                var field = node as PrimaryNode.TermFieldExpression;

                return CompileField(generator, scope, field);
            }
            if (node is PrimaryNode.TermThisExpression)
            {
                return new SelfItem(generator, scopeType, false);
            }
            if (node is PrimaryNode.TermSuperExpression)
            {
                Class superScope = (scopeType as Class).Super;

                return new SelfItem(generator, superScope, true);
            }

            if (node is PrimaryNode.TermDecimalLiteralExpression)
            {
                var i = node as PrimaryNode.TermDecimalLiteralExpression;

                return new ImmediateItem(generator, PrimativeTypes.Int, i.Value);
            }
            if (node is PrimaryNode.TermBoolLiteralExpression)
            {
                var b = node as PrimaryNode.TermBoolLiteralExpression;

                return new ImmediateItem(generator, PrimativeTypes.Boolean, b.Value);
            }
            if (node is PrimaryNode.TermCharLiteralExpression)
            {
                var b = node as PrimaryNode.TermCharLiteralExpression;

                return new ImmediateItem(generator, PrimativeTypes.Char, b.Value);
            }
            if (node is PrimaryNode.TermFloatLiteralExpression)
            {
                var b = node as PrimaryNode.TermFloatLiteralExpression;

                return new ImmediateItem(generator, PrimativeTypes.Float, b.Value);
            }
            if (node is PrimaryNode.TermStringLiteralExpression)
            {
                var s = node as PrimaryNode.TermStringLiteralExpression;

                return new ImmediateItem(generator, new PlaceholderType { Name = "java.lang.String" }, s.Value);
            }
            if (node is PrimaryNode.TermMethodExpression)
            {
                var method = node as PrimaryNode.TermMethodExpression;

                return CompileMethod(generator, scopeType, method);
            }

            if (node is PrimaryNode.TermArrayExpression)
            {
                var array = node as PrimaryNode.TermArrayExpression;

                return CompileArray(generator, scope, array);
            }

            throw new NotImplementedException();
        }

        private static Item CompileIdentifier(ByteCodeGenerator generator, Item scope, PrimaryNode.TermIdentifierExpression id)
        {
            if (scope == null)
            {
                // try local, instance, static, super, etc...

                Item item = TryLocal(generator, id);
                if (item != null) return item;

                item = TryInstance(generator, generator.Method.DeclaringType, id);
                if (item != null)
                {
                    if (item is MemberItem)
                    {
                        new SelfItem(generator, generator.Method.DeclaringType, false).Load();
                    }

                    return item;
                }

                item = TryClass(generator, id);
                if (item != null) return item;
            }
            else if (scope is SelfItem)
            {
                var self = scope as SelfItem;

                if (self.IsSuper)
                {
                    // try super
                }
                else
                {
                    Item item = TryInstance(generator, generator.Method.DeclaringType, id);
                    if (item != null) return item;
                }
            }
            else if (scope is ClassItem)
            {
                var c = scope as ClassItem;

                Item item = TryInstance(generator, c.Type, id);
                if (item != null) return item;
            }
            else if (scope is LocalItem)
            {
                var c = scope as LocalItem;

                var item = TryInstance(generator, c.Type, id);
                if (item != null) return item;
            }

            throw new NotImplementedException();
        }
        private static Item CompileField(ByteCodeGenerator generator, Item scope, PrimaryNode.TermFieldExpression field)
        {
            var item = new PrimaryCompiler(field.Child).Compile(generator, scope);

            item.Load();
            return new PrimaryCompiler(field.SecondChild).Compile(generator, item);
        }
        private static Item CompileMethod(ByteCodeGenerator generator, DefinedType parentType, PrimaryNode.TermMethodExpression id)
        {
            generator.Kill();
            var args = id.Arguments.Select(parameter => new TranslationCompiler(parameter).Compile(generator).Type).ToList();
            generator.Revive();

            var method = parentType.FindMethod(generator, id.Identifier, args);
            if (method == null) throw new InvalidOperationException();

            foreach (var arg in method.Parameters.Zip(id.Arguments, (dst, src) => new { dst, src }))
            {
                new TranslationCompiler(arg.src, arg.dst.Type).Compile(generator).Load();
            }

            var item = method.Modifiers.HasFlag(Modifier.Static)
               ? (Item)new StaticItem(generator, method)
               : new MemberItem(generator, method, method.Name == "<init>");

            return item.Invoke();
        }

        private static Item CompileArray(ByteCodeGenerator generator, Item scope, PrimaryNode.TermArrayExpression array)
        {
            var item = new PrimaryCompiler(array.Child).Compile(generator, scope);
            item.Load();

            new ExpressionCompiler(array.Index).Compile(generator).Load();

            var result = item.Type as Array;

            return new IndexedItem(generator, result.ArrayType);
        }

        private static LocalItem TryLocal(ByteCodeGenerator generator, PrimaryNode.TermIdentifierExpression id)
        {
            Variable localVariable = generator.GetVariable(id.Identifier);

            return localVariable != null ? new LocalItem(generator, localVariable) : null;
        }
        private static Item TryInstance(ByteCodeGenerator generator, Type type, PrimaryNode.TermIdentifierExpression id)
        {
            if (type is Array)
            {
                if (id.Identifier == "length")
                {
                    generator.Emit(OpCodeValue.arraylength);
                    return new StackItem(generator, PrimativeTypes.Int);
                }
            }

            var definedType = type as DefinedType;
            if (definedType == null) return null;

            // try instance
            Field field = definedType.Fields.FirstOrDefault(x => x.Name == id.Identifier);
            if (field == null)
            {
                if (type is Class && ((Class)type).Super != null)
                {
                    definedType.Resolve(generator.Manager.Imports);

                    return TryInstance(generator, ((Class)type).Super, id);
                }

                return null;
            }

            bool nonVirtual = field.Modifiers.HasFlag(Modifier.Private);
            bool isStatic = field.Modifiers.HasFlag(Modifier.Static);

            return isStatic
                       ? new StaticItem(generator, field)
                       : (Item)new MemberItem(generator, field, nonVirtual);
        }
        private static ClassItem TryClass(ByteCodeGenerator generator, PrimaryNode.TermIdentifierExpression id)
        {
            var c = ClassLocator.Find(id.Identifier, generator.Manager.Imports);

            return c == null ? null : new ClassItem(generator, c);
        }
    }
}