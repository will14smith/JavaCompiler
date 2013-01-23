using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using JavaCompiler.Compilers;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Loaders;
using JavaCompiler.Translators;

namespace JavaCompiler
{
    public class Compiler
    {
        private readonly string document;

        public Compiler(string document)
        {
            this.document = document;
        }

        public List<string> ClassPath
        {
            get { return ClassLocator.SearchPaths; }
        }

        public byte[] Compile()
        {
            CommonTree tree = BuildAst(document);
            Program program = new ProgramTranslator(tree).Walk();

            return new ProgramCompiler(program).Compile();
        }

        internal static CommonTree BuildAst(string document)
        {
            var input = new ANTLRStringStream(document);
            var lexer = new JavaLexer(input);
            var tokens = new CommonTokenStream(lexer);

            var parser = new JavaParser(tokens);

            return parser.javaSource().Tree;
        }
    }
}