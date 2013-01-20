using JavaCompiler.Translators.Methods.Tree.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Reflection;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for UnaryOtherNode_UnaryCastNodeTest and is intended
    ///to contain all UnaryOtherNode_UnaryCastNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UnaryOtherNode_UnaryCastNodeTest
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
        ///A test for UnaryCastNode Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void UnaryOtherNode_UnaryCastNodeConstructorTest()
        {
            UnaryOtherNode_Accessor.UnaryCastNode target = new UnaryOtherNode_Accessor.UnaryCastNode();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ValidateType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ValidateTypeTest()
        {
            UnaryOtherNode_Accessor.UnaryCastNode target = new UnaryOtherNode_Accessor.UnaryCastNode(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Expression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ExpressionTest()
        {
            UnaryOtherNode_Accessor.UnaryCastNode target = new UnaryOtherNode_Accessor.UnaryCastNode(); // TODO: Initialize to an appropriate value
            ExpressionNode expected = null; // TODO: Initialize to an appropriate value
            ExpressionNode actual;
            target.Expression = expected;
            actual = target.Expression;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void TypeTest()
        {
            UnaryOtherNode_Accessor.UnaryCastNode target = new UnaryOtherNode_Accessor.UnaryCastNode(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.Type = expected;
            actual = target.Type;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
