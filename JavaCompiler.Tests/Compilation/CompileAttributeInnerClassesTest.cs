using JavaCompiler.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Utilities;
using System.Collections.Generic;

namespace JavaCompiler.Tests.Compilation
{
    
    
    /// <summary>
    ///This is a test class for CompileAttributeInnerClassesTest and is intended
    ///to contain all CompileAttributeInnerClassesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompileAttributeInnerClassesTest
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
        ///A test for CompileAttributeInnerClasses Constructor
        ///</summary>
        [TestMethod()]
        public void CompileAttributeInnerClassesConstructorTest()
        {
            CompileAttributeInnerClasses target = new CompileAttributeInnerClasses();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            CompileAttributeInnerClasses target = new CompileAttributeInnerClasses(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.Write(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Classes
        ///</summary>
        [TestMethod()]
        public void ClassesTest()
        {
            CompileAttributeInnerClasses target = new CompileAttributeInnerClasses(); // TODO: Initialize to an appropriate value
            List<CompileAttributeInnerClasses.InnerClass> expected = null; // TODO: Initialize to an appropriate value
            List<CompileAttributeInnerClasses.InnerClass> actual;
            target.Classes = expected;
            actual = target.Classes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Length
        ///</summary>
        [TestMethod()]
        public void LengthTest()
        {
            CompileAttributeInnerClasses target = new CompileAttributeInnerClasses(); // TODO: Initialize to an appropriate value
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
            CompileAttributeInnerClasses target = new CompileAttributeInnerClasses(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
