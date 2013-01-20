using JavaCompiler.Translators.Methods.Statements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for AssertTranslatorTest and is intended
    ///to contain all AssertTranslatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AssertTranslatorTest
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
        ///A test for AssertTranslator Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void AssertTranslatorConstructorTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            AssertTranslator_Accessor target = new AssertTranslator_Accessor(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Walk
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WalkTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            AssertTranslator_Accessor target = new AssertTranslator_Accessor(param0); // TODO: Initialize to an appropriate value
            MethodTree expected = null; // TODO: Initialize to an appropriate value
            MethodTree actual;
            actual = target.Walk();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
