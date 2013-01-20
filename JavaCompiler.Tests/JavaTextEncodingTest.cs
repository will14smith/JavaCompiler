using JavaCompiler.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for JavaTextEncodingTest and is intended
    ///to contain all JavaTextEncodingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JavaTextEncodingTest
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
        ///A test for JavaTextEncoding Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void JavaTextEncodingConstructorTest()
        {
            JavaTextEncoding_Accessor target = new JavaTextEncoding_Accessor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetByteCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GetByteCountTest()
        {
            JavaTextEncoding_Accessor target = new JavaTextEncoding_Accessor(); // TODO: Initialize to an appropriate value
            char[] chars = null; // TODO: Initialize to an appropriate value
            int charIndex = 0; // TODO: Initialize to an appropriate value
            int charCount = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetByteCount(chars, charIndex, charCount);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GetBytesTest()
        {
            JavaTextEncoding_Accessor target = new JavaTextEncoding_Accessor(); // TODO: Initialize to an appropriate value
            char[] chars = null; // TODO: Initialize to an appropriate value
            int charIndex = 0; // TODO: Initialize to an appropriate value
            int charCount = 0; // TODO: Initialize to an appropriate value
            byte[] bytes = null; // TODO: Initialize to an appropriate value
            int byteIndex = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetBytes(chars, charIndex, charCount, bytes, byteIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetCharCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GetCharCountTest()
        {
            JavaTextEncoding_Accessor target = new JavaTextEncoding_Accessor(); // TODO: Initialize to an appropriate value
            byte[] bytes = null; // TODO: Initialize to an appropriate value
            int byteIndex = 0; // TODO: Initialize to an appropriate value
            int byteCount = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetCharCount(bytes, byteIndex, byteCount);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetChars
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GetCharsTest()
        {
            JavaTextEncoding_Accessor target = new JavaTextEncoding_Accessor(); // TODO: Initialize to an appropriate value
            byte[] bytes = null; // TODO: Initialize to an appropriate value
            int byteIndex = 0; // TODO: Initialize to an appropriate value
            int byteCount = 0; // TODO: Initialize to an appropriate value
            char[] chars = null; // TODO: Initialize to an appropriate value
            int charIndex = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetMaxByteCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GetMaxByteCountTest()
        {
            JavaTextEncoding_Accessor target = new JavaTextEncoding_Accessor(); // TODO: Initialize to an appropriate value
            int charCount = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetMaxByteCount(charCount);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetMaxCharCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GetMaxCharCountTest()
        {
            JavaTextEncoding_Accessor target = new JavaTextEncoding_Accessor(); // TODO: Initialize to an appropriate value
            int byteCount = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetMaxCharCount(byteCount);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
