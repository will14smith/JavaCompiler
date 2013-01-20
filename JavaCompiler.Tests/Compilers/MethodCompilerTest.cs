using JavaCompiler.Compilers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Reflection;
using JavaCompiler.Compilation;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Tests.Compilers
{
    
    
    /// <summary>
    ///This is a test class for MethodCompilerTest and is intended
    ///to contain all MethodCompilerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MethodCompilerTest
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
        ///A test for MethodCompiler Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void MethodCompilerConstructorTest()
        {
            Method method = null; // TODO: Initialize to an appropriate value
            MethodCompiler target = new MethodCompiler(method);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Compile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileTest()
        {

            MethodCompiler target = new MethodCompiler(null); // TODO: Initialize to an appropriate value
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            CompileMethodInfo expected = null; // TODO: Initialize to an appropriate value
            CompileMethodInfo actual;
            actual = target.Compile(manager);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
