using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using JavaCompiler.Compilers;
using JavaCompiler.Translators;

namespace JavaCompiler
{
    public partial class Compiler
    {
        private readonly string document;

        public Compiler(string document)
        {
            this.document = document;
        }

        public byte[] Compile()
        {
            var tree = BuildAst();
            var program = new ProgramTranslator(tree).Walk();

            return new ProgramCompiler(program).Compile();
        }

        private CommonTree BuildAst()
        {
            var input = new ANTLRStringStream(document);
            var lexer = new JavaLexer(input);
            var tokens = new CommonTokenStream(lexer);

            var parser = new JavaParser(tokens);

            return parser.javaSource().Tree;
        }
    }
}
