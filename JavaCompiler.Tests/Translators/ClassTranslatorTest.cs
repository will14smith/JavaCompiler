using JavaCompiler.Translators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection;

namespace JavaCompiler.Tests.Translators
{
    
    
    /// <summary>
    ///This is a test class for ClassTranslatorTest and is intended
    ///to contain all ClassTranslatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClassTranslatorTest
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
        ///A test for ClassTranslator Constructor
        ///</summary>
        [TestMethod()]
        public void ClassTranslatorConstructorTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            ClassTranslator target = new ClassTranslator(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Walk
        ///</summary>
        [TestMethod()]
        public void WalkTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            ClassTranslator target = new ClassTranslator(node); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            actual = target.Walk();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WalkBody
        ///</summary>
        [TestMethod()]
        public void WalkBodyTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            ClassTranslator target = new ClassTranslator(node); // TODO: Initialize to an appropriate value
            ITree body = null; // TODO: Initialize to an appropriate value
            target.WalkBody(body);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
