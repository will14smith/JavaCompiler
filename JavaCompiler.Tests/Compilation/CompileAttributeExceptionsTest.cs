using JavaCompiler.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Utilities;
using System.Collections.Generic;

namespace JavaCompiler.Tests.Compilation
{
    
    
    /// <summary>
    ///This is a test class for CompileAttributeExceptionsTest and is intended
    ///to contain all CompileAttributeExceptionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompileAttributeExceptionsTest
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
        ///A test for CompileAttributeExceptions Constructor
        ///</summary>
        [TestMethod()]
        public void CompileAttributeExceptionsConstructorTest()
        {
            CompileAttributeExceptions target = new CompileAttributeExceptions();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            CompileAttributeExceptions target = new CompileAttributeExceptions(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.Write(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExceptionTable
        ///</summary>
        [TestMethod()]
        public void ExceptionTableTest()
        {
            CompileAttributeExceptions target = new CompileAttributeExceptions(); // TODO: Initialize to an appropriate value
            List<short> expected = null; // TODO: Initialize to an appropriate value
            List<short> actual;
            target.ExceptionTable = expected;
            actual = target.ExceptionTable;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Length
        ///</summary>
        [TestMethod()]
        public void LengthTest()
        {
            CompileAttributeExceptions target = new CompileAttributeExceptions(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Length;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            CompileAttributeExceptions target = new CompileAttributeExceptions(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
