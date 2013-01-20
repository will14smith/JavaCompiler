using JavaCompiler.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Utilities;

namespace JavaCompiler.Tests.Compilation
{
    
    
    /// <summary>
    ///This is a test class for CompileConstantLongTest and is intended
    ///to contain all CompileConstantLongTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompileConstantLongTest
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
        ///A test for CompileConstantLong Constructor
        ///</summary>
        [TestMethod()]
        public void CompileConstantLongConstructorTest()
        {
            CompileConstantLong target = new CompileConstantLong();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            CompileConstantLong target = new CompileConstantLong(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.Write(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for HValue
        ///</summary>
        [TestMethod()]
        public void HValueTest()
        {
            CompileConstantLong target = new CompileConstantLong(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            target.HValue = expected;
            actual = target.HValue;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LValue
        ///</summary>
        [TestMethod()]
        public void LValueTest()
        {
            CompileConstantLong target = new CompileConstantLong(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            target.LValue = expected;
            actual = target.LValue;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Tag
        ///</summary>
        [TestMethod()]
        public void TagTest()
        {
            CompileConstantLong target = new CompileConstantLong(); // TODO: Initialize to an appropriate value
            byte actual;
            actual = target.Tag;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
