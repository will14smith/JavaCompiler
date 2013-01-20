using JavaCompiler.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Utilities;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for CompileConstantInvokeDynamicTest and is intended
    ///to contain all CompileConstantInvokeDynamicTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompileConstantInvokeDynamicTest
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
        ///A test for CompileConstantInvokeDynamic Constructor
        ///</summary>
        [TestMethod()]
        public void CompileConstantInvokeDynamicConstructorTest()
        {
            CompileConstantInvokeDynamic target = new CompileConstantInvokeDynamic();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            CompileConstantInvokeDynamic target = new CompileConstantInvokeDynamic(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.Write(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BootstrapIndex
        ///</summary>
        [TestMethod()]
        public void BootstrapIndexTest()
        {
            CompileConstantInvokeDynamic target = new CompileConstantInvokeDynamic(); // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            target.BootstrapIndex = expected;
            actual = target.BootstrapIndex;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NameAndTypeIndex
        ///</summary>
        [TestMethod()]
        public void NameAndTypeIndexTest()
        {
            CompileConstantInvokeDynamic target = new CompileConstantInvokeDynamic(); // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            target.NameAndTypeIndex = expected;
            actual = target.NameAndTypeIndex;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Tag
        ///</summary>
        [TestMethod()]
        public void TagTest()
        {
            CompileConstantInvokeDynamic target = new CompileConstantInvokeDynamic(); // TODO: Initialize to an appropriate value
            byte actual;
            actual = target.Tag;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
