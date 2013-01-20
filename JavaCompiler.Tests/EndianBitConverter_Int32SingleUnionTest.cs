using JavaCompiler.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for EndianBitConverter_Int32SingleUnionTest and is intended
    ///to contain all EndianBitConverter_Int32SingleUnionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EndianBitConverter_Int32SingleUnionTest
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
        ///A test for Int32SingleUnion Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void EndianBitConverter_Int32SingleUnionConstructorTest()
        {
            float f = 0F; // TODO: Initialize to an appropriate value
            EndianBitConverter_Accessor.Int32SingleUnion target = new EndianBitConverter_Accessor.Int32SingleUnion(f);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Int32SingleUnion Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void EndianBitConverter_Int32SingleUnionConstructorTest1()
        {
            int i = 0; // TODO: Initialize to an appropriate value
            EndianBitConverter_Accessor.Int32SingleUnion target = new EndianBitConverter_Accessor.Int32SingleUnion(i);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AsInt32
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void AsInt32Test()
        {
            EndianBitConverter_Accessor.Int32SingleUnion target = new EndianBitConverter_Accessor.Int32SingleUnion(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.AsInt32;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AsSingle
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void AsSingleTest()
        {
            EndianBitConverter_Accessor.Int32SingleUnion target = new EndianBitConverter_Accessor.Int32SingleUnion(); // TODO: Initialize to an appropriate value
            float actual;
            actual = target.AsSingle;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
