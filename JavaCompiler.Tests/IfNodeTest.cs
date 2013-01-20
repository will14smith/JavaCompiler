using JavaCompiler.Translators.Methods.Tree.Statements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for IfNodeTest and is intended
    ///to contain all IfNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IfNodeTest
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
        ///A test for IfNode Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void IfNodeConstructorTest()
        {
            IfNode_Accessor target = new IfNode_Accessor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ValidateType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ValidateTypeTest()
        {
            IfNode_Accessor target = new IfNode_Accessor(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Condition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ConditionTest()
        {
            IfNode_Accessor target = new IfNode_Accessor(); // TODO: Initialize to an appropriate value
            ExpressionNode expected = null; // TODO: Initialize to an appropriate value
            ExpressionNode actual;
            target.Condition = expected;
            actual = target.Condition;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FalseBranch
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void FalseBranchTest()
        {
            IfNode_Accessor target = new IfNode_Accessor(); // TODO: Initialize to an appropriate value
            MethodTreeNode expected = null; // TODO: Initialize to an appropriate value
            MethodTreeNode actual;
            target.FalseBranch = expected;
            actual = target.FalseBranch;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TrueBranch
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void TrueBranchTest()
        {
            IfNode_Accessor target = new IfNode_Accessor(); // TODO: Initialize to an appropriate value
            MethodTreeNode expected = null; // TODO: Initialize to an appropriate value
            MethodTreeNode actual;
            target.TrueBranch = expected;
            actual = target.TrueBranch;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
