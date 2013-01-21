using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.IntegrationTests
{
    public abstract class BaseIntegrationTest
    {
        public ITree Parse(string source)
        {
            var input = new ANTLRStringStream(source);
            var lexer = new JavaLexer(input);
            var tokens = new CommonTokenStream(lexer);

            var parser = new JavaParser(tokens);

            return parser.javaSource().Tree;
        }
    }
}
