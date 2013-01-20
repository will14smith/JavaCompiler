﻿using JavaCompiler.Compilers.Methods.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Compilation.ByteCode;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for InnerNewCompilerTest and is intended
    ///to contain all InnerNewCompilerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InnerNewCompilerTest
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
        ///A test for InnerNewCompiler Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void InnerNewCompilerConstructorTest()
        {
            InnerNewNode_Accessor node = null; // TODO: Initialize to an appropriate value
            InnerNewCompiler_Accessor target = new InnerNewCompiler_Accessor(node);
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
            InnerNewCompiler_Accessor target = new InnerNewCompiler_Accessor(param0); // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            target.Compile(generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
