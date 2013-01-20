using JavaCompiler.Translators.Methods.Tree.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for PrimaryNode_TermBoolLiteralExpressionTest and is intended
    ///to contain all PrimaryNode_TermBoolLiteralExpressionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrimaryNode_TermBoolLiteralExpressionTest
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
        ///A test for TermBoolLiteralExpression Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void PrimaryNode_TermBoolLiteralExpressionConstructorTest()
        {
            PrimaryNode_Accessor.TermBoolLiteralExpression target = new PrimaryNode_Accessor.TermBoolLiteralExpression();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ToStringTest()
        {
            PrimaryNode_Accessor.TermBoolLiteralExpression target = new PrimaryNode_Accessor.TermBoolLiteralExpression(); // TODO: Initialize to an appropriate value
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
            PrimaryNode_Accessor.TermBoolLiteralExpression target = new PrimaryNode_Accessor.TermBoolLiteralExpression(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Value
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ValueTest()
        {
            PrimaryNode_Accessor.TermBoolLiteralExpression target = new PrimaryNode_Accessor.TermBoolLiteralExpression(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
