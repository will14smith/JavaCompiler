using JavaCompiler.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for BigEndianBitConverterTest and is intended
    ///to contain all BigEndianBitConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BigEndianBitConverterTest
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
        ///A test for BigEndianBitConverter Constructor
        ///</summary>
        [TestMethod()]
        public void BigEndianBitConverterConstructorTest()
        {
            BigEndianBitConverter target = new BigEndianBitConverter();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CopyBytesImpl
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CopyBytesImplTest()
        {
            BigEndianBitConverter_Accessor target = new BigEndianBitConverter_Accessor(); // TODO: Initialize to an appropriate value
            long value = 0; // TODO: Initialize to an appropriate value
            int bytes = 0; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytesImpl(value, bytes, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FromBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void FromBytesTest()
        {
            BigEndianBitConverter_Accessor target = new BigEndianBitConverter_Accessor(); // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            int bytesToConvert = 0; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.FromBytes(buffer, startIndex, bytesToConvert);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsLittleEndian
        ///</summary>
        [TestMethod()]
        public void IsLittleEndianTest()
        {
            BigEndianBitConverter target = new BigEndianBitConverter(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLittleEndian();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Endianness
        ///</summary>
        [TestMethod()]
        public void EndiannessTest()
        {
            BigEndianBitConverter target = new BigEndianBitConverter(); // TODO: Initialize to an appropriate value
            Endianness actual;
            actual = target.Endianness;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
