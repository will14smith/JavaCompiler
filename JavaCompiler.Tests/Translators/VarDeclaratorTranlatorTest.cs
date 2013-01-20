using JavaCompiler.Translators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Tests.Translators
{
    
    
    /// <summary>
    ///This is a test class for VarDeclaratorTranlatorTest and is intended
    ///to contain all VarDeclaratorTranlatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VarDeclaratorTranlatorTest
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
        ///A test for VarDeclaratorTranlator Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void VarDeclaratorTranlatorConstructorTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            VarDeclaratorTranslator target = new VarDeclaratorTranslator(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Walk
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WalkTest()
        {

            VarDeclaratorTranslator target = new VarDeclaratorTranslator(null); // TODO: Initialize to an appropriate value
            Field expected = null; // TODO: Initialize to an appropriate value
            Field actual;
            actual = target.Walk();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
