using System;
using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Reflection.Types.Internal;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilers.Items;
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
            if (node is PrimaryNode.TermIdentifierExpression)
            {
                var id = node as PrimaryNode.TermIdentifierExpression;

                if (scope == null)
                {
                    // try local, instance, static, super, etc...

                    Item item = TryLocal(generator, id);
                    if (item != null) return item;

                    item = TryInstance(generator, generator.Method.DeclaringType, id);
                    if (item != null) return item;

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
                        var item = TryInstance(generator, generator.Method.DeclaringType, id);
                        if (item != null) return item;
                    }
                }
                else if (scope is ClassItem)
                {
                    var c = scope as ClassItem;

                    Item item = TryInstance(generator, c.Type as DefinedType, id);
                    if (item != null) return item;
                }
            }
            if (node is PrimaryNode.TermFieldExpression)
            {
                var fieldExpr = node as PrimaryNode.TermFieldExpression;

                var item = new PrimaryCompiler(fieldExpr.Child).Compile(generator, scope);

                item.Load();
                return new PrimaryCompiler(fieldExpr.SecondChild).Compile(generator, item);
            }
            if (node is PrimaryNode.TermThisExpression)
            {
                var selfScope = (scope == null) ? generator.Method.DeclaringType : scope.Type;

                return new SelfItem(generator, selfScope, false);
            }
            if (node is PrimaryNode.TermSuperExpression)
            {
                var selfScope = (scope == null) ? generator.Method.DeclaringType : scope.Type;
                var superScope = (selfScope as Class).Super;

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

            if (node is PrimaryNode.TermMethodCallExpression)
            {
                var method = node as PrimaryNode.TermMethodCallExpression;
                string methodName;

                DefinedType parentType;
                if (node.Child is PrimaryNode.TermIdentifierExpression)
                {
                    var id = node.Child as PrimaryNode.TermIdentifierExpression;

                    methodName = id.Identifier;

                    var thisItem = new PrimaryCompiler(new PrimaryNode.TermThisExpression()).Compile(generator, scope);

                    thisItem.Load();
                    parentType = thisItem.Type as DefinedType;
                }
                else if (node.Child is PrimaryNode.TermFieldExpression)
                {
                    var field = node.Child as PrimaryNode.TermFieldExpression;
                    var id = field.SecondChild as PrimaryNode.TermIdentifierExpression;

                    if (id == null) throw new InvalidOperationException();
                    methodName = id.Identifier;

                    var objectItem = new PrimaryCompiler(field.Child).Compile(generator);

                    objectItem.Load();
                    parentType = objectItem.Type as DefinedType;
                }
                else
                {
                    throw new NotImplementedException();
                }

                parentType = ClassLocator.Find(parentType, generator.Manager.Imports) as DefinedType;
                if (parentType == null) throw new InvalidOperationException();

                IMember member = TryMember(generator, methodName, parentType, method.Arguments);
                if (member == null) throw new InvalidOperationException();

                var isStatic = (member.Modifiers & Modifier.Static) == Modifier.Static;

                foreach(var parameter in method.Arguments)
                {
                    new ExpressionCompiler(parameter).Compile(generator).Load();
                }

                return isStatic ?
                    new StaticItem(generator, member).Invoke() :
                    new MemberItem(generator, member, member.Name == "<init>").Invoke();
            }

            throw new NotImplementedException();
        }

        private static LocalItem TryLocal(ByteCodeGenerator generator, PrimaryNode.TermIdentifierExpression id)
        {
            var localVariable = generator.GetVariable(id.Identifier);

            return localVariable != null ? new LocalItem(generator, localVariable) : null;
        }
        private static Item TryInstance(ByteCodeGenerator generator, DefinedType type, PrimaryNode.TermIdentifierExpression id)
        {
            // try instance
            var field = type.Fields.FirstOrDefault(x => x.Name == id.Identifier);
            if (field == null)
            {
                if (type is Class && ((Class)type).Super != null)
                {
                    ((Class)type).Resolve(generator.Manager.Imports);

                    return TryInstance(generator, ((Class)type).Super, id);
                }

                return null;
            }

            var nonVirtual = field.Modifiers.HasFlag(Modifier.Private);
            var isStatic = field.Modifiers.HasFlag(Modifier.Static);

            return isStatic ?
                (Item)new StaticItem(generator, field) :
                (Item)new MemberItem(generator, field, nonVirtual);
        }
        private static ClassItem TryClass(ByteCodeGenerator generator, PrimaryNode.TermIdentifierExpression id)
        {
            var c = ClassLocator.Find(id.Identifier, generator.Manager.Imports);

            return c == null ? null : new ClassItem(generator, c);
        }

        private static IMember TryMember(ByteCodeGenerator generator, string name, DefinedType parentType, List<ExpressionNode> arguments)
        {
            var methods = parentType.Methods.Where(x => x.Name == name && x.Parameters.Count == arguments.Count).ToList();
            if (!methods.Any()) return null;

            //TODO: Find best method
            return methods.First();
        }
    }
}
