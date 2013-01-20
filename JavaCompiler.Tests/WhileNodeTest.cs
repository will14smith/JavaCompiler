﻿using JavaCompiler.Translators.Methods.Tree.Statements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Translators.Methods.Tree;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for WhileNodeTest and is intended
    ///to contain all WhileNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WhileNodeTest
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
        ///A test for WhileNode Constructor
        ///</summary>
        [TestMethod()]
        public void WhileNodeConstructorTest()
        {
            WhileNode target = new WhileNode();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ValidateType
        ///</summary>
        [TestMethod()]
        public void ValidateTypeTest()
        {
            WhileNode target = new WhileNode(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Expression
        ///</summary>
        [TestMethod()]
        public void ExpressionTest()
        {
            WhileNode target = new WhileNode(); // TODO: Initialize to an appropriate value
            ExpressionNode expected = null; // TODO: Initialize to an appropriate value
            ExpressionNode actual;
            target.Expression = expected;
            actual = target.Expression;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Statement
        ///</summary>
        [TestMethod()]
        public void StatementTest()
        {
            WhileNode target = new WhileNode(); // TODO: Initialize to an appropriate value
            MethodTreeNode expected = null; // TODO: Initialize to an appropriate value
            MethodTreeNode actual;
            target.Statement = expected;
            actual = target.Statement;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
