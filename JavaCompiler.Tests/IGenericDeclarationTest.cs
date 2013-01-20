using JavaCompiler.Reflection.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Reflection;
using System.Collections.Generic;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for IGenericDeclarationTest and is intended
    ///to contain all IGenericDeclarationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IGenericDeclarationTest
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
        ///A test for TypeParameters
        ///</summary>
        public void TypeParametersTestHelper<T>()
            where T : IGenericDeclaration<T>
        {
            IGenericDeclaration<T> target = CreateIGenericDeclaration<T>(); // TODO: Initialize to an appropriate value
            List<JavaTypeVariable<T>> actual;
            actual = target.TypeParameters;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual IGenericDeclaration<T> CreateIGenericDeclaration<T>()
            where T : IGenericDeclaration<T>
        {
            // TODO: Instantiate an appropriate concrete class.
            IGenericDeclaration<T> target = null;
            return target;
        }

        [TestMethod()]
        public void TypeParametersTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call TypeParametersTestHelper<T>() with appropriate type parameters.");
        }
    }
}
