using JavaCompiler.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Reflection.Interfaces;
using System.Collections.Generic;

namespace JavaCompiler.Tests.Reflection
{
    
    
    /// <summary>
    ///This is a test class for TypeVariableTest and is intended
    ///to contain all TypeVariableTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TypeVariableTest
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
        ///A test for TypeVariable`1 Constructor
        ///</summary>
        public void TypeVariableConstructorTestHelper<T>()
            where T : IGenericDeclaration<T>
        {
            TypeVariable<T> target = new TypeVariable<T>();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void TypeVariableConstructorTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call TypeVariableConstructorTestHelper<T>() with appropriate type par" +
                    "ameters.");
        }

        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void BoundsTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call BoundsTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for GenericDeclaration
        ///</summary>
        public void GenericDeclarationTestHelper<T>()
            where T : IGenericDeclaration<T>
        {
            TypeVariable<T> target = new TypeVariable<T>(); // TODO: Initialize to an appropriate value
            T expected = default(T); // TODO: Initialize to an appropriate value
            T actual;
            target.GenericDeclaration = expected;
            actual = target.GenericDeclaration;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GenericDeclarationTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GenericDeclarationTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        public void NameTestHelper<T>()
            where T : IGenericDeclaration<T>
        {
            TypeVariable<T> target = new TypeVariable<T>(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void NameTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call NameTestHelper<T>() with appropriate type parameters.");
        }
    }
}
