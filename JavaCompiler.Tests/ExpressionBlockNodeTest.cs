using JavaCompiler.Translators.Methods.Tree.Statements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for ExpressionBlockNodeTest and is intended
    ///to contain all ExpressionBlockNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExpressionBlockNodeTest
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
        ///A test for ExpressionBlockNode Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ExpressionBlockNodeConstructorTest()
        {
            ExpressionBlockNode_Accessor target = new ExpressionBlockNode_Accessor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ValidateType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ValidateTypeTest()
        {
            ExpressionBlockNode_Accessor target = new ExpressionBlockNode_Accessor(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
