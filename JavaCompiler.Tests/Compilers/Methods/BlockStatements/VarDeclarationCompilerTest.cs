using JavaCompiler.Compilers.Methods.BlockStatements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using JavaCompiler.Compilation.ByteCode;

namespace JavaCompiler.Tests.Compilers.Methods.BlockStatements
{
    
    
    /// <summary>
    ///This is a test class for VarDeclarationCompilerTest and is intended
    ///to contain all VarDeclarationCompilerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VarDeclarationCompilerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for VarDeclarationCompiler Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void VarDeclarationCompilerConstructorTest()
        {
            VarDeclarationNode node = null; // TODO: Initialize to an appropriate value
            VarDeclarationCompiler target = new VarDeclarationCompiler(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Compile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileTest()
        {

            VarDeclarationCompiler target = new VarDeclarationCompiler(null); // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            target.Compile(generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
