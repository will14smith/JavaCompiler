using JavaCompiler.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for PrimativeClasses_DoubleClassTest and is intended
    ///to contain all PrimativeClasses_DoubleClassTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrimativeClasses_DoubleClassTest
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
        ///A test for DoubleClass Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void PrimativeClasses_DoubleClassConstructorTest()
        {
            PrimativeClasses_Accessor.DoubleClass target = new PrimativeClasses_Accessor.DoubleClass();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for IsAssignableTo
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void IsAssignableToTest()
        {
            PrimativeClasses_Accessor.DoubleClass target = new PrimativeClasses_Accessor.DoubleClass(); // TODO: Initialize to an appropriate value
            Class c = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsAssignableTo(c);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void NameTest()
        {
            PrimativeClasses_Accessor.DoubleClass target = new PrimativeClasses_Accessor.DoubleClass(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Name;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Primitive
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void PrimitiveTest()
        {
            PrimativeClasses_Accessor.DoubleClass target = new PrimativeClasses_Accessor.DoubleClass(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Primitive;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
