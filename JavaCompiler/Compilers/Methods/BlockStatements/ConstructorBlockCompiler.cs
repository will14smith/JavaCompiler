﻿using System;
using System.Linq;
using JavaCompiler.Compilation.ByteCode;
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
            var first = tree.FirstOrDefault();
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
        }

        private void CompileSuperCall(ByteCodeGenerator generator)
        {
            var thisClass = (generator.Method.DeclaringType) as Class;
            thisClass.Resolve(generator.Manager.Imports);

            var superClass = thisClass.Super;
            var thisConstructor = generator.Method;

            var superMethod = (Method)superClass.Constructors
                .OrderByDescending(x => x.Parameters.Count)
                .FirstOrDefault(x => x.Parameters.Count <= thisConstructor.Parameters.Count);
            if (superMethod == null)
            {
                throw new InvalidOperationException();
            }

            var index = generator.Manager.AddConstantMethodref(superMethod);

            generator.Emit(OpCodes.aload_0);
            generator.Emit(OpCodes.invokespecial, index);
        }
        private void CompileSuperCall(ByteCodeGenerator generator, PrimaryNode.TermConstructorCallExpression call)
        {
            if(call.IsSuper)
            {
                
            }
        }
    }
}