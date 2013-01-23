using JavaCompiler.Compilers.Methods.Expressions;
using JavaCompiler.Compilers.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection;

namespace JavaCompiler.Tests.Compilers.Methods.Expressions
{
    
    
    /// <summary>
    ///This is a test class for AssignmentCompilerTest and is intended
    ///to contain all AssignmentCompilerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AssignmentCompilerTest
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
        ///A test for AssignmentCompiler Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void AssignmentCompilerConstructorTest()
        {
            AssignmentNode node = null; // TODO: Initialize to an appropriate value
            AssignmentCompiler target = new AssignmentCompiler(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Compile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileTest()
        {

            AssignmentCompiler target = new AssignmentCompiler(null); // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Item expected = null; // TODO: Initialize to an appropriate value
            Item actual;
            actual = target.Compile(generator);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
