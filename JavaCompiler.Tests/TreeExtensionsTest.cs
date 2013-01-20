using JavaCompiler.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr.Runtime.Tree;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for TreeExtensionsTest and is intended
    ///to contain all TreeExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TreeExtensionsTest
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
        ///A test for IsAdditiveExpression
        ///</summary>
        [TestMethod()]
        public void IsAdditiveExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsAdditiveExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsArrayInitialiserExpression
        ///</summary>
        [TestMethod()]
        public void IsArrayInitialiserExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsArrayInitialiserExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsAssignExpression
        ///</summary>
        [TestMethod()]
        public void IsAssignExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsAssignExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsBlock
        ///</summary>
        [TestMethod()]
        public void IsBlockTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsBlock(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsEqualityExpression
        ///</summary>
        [TestMethod()]
        public void IsEqualityExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsEqualityExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsExpression
        ///</summary>
        [TestMethod()]
        public void IsExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsLiteral
        ///</summary>
        [TestMethod()]
        public void IsLiteralTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsLiteral(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsMultiplicativeExpression
        ///</summary>
        [TestMethod()]
        public void IsMultiplicativeExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsMultiplicativeExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsNewExpression
        ///</summary>
        [TestMethod()]
        public void IsNewExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsNewExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsNewInnerExpression
        ///</summary>
        [TestMethod()]
        public void IsNewInnerExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsNewInnerExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsPrimaryExpression
        ///</summary>
        [TestMethod()]
        public void IsPrimaryExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsPrimaryExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsQualifiedExpression
        ///</summary>
        [TestMethod()]
        public void IsQualifiedExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsQualifiedExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsRelationalExpression
        ///</summary>
        [TestMethod()]
        public void IsRelationalExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsRelationalExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsShiftExpression
        ///</summary>
        [TestMethod()]
        public void IsShiftExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsShiftExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsStatement
        ///</summary>
        [TestMethod()]
        public void IsStatementTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsStatement(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsTypeDeclaration
        ///</summary>
        [TestMethod()]
        public void IsTypeDeclarationTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsTypeDeclaration(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsUnaryExpression
        ///</summary>
        [TestMethod()]
        public void IsUnaryExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsUnaryExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsUnaryOtherExpression
        ///</summary>
        [TestMethod()]
        public void IsUnaryOtherExpressionTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsUnaryOtherExpression(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsVarDeclaration
        ///</summary>
        [TestMethod()]
        public void IsVarDeclarationTest()
        {
            ITree child = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = TreeExtensions.IsVarDeclaration(child);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
