using JavaCompiler.Translators.Methods.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Translators.Methods.Expressions
{
    
    
    /// <summary>
    ///This is a test class for QualifiedTranslatorTest and is intended
    ///to contain all QualifiedTranslatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class QualifiedTranslatorTest
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
        ///A test for QualifiedTranslator Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void QualifiedTranslatorConstructorTest()
        {
            QualifiedTranslator target = new QualifiedTranslator();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
