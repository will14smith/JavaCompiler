using JavaCompiler.Translators.Methods.Tree.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for PrimaryNode_TermMethodCallExpressionTest and is intended
    ///to contain all PrimaryNode_TermMethodCallExpressionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrimaryNode_TermMethodCallExpressionTest
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
        ///A test for TermMethodCallExpression Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void PrimaryNode_TermMethodCallExpressionConstructorTest()
        {
            PrimaryNode_Accessor.TermMethodCallExpression target = new PrimaryNode_Accessor.TermMethodCallExpression();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ToStringTest()
        {
            PrimaryNode_Accessor.TermMethodCallExpression target = new PrimaryNode_Accessor.TermMethodCallExpression(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidateType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ValidateTypeTest()
        {
            PrimaryNode_Accessor.TermMethodCallExpression target = new PrimaryNode_Accessor.TermMethodCallExpression(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Arguments
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ArgumentsTest()
        {
            PrimaryNode_Accessor.TermMethodCallExpression target = new PrimaryNode_Accessor.TermMethodCallExpression(); // TODO: Initialize to an appropriate value
            List<ExpressionNode> expected = null; // TODO: Initialize to an appropriate value
            List<ExpressionNode> actual;
            target.Arguments = expected;
            actual = target.Arguments;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
