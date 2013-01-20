using JavaCompiler.Translators.Methods.BlockStatements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr.Runtime.Tree;
using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using System.Collections.Generic;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for VarDeclarationTranslatorTest and is intended
    ///to contain all VarDeclarationTranslatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VarDeclarationTranslatorTest
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
        ///A test for VarDeclarationTranslator Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void VarDeclarationTranslatorConstructorTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            VarDeclarationTranslator_Accessor target = new VarDeclarationTranslator_Accessor(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Walk
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WalkTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            VarDeclarationTranslator_Accessor target = new VarDeclarationTranslator_Accessor(param0); // TODO: Initialize to an appropriate value
            List<VarDeclarationNode> expected = null; // TODO: Initialize to an appropriate value
            List<VarDeclarationNode> actual;
            actual = target.Walk();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
