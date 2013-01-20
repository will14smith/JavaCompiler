using JavaCompiler.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for ConstructorTest and is intended
    ///to contain all ConstructorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConstructorTest
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
        ///A test for Constructor Constructor
        ///</summary>
        [TestMethod()]
        public void ConstructorConstructorTest()
        {
            Constructor target = new Constructor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DeclaringClass
        ///</summary>
        [TestMethod()]
        public void DeclaringClassTest()
        {
            Constructor target = new Constructor(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.DeclaringClass = expected;
            actual = target.DeclaringClass;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExceptionTypes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ExceptionTypesTest()
        {
            Constructor_Accessor target = new Constructor_Accessor(); // TODO: Initialize to an appropriate value
            List<Class> expected = null; // TODO: Initialize to an appropriate value
            List<Class> actual;
            target.ExceptionTypes = expected;
            actual = target.ExceptionTypes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenericExceptionTypes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GenericExceptionTypesTest()
        {
            Constructor_Accessor target = new Constructor_Accessor(); // TODO: Initialize to an appropriate value
            List<IType> expected = null; // TODO: Initialize to an appropriate value
            List<IType> actual;
            target.GenericExceptionTypes = expected;
            actual = target.GenericExceptionTypes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenericParameterTypes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GenericParameterTypesTest()
        {
            Constructor_Accessor target = new Constructor_Accessor(); // TODO: Initialize to an appropriate value
            List<IType> expected = null; // TODO: Initialize to an appropriate value
            List<IType> actual;
            target.GenericParameterTypes = expected;
            actual = target.GenericParameterTypes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Modifiers
        ///</summary>
        [TestMethod()]
        public void ModifiersTest()
        {
            Constructor target = new Constructor(); // TODO: Initialize to an appropriate value
            Modifier expected = new Modifier(); // TODO: Initialize to an appropriate value
            Modifier actual;
            target.Modifiers = expected;
            actual = target.Modifiers;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            Constructor target = new Constructor(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ParameterTypes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ParameterTypesTest()
        {
            Constructor_Accessor target = new Constructor_Accessor(); // TODO: Initialize to an appropriate value
            List<Class> expected = null; // TODO: Initialize to an appropriate value
            List<Class> actual;
            target.ParameterTypes = expected;
            actual = target.ParameterTypes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Synthetic
        ///</summary>
        [TestMethod()]
        public void SyntheticTest()
        {
            Constructor target = new Constructor(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Synthetic = expected;
            actual = target.Synthetic;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TypeParameters
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void TypeParametersTest()
        {
            Constructor_Accessor target = new Constructor_Accessor(); // TODO: Initialize to an appropriate value
            List<JavaTypeVariable<Constructor>> expected = null; // TODO: Initialize to an appropriate value
            List<JavaTypeVariable<Constructor>> actual;
            target.TypeParameters = expected;
            actual = target.TypeParameters;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
