using JavaCompiler.Translators.Methods.Tree.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for MultiplicativeNodeTest and is intended
    ///to contain all MultiplicativeNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MultiplicativeNodeTest
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


        internal virtual MultiplicativeNode_Accessor CreateMultiplicativeNode_Accessor()
        {
            // TODO: Instantiate an appropriate concrete class.
            MultiplicativeNode_Accessor target = null;
            return target;
        }

        /// <summary>
        ///A test for ValidateType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ValidateTypeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            MultiplicativeNode_Accessor target = new MultiplicativeNode_Accessor(param0); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LeftChild
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void LeftChildTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            MultiplicativeNode_Accessor target = new MultiplicativeNode_Accessor(param0); // TODO: Initialize to an appropriate value
            ExpressionNode expected = null; // TODO: Initialize to an appropriate value
            ExpressionNode actual;
            target.LeftChild = expected;
            actual = target.LeftChild;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RightChild
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void RightChildTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            MultiplicativeNode_Accessor target = new MultiplicativeNode_Accessor(param0); // TODO: Initialize to an appropriate value
            ExpressionNode expected = null; // TODO: Initialize to an appropriate value
            ExpressionNode actual;
            target.RightChild = expected;
            actual = target.RightChild;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
