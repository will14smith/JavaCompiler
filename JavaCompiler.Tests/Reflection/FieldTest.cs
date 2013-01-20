using JavaCompiler.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Reflection.Enums;

namespace JavaCompiler.Tests.Reflection
{
    
    
    /// <summary>
    ///This is a test class for FieldTest and is intended
    ///to contain all FieldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FieldTest
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
        ///A test for Field Constructor
        ///</summary>
        [TestMethod()]
        public void FieldConstructorTest()
        {
            Field target = new Field();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DeclaringClass
        ///</summary>
        [TestMethod()]
        public void DeclaringClassTest()
        {
            Field target = new Field(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.DeclaringClass = expected;
            actual = target.DeclaringClass;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Modifiers
        ///</summary>
        [TestMethod()]
        public void ModifiersTest()
        {
            Field target = new Field(); // TODO: Initialize to an appropriate value
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
            Field target = new Field(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Synthetic
        ///</summary>
        [TestMethod()]
        public void SyntheticTest()
        {
            Field target = new Field(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Synthetic = expected;
            actual = target.Synthetic;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            Field target = new Field(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.Type = expected;
            actual = target.Type;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
