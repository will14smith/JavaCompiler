﻿using JavaCompiler.Translators.Methods.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.Expressions;

namespace JavaCompiler.Tests.Translators.Methods.Expressions
{
    
    
    /// <summary>
    ///This is a test class for OrTranslatorTest and is intended
    ///to contain all OrTranslatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OrTranslatorTest
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
        ///A test for OrTranslator Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void OrTranslatorConstructorTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            OrTranslator target = new OrTranslator(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Walk
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WalkTest()
        {

            OrTranslator target = new OrTranslator(null); // TODO: Initialize to an appropriate value
            OrNode expected = null; // TODO: Initialize to an appropriate value
            OrNode actual;
            actual = target.Walk();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}