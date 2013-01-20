using JavaCompiler.Translators.Methods.Tree.BlockStatements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Translators.Methods.Tree.Expressions;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Reflection;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for VarDeclarationNodeTest and is intended
    ///to contain all VarDeclarationNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VarDeclarationNodeTest
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
        ///A test for VarDeclarationNode Constructor
        ///</summary>
        [TestMethod()]
        public void VarDeclarationNodeConstructorTest()
        {
            VarDeclarationNode target = new VarDeclarationNode();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ValidateType
        ///</summary>
        [TestMethod()]
        public void ValidateTypeTest()
        {
            VarDeclarationNode target = new VarDeclarationNode(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Initialiser
        ///</summary>
        [TestMethod()]
        public void InitialiserTest()
        {
            VarDeclarationNode target = new VarDeclarationNode(); // TODO: Initialize to an appropriate value
            ExpressionNode expected = null; // TODO: Initialize to an appropriate value
            ExpressionNode actual;
            target.Initialiser = expected;
            actual = target.Initialiser;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Modifiers
        ///</summary>
        [TestMethod()]
        public void ModifiersTest()
        {
            VarDeclarationNode target = new VarDeclarationNode(); // TODO: Initialize to an appropriate value
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
            VarDeclarationNode target = new VarDeclarationNode(); // TODO: Initialize to an appropriate value
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
        public void TypeTest()
        {
            VarDeclarationNode target = new VarDeclarationNode(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.Type = expected;
            actual = target.Type;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
