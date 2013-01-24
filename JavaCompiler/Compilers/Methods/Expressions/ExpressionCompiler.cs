using System;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Compilers.Items;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Compilers.Methods.Expressions
{
    public class ExpressionCompiler
    {
        private readonly ExpressionNode node;

        public ExpressionCompiler(ExpressionNode node)
        {
            this.node = node;
        }

        public Item Compile(ByteCodeGenerator generator)
        {
            if (node is AssignmentNode)
            {
                return new AssignmentCompiler(node as AssignmentNode).Compile(generator);
            }
            if (node is ConditionalNode)
            {
                return new ConditionalCompiler(node as ConditionalNode).Compile(generator);
            }
            if (node is LogicalOrNode)
            {
                return new LogicalOrCompiler(node as LogicalOrNode).Compile(generator);
            }
            if (node is LogicalAndNode)
            {
                return new LogicalAndCompiler(node as LogicalAndNode).Compile(generator);
            }
            if (node is OrNode)
            {
                return new OrCompiler(node as OrNode).Compile(generator);
            }
            if (node is XorNode)
            {
                return new XorCompiler(node as XorNode).Compile(generator);
            }
            if (node is AndNode)
            {
                return new AndCompiler(node as AndNode).Compile(generator);
            }
            if (node is EqualityNode)
            {
                return new EqualityCompiler(node as EqualityNode).Compile(generator);
            }
            /*TODO:  if (node is InstaceOfNode)
            {
                return new InstanceOfCompiler(node as InstaceOfNode).Compile(generator);
            }*/
            if (node is RelationNode)
            {
                return new RelationCompiler(node as RelationNode).Compile(generator);
            }
            if (node is ShiftNode)
            {
                return new ShiftCompiler(node as ShiftNode).Compile(generator);
            }
            if (node is AdditiveNode)
            {
                return new AdditiveCompiler(node as AdditiveNode).Compile(generator);
            }
            if (node is MultiplicativeNode)
            {
                return new MultiplicativeCompiler(node as MultiplicativeNode).Compile(generator);
            }
            if (node is UnaryNode)
            {
                return new UnaryCompiler(node as UnaryNode).Compile(generator);
            }
            if (node is UnaryOtherNode)
            {
                return new UnaryOtherCompiler(node as UnaryOtherNode).Compile(generator);
            }
            if (node is PrimaryNode)
            {
                return new PrimaryCompiler(node as PrimaryNode).Compile(generator);
            }

            throw new NotImplementedException();
        }
    }
}