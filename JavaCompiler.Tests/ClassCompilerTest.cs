using JavaCompiler.Compilers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Reflection;
using JavaCompiler.Compilation;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for ClassCompilerTest and is intended
    ///to contain all ClassCompilerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClassCompilerTest
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
        ///A test for ClassCompiler Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ClassCompilerConstructorTest()
        {
            Class @class = null; // TODO: Initialize to an appropriate value
            ClassCompiler_Accessor target = new ClassCompiler_Accessor(@class);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Compile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ClassCompiler_Accessor target = new ClassCompiler_Accessor(param0); // TODO: Initialize to an appropriate value
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            target.Compile(manager);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CompileFields
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileFieldsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ClassCompiler_Accessor target = new ClassCompiler_Accessor(param0); // TODO: Initialize to an appropriate value
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            target.CompileFields(manager);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CompileInterfaces
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileInterfacesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ClassCompiler_Accessor target = new ClassCompiler_Accessor(param0); // TODO: Initialize to an appropriate value
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            target.CompileInterfaces(manager);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CompileMethods
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CompileMethodsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ClassCompiler_Accessor target = new ClassCompiler_Accessor(param0); // TODO: Initialize to an appropriate value
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            target.CompileMethods(manager);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
