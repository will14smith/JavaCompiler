using JavaCompiler.Compilers.Methods.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilation.ByteCode;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for PrimaryCompilerTest and is intended
    ///to contain all PrimaryCompilerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrimaryCompilerTest
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
        ///A test for PrimaryCompiler Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void PrimaryCompilerConstructorTest()
        {
            PrimaryNode_Accessor node = null; // TODO: Initialize to an appropriate value
            PrimaryCompiler_Accessor target = new PrimaryCompiler_Accessor(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Compile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            PrimaryCompiler_Accessor target = new PrimaryCompiler_Accessor(param0); // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Variable expected = null; // TODO: Initialize to an appropriate value
            Variable actual;
            actual = target.Compile(generator);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CompileDecimal
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileDecimalTest()
        {
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            PrimaryNode_Accessor.TermDecimalLiteralExpression primaryNode = null; // TODO: Initialize to an appropriate value
            Variable expected = null; // TODO: Initialize to an appropriate value
            Variable actual;
            actual = PrimaryCompiler_Accessor.CompileDecimal(generator, primaryNode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CompileMethodCall
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileMethodCallTest()
        {
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            PrimaryNode_Accessor.TermMethodCallExpression termMethodCallExpression = null; // TODO: Initialize to an appropriate value
            Variable expected = null; // TODO: Initialize to an appropriate value
            Variable actual;
            actual = PrimaryCompiler_Accessor.CompileMethodCall(generator, termMethodCallExpression);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
