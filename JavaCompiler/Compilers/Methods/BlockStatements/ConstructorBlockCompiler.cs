using System;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators.Methods.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.BlockStatements
{
    public class ConstructorBlockCompiler
    {
        private readonly MethodTree tree;

        public ConstructorBlockCompiler(MethodTree tree)
        {
            this.tree = tree;
        }

        public void Compile(ByteCodeGenerator generator)
        {
            MethodTreeNode first = tree.FirstOrDefault();
            if (first == null)
            {
                CompileSuperCall(generator);
            }
            else
            {
                if (first is PrimaryNode.TermConstructorCallExpression)
                {
                    var call = first as PrimaryNode.TermConstructorCallExpression;

                    CompileSuperCall(generator, call);

                    tree.RemoveAt(0);
                }
                else
                {
                    CompileSuperCall(generator);
                }
            }

            new BlockCompiler(tree).Compile(generator);

            generator.Emit(OpCodeValue.@return);
        }

        private void CompileSuperCall(ByteCodeGenerator generator)
        {
            var thisClass = (generator.Method.DeclaringType) as Class;
            thisClass.Resolve(generator.Manager.Imports);

            Class superClass = thisClass.Super;
            Method thisConstructor = generator.Method;

            var superMethod = (Method)superClass.Constructors
                                           .OrderByDescending(x => x.Parameters.Count)
                                           .FirstOrDefault(x => x.Parameters.Count <= thisConstructor.Parameters.Count);
            if (superMethod == null)
            {
                throw new InvalidOperationException();
            }

            short index = generator.Manager.AddConstantMethodref(superMethod);

            new SelfItem(generator, superClass, true).Load();
            new MemberItem(generator, superMethod, true).Invoke();
        }

        private void CompileSuperCall(ByteCodeGenerator generator, PrimaryNode.TermConstructorCallExpression call)
        {
            var target = call.IsSuper
                ? (PrimaryNode)new PrimaryNode.TermSuperExpression()
                : (PrimaryNode)new PrimaryNode.TermThisExpression();

            new PrimaryCompiler(
                    new PrimaryNode.TermFieldExpression
                    {
                        Child = target,
                        SecondChild = new PrimaryNode.TermMethodExpression { Identifier = "<init>", Arguments = call.Arguments }
                    }
            ).Compile(generator);
        }
    }
}