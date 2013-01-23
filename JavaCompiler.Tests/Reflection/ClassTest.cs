using JavaCompiler.Reflection;
using JavaCompiler.Reflection.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Tests.Reflection
{
    
    
    /// <summary>
    ///This is a test class for ClassTest and is intended
    ///to contain all ClassTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClassTest
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
        ///A test for Class Constructor
        ///</summary>
        [TestMethod()]
        public void ClassConstructorTest()
        {
            Class target = new Class();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CanAssignTo
        ///</summary>
        [TestMethod()]
        public void CanAssignToTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            Class c = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanAssignTo(c);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsAssignableTo
        ///</summary>
        [TestMethod()]
        public void IsAssignableToTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            Class c = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsAssignableTo(c);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for ComponentType
        ///</summary>
        [TestMethod()]
        public void ComponentTypeTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.ComponentType = expected;
            actual = target.ComponentType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeclaringClass
        ///</summary>
        [TestMethod()]
        public void DeclaringClassTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.DeclaringClass = expected;
            actual = target.DeclaringClass;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Package
        ///</summary>
        [TestMethod()]
        public void PackageTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            Package expected = null; // TODO: Initialize to an appropriate value
            Package actual;
            target.Package = expected;
            actual = target.Package;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Primitive
        ///</summary>
        [TestMethod()]
        public void PrimitiveTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Primitive;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Super
        ///</summary>
        [TestMethod()]
        public void SuperTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.Super = expected;
            actual = target.Super;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Synthetic
        ///</summary>
        [TestMethod()]
        public void SyntheticTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Synthetic = expected;
            actual = target.Synthetic;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
