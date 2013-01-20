using JavaCompiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr.Runtime;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for JavaLexer_DFA28Test and is intended
    ///to contain all JavaLexer_DFA28Test Unit Tests
    ///</summary>
    [TestClass()]
    public class JavaLexer_DFA28Test
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
        ///A test for DFA28 Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void JavaLexer_DFA28ConstructorTest()
        {
            BaseRecognizer recognizer = null; // TODO: Initialize to an appropriate value
            JavaLexer_Accessor.DFA28 target = new JavaLexer_Accessor.DFA28(recognizer);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ErrorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaLexer_Accessor.DFA28 target = new JavaLexer_Accessor.DFA28(param0); // TODO: Initialize to an appropriate value
            NoViableAltException nvae = null; // TODO: Initialize to an appropriate value
            target.Error(nvae);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void DescriptionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaLexer_Accessor.DFA28 target = new JavaLexer_Accessor.DFA28(param0); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Description;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
