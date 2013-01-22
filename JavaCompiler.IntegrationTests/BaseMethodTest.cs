using JavaCompiler.Compilers;
using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using JavaCompiler.Translators;
using JavaCompiler.Translators.Methods.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.IntegrationTests
{
    public abstract class BaseMethodTest : BaseIntegrationTest
    {
        public string Source;

        public MethodTree ExpectedTree { get; set; }
        public byte[] ExpectedByteCode { get; set; }

        [TestMethod]
        public void TreeTest()
        {
            var source = "public class Test {" + Source + "}";

            var antlrTree = Parse(source);

            var program = new ProgramTranslator(antlrTree).Walk();

            var method = (program.Type as Class).Methods[0].Body;

            Assert.AreEqual(ExpectedTree, method);
        }
        [TestMethod]
        public void CompileTest()
        {
            var source = "public class Test {" + Source + "}";

            var antlrTree = Parse(source);

            var program = new ProgramTranslator(antlrTree).Walk();
            var bytecode = new ProgramCompiler(program).Compile();

            Assert.AreEqual(ExpectedByteCode, bytecode);
        }
    }
}
