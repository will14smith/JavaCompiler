using JavaCompiler.Compilation.ByteCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Reflection;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for VariableTest and is intended
    ///to contain all VariableTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VariableTest
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
        ///A test for Variable Constructor
        ///</summary>
        [TestMethod()]
        public void VariableConstructorTest()
        {
            Class type = null; // TODO: Initialize to an appropriate value
            Variable target = new Variable(type);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Variable Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void VariableConstructorTest1()
        {
            short index = 0; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Class type = null; // TODO: Initialize to an appropriate value
            Variable_Accessor target = new Variable_Accessor(index, name, type);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CanAssign
        ///</summary>
        [TestMethod()]
        public void CanAssignTest()
        {
            Class type = null; // TODO: Initialize to an appropriate value
            Variable target = new Variable(type); // TODO: Initialize to an appropriate value
            Class c = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanAssign(c);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsAssignableTo
        ///</summary>
        [TestMethod()]
        public void IsAssignableToTest()
        {
            Class type = null; // TODO: Initialize to an appropriate value
            Variable target = new Variable(type); // TODO: Initialize to an appropriate value
            Class c = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsAssignableTo(c);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void IndexTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Variable_Accessor target = new Variable_Accessor(param0); // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            target.Index = expected;
            actual = target.Index;
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
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Variable_Accessor target = new Variable_Accessor(param0); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void TypeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Variable_Accessor target = new Variable_Accessor(param0); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.Type = expected;
            actual = target.Type;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
