using JavaCompiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr.Runtime.Tree;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for CompilerTest and is intended
    ///to contain all CompilerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompilerTest
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
        ///A test for Compile
        ///</summary>
        [TestMethod()]
        public void CompileTest()
        {
            string document = string.Empty; // TODO: Initialize to an appropriate value
            Compiler target = new Compiler(document); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.Compile();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuildAst
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void BuildAstTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Compiler_Accessor target = new Compiler_Accessor(param0); // TODO: Initialize to an appropriate value
            CommonTree expected = null; // TODO: Initialize to an appropriate value
            CommonTree actual;
            actual = target.BuildAst();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Compiler Constructor
        ///</summary>
        [TestMethod()]
        public void CompilerConstructorTest()
        {
            string document = string.Empty; // TODO: Initialize to an appropriate value
            Compiler target = new Compiler(document);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
