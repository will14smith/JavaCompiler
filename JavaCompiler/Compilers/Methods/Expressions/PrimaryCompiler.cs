using System;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilers.Items;

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

                    var item = TryLocal(generator, id);
                    if (item != null) return item;

                    item = TryInstance(generator, generator.Method.DeclaringType, id);
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
                return new SelfItem(generator, false);
            }
            if (node is PrimaryNode.TermSuperExpression)
            {
                return new SelfItem(generator, true);
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

            if (node is PrimaryNode.TermMethodCallExpression)
            {
                var method = node as PrimaryNode.TermMethodCallExpression;

                //TODO: resolve method
                var objectItem = new PrimaryCompiler(method.Child).Compile(generator);

                IMember member = null;
                var isStatic = objectItem == null;

                return isStatic ?
                    new StaticItem(generator, member).Invoke() :
                    new MemberItem(generator, member, member.Name == "<init>").Invoke();
            }

            throw new NotImplementedException();
        }

        private static Item TryLocal(ByteCodeGenerator generator, PrimaryNode.TermIdentifierExpression id)
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

            var nonVirtual = (field.Modifiers & Modifier.Private) == Modifier.Private;

            return new MemberItem(generator, field, nonVirtual);
        }
    }
}
