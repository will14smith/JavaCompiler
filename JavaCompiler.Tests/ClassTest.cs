using JavaCompiler.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using JavaCompiler.Reflection.Interfaces;
using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Tests
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
        ///A test for Annotation
        ///</summary>
        [TestMethod()]
        public void AnnotationTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Annotation = expected;
            actual = target.Annotation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Array
        ///</summary>
        [TestMethod()]
        public void ArrayTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Array = expected;
            actual = target.Array;
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
        ///A test for Constructors
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ConstructorsTest()
        {
            Class_Accessor target = new Class_Accessor(); // TODO: Initialize to an appropriate value
            List<Constructor> expected = null; // TODO: Initialize to an appropriate value
            List<Constructor> actual;
            target.Constructors = expected;
            actual = target.Constructors;
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
        ///A test for Enum
        ///</summary>
        [TestMethod()]
        public void EnumTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Enum = expected;
            actual = target.Enum;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnumConstants
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void EnumConstantsTest()
        {
            Class_Accessor target = new Class_Accessor(); // TODO: Initialize to an appropriate value
            List<object> expected = null; // TODO: Initialize to an appropriate value
            List<object> actual;
            target.EnumConstants = expected;
            actual = target.EnumConstants;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Fields
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void FieldsTest()
        {
            Class_Accessor target = new Class_Accessor(); // TODO: Initialize to an appropriate value
            List<Field> expected = null; // TODO: Initialize to an appropriate value
            List<Field> actual;
            target.Fields = expected;
            actual = target.Fields;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenericInterfaces
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GenericInterfacesTest()
        {
            Class_Accessor target = new Class_Accessor(); // TODO: Initialize to an appropriate value
            List<IType> expected = null; // TODO: Initialize to an appropriate value
            List<IType> actual;
            target.GenericInterfaces = expected;
            actual = target.GenericInterfaces;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenericSuperclass
        ///</summary>
        [TestMethod()]
        public void GenericSuperclassTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            IType expected = null; // TODO: Initialize to an appropriate value
            IType actual;
            target.GenericSuperclass = expected;
            actual = target.GenericSuperclass;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Interface
        ///</summary>
        [TestMethod()]
        public void InterfaceTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Interface = expected;
            actual = target.Interface;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Interfaces
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void InterfacesTest()
        {
            Class_Accessor target = new Class_Accessor(); // TODO: Initialize to an appropriate value
            List<Class> expected = null; // TODO: Initialize to an appropriate value
            List<Class> actual;
            target.Interfaces = expected;
            actual = target.Interfaces;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Methods
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void MethodsTest()
        {
            Class_Accessor target = new Class_Accessor(); // TODO: Initialize to an appropriate value
            List<Method> expected = null; // TODO: Initialize to an appropriate value
            List<Method> actual;
            target.Methods = expected;
            actual = target.Methods;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Modifiers
        ///</summary>
        [TestMethod()]
        public void ModifiersTest()
        {
            Class target = new Class(); // TODO: Initialize to an appropriate value
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

        /// <summary>
        ///A test for TypeParameters
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void TypeParametersTest()
        {
            Class_Accessor target = new Class_Accessor(); // TODO: Initialize to an appropriate value
            List<JavaTypeVariable<Class>> expected = null; // TODO: Initialize to an appropriate value
            List<JavaTypeVariable<Class>> actual;
            target.TypeParameters = expected;
            actual = target.TypeParameters;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Types
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void TypesTest()
        {
            Class_Accessor target = new Class_Accessor(); // TODO: Initialize to an appropriate value
            List<IType> expected = null; // TODO: Initialize to an appropriate value
            List<IType> actual;
            target.Types = expected;
            actual = target.Types;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
