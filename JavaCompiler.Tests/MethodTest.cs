using JavaCompiler.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Translators.Methods.Tree;
using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for MethodTest and is intended
    ///to contain all MethodTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MethodTest
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
        ///A test for Method Constructor
        ///</summary>
        [TestMethod()]
        public void MethodConstructorTest()
        {
            Method target = new Method();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Body
        ///</summary>
        [TestMethod()]
        public void BodyTest()
        {
            Method target = new Method(); // TODO: Initialize to an appropriate value
            MethodTree expected = null; // TODO: Initialize to an appropriate value
            MethodTree actual;
            target.Body = expected;
            actual = target.Body;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeclaringClass
        ///</summary>
        [TestMethod()]
        public void DeclaringClassTest()
        {
            Method target = new Method(); // TODO: Initialize to an appropriate value
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
            Method_Accessor target = new Method_Accessor(); // TODO: Initialize to an appropriate value
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
            Method_Accessor target = new Method_Accessor(); // TODO: Initialize to an appropriate value
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
            Method_Accessor target = new Method_Accessor(); // TODO: Initialize to an appropriate value
            List<IType> expected = null; // TODO: Initialize to an appropriate value
            List<IType> actual;
            target.GenericParameterTypes = expected;
            actual = target.GenericParameterTypes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenericReturnType
        ///</summary>
        [TestMethod()]
        public void GenericReturnTypeTest()
        {
            Method target = new Method(); // TODO: Initialize to an appropriate value
            IType expected = null; // TODO: Initialize to an appropriate value
            IType actual;
            target.GenericReturnType = expected;
            actual = target.GenericReturnType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Modifiers
        ///</summary>
        [TestMethod()]
        public void ModifiersTest()
        {
            Method target = new Method(); // TODO: Initialize to an appropriate value
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
            Method target = new Method(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Parameters
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ParametersTest()
        {
            Method_Accessor target = new Method_Accessor(); // TODO: Initialize to an appropriate value
            List<Method.Parameter> expected = null; // TODO: Initialize to an appropriate value
            List<Method.Parameter> actual;
            target.Parameters = expected;
            actual = target.Parameters;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReturnType
        ///</summary>
        [TestMethod()]
        public void ReturnTypeTest()
        {
            Method target = new Method(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.ReturnType = expected;
            actual = target.ReturnType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Synthetic
        ///</summary>
        [TestMethod()]
        public void SyntheticTest()
        {
            Method target = new Method(); // TODO: Initialize to an appropriate value
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
            Method_Accessor target = new Method_Accessor(); // TODO: Initialize to an appropriate value
            List<JavaTypeVariable<Method>> expected = null; // TODO: Initialize to an appropriate value
            List<JavaTypeVariable<Method>> actual;
            target.TypeParameters = expected;
            actual = target.TypeParameters;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VarArgs
        ///</summary>
        [TestMethod()]
        public void VarArgsTest()
        {
            Method target = new Method(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.VarArgs = expected;
            actual = target.VarArgs;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
