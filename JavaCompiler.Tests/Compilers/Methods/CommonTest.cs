using JavaCompiler.Compilers.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JavaCompiler.Reflection;
using JavaCompiler.Compilation.ByteCode;

namespace JavaCompiler.Tests.Compilers.Methods
{
    
    
    /// <summary>
    ///This is a test class for CommonTest and is intended
    ///to contain all CommonTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommonTest
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
        ///A test for Cast
        ///</summary>
        [TestMethod()]
        public void CastTest()
        {
            Class stackType = null; // TODO: Initialize to an appropriate value
            Class requiredType = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            bool force = false; // TODO: Initialize to an appropriate value
            Common.Cast(stackType, requiredType, generator, force);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadDouble
        ///</summary>
        [TestMethod()]
        public void LoadDoubleTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.LoadDouble(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadFloat
        ///</summary>
        [TestMethod()]
        public void LoadFloatTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.LoadFloat(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadInt
        ///</summary>
        [TestMethod()]
        public void LoadIntTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.LoadInt(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadLong
        ///</summary>
        [TestMethod()]
        public void LoadLongTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.LoadLong(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LoadPrimative
        ///</summary>
        [TestMethod()]
        public void LoadPrimativeTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.LoadPrimative(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StoreDouble
        ///</summary>
        [TestMethod()]
        public void StoreDoubleTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.StoreDouble(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StoreFloat
        ///</summary>
        [TestMethod()]
        public void StoreFloatTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.StoreFloat(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StoreInt
        ///</summary>
        [TestMethod()]
        public void StoreIntTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.StoreInt(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StoreLong
        ///</summary>
        [TestMethod()]
        public void StoreLongTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.StoreLong(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StorePrimative
        ///</summary>
        [TestMethod()]
        public void StorePrimativeTest()
        {
            Variable variable = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator generator = null; // TODO: Initialize to an appropriate value
            Common.StorePrimative(variable, generator);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
