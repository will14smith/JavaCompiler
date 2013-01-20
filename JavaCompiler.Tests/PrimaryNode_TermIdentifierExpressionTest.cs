using JavaCompiler.Translators.Methods.Tree.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr.Runtime.Tree;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for PrimaryNode_TermIdentifierExpressionTest and is intended
    ///to contain all PrimaryNode_TermIdentifierExpressionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrimaryNode_TermIdentifierExpressionTest
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
        ///A test for TermIdentifierExpression Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void PrimaryNode_TermIdentifierExpressionConstructorTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            PrimaryNode_Accessor.TermIdentifierExpression target = new PrimaryNode_Accessor.TermIdentifierExpression(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for TermIdentifierExpression Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void PrimaryNode_TermIdentifierExpressionConstructorTest1()
        {
            PrimaryNode_Accessor.TermIdentifierExpression target = new PrimaryNode_Accessor.TermIdentifierExpression();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ToStringTest()
        {
            PrimaryNode_Accessor.TermIdentifierExpression target = new PrimaryNode_Accessor.TermIdentifierExpression(); // TODO: Initialize to an appropriate value
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
            PrimaryNode_Accessor.TermIdentifierExpression target = new PrimaryNode_Accessor.TermIdentifierExpression(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Identifier
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void IdentifierTest()
        {
            PrimaryNode_Accessor.TermIdentifierExpression target = new PrimaryNode_Accessor.TermIdentifierExpression(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Identifier = expected;
            actual = target.Identifier;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
