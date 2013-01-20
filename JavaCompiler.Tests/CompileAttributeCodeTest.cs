using JavaCompiler.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Utilities;
using System.Collections.Generic;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for CompileAttributeCodeTest and is intended
    ///to contain all CompileAttributeCodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompileAttributeCodeTest
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
        ///A test for CompileAttributeCode Constructor
        ///</summary>
        [TestMethod()]
        public void CompileAttributeCodeConstructorTest()
        {
            CompileAttributeCode target = new CompileAttributeCode();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            CompileAttributeCode target = new CompileAttributeCode(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.Write(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Attributes
        ///</summary>
        [TestMethod()]
        public void AttributesTest()
        {
            CompileAttributeCode target = new CompileAttributeCode(); // TODO: Initialize to an appropriate value
            List<short> expected = null; // TODO: Initialize to an appropriate value
            List<short> actual;
            target.Attributes = expected;
            actual = target.Attributes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Code
        ///</summary>
        [TestMethod()]
        public void CodeTest()
        {
            CompileAttributeCode target = new CompileAttributeCode(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            target.Code = expected;
            actual = target.Code;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExceptionTable
        ///</summary>
        [TestMethod()]
        public void ExceptionTableTest()
        {
            CompileAttributeCode target = new CompileAttributeCode(); // TODO: Initialize to an appropriate value
            List<CompileAttributeCode.ExceptionTableEntry> expected = null; // TODO: Initialize to an appropriate value
            List<CompileAttributeCode.ExceptionTableEntry> actual;
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
            CompileAttributeCode target = new CompileAttributeCode(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Length;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MaxLocals
        ///</summary>
        [TestMethod()]
        public void MaxLocalsTest()
        {
            CompileAttributeCode target = new CompileAttributeCode(); // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            target.MaxLocals = expected;
            actual = target.MaxLocals;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MaxStack
        ///</summary>
        [TestMethod()]
        public void MaxStackTest()
        {
            CompileAttributeCode target = new CompileAttributeCode(); // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            target.MaxStack = expected;
            actual = target.MaxStack;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            CompileAttributeCode target = new CompileAttributeCode(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
