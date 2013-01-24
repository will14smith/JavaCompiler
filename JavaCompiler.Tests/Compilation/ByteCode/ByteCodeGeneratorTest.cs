using JavaCompiler.Compilation.ByteCode;
using JavaCompiler.Reflection.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection;

namespace JavaCompiler.Tests.Compilation.ByteCode
{
    
    
    /// <summary>
    ///This is a test class for ByteCodeGeneratorTest and is intended
    ///to contain all ByteCodeGeneratorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ByteCodeGeneratorTest
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
        ///A test for ByteCodeGenerator Constructor
        ///</summary>
        [TestMethod()]
        public void ByteCodeGeneratorConstructorTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager, null);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
        /// <summary>
        ///A test for DefineVariable
        ///</summary>
        [TestMethod()]
        public void DefineVariableTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager, null); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Class type = null; // TODO: Initialize to an appropriate value
            Variable expected = null; // TODO: Initialize to an appropriate value
            Variable actual;
            actual = target.DefineVariable(name, type);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager, null); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetVariable
        ///</summary>
        [TestMethod()]
        public void GetVariableTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager, null); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Variable expected = null; // TODO: Initialize to an appropriate value
            Variable actual;
            actual = target.GetVariable(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for UndefineVariable
        ///</summary>
        [TestMethod()]
        public void UndefineVariableTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager, null); // TODO: Initialize to an appropriate value
            Variable variable = null; // TODO: Initialize to an appropriate value
            target.UndefineVariable(variable);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UndefineVariable
        ///</summary>
        [TestMethod()]
        public void UndefineVariableTest1()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager, null); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.UndefineVariable(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UndefineVariable
        ///</summary>
        [TestMethod()]
        public void UndefineVariableTest2()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager, null); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            target.UndefineVariable(name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
