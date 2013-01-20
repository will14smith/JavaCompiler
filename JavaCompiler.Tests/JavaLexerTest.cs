using JavaCompiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr.Runtime;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for JavaLexerTest and is intended
    ///to contain all JavaLexerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JavaLexerTest
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
        ///A test for JavaLexer Constructor
        ///</summary>
        [TestMethod()]
        public void JavaLexerConstructorTest()
        {
            ICharStream input = null; // TODO: Initialize to an appropriate value
            RecognizerSharedState state = null; // TODO: Initialize to an appropriate value
            JavaLexer target = new JavaLexer(input, state);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for JavaLexer Constructor
        ///</summary>
        [TestMethod()]
        public void JavaLexerConstructorTest1()
        {
            ICharStream input = null; // TODO: Initialize to an appropriate value
            JavaLexer target = new JavaLexer(input);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for JavaLexer Constructor
        ///</summary>
        [TestMethod()]
        public void JavaLexerConstructorTest2()
        {
            JavaLexer target = new JavaLexer();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for InitDFAs
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void InitDFAsTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.InitDFAs();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mABSTRACT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mABSTRACTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mABSTRACT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mAND
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mANDTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mAND();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mAND_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mAND_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mAND_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mASSERT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mASSERTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mASSERT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mAT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mATTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mAT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mBIT_SHIFT_RIGHT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mBIT_SHIFT_RIGHTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mBIT_SHIFT_RIGHT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mBIT_SHIFT_RIGHT_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mBIT_SHIFT_RIGHT_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mBIT_SHIFT_RIGHT_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mBOOLEAN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mBOOLEANTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mBOOLEAN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mBREAK
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mBREAKTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mBREAK();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mBYTE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mBYTETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mBYTE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mCASE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mCASETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mCASE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mCATCH
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mCATCHTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mCATCH();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mCHAR
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mCHARTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mCHAR();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mCHARACTER_LITERAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mCHARACTER_LITERALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mCHARACTER_LITERAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mCLASS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mCLASSTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mCLASS();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mCOLON
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mCOLONTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mCOLON();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mCOMMA
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mCOMMATest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mCOMMA();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mCOMMENT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mCOMMENTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mCOMMENT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mCONTINUE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mCONTINUETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mCONTINUE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mDEC
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mDECTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mDEC();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mDECIMAL_LITERAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mDECIMAL_LITERALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mDECIMAL_LITERAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mDEFAULT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mDEFAULTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mDEFAULT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mDIV
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mDIVTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mDIV();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mDIV_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mDIV_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mDIV_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mDO
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mDOTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mDO();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mDOT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mDOTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mDOT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mDOTSTAR
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mDOTSTARTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mDOTSTAR();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mDOUBLE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mDOUBLETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mDOUBLE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mELLIPSIS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mELLIPSISTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mELLIPSIS();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mELSE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mELSETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mELSE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mENUM
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mENUMTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mENUM();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mEQUAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mEQUALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mEQUAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mESCAPE_SEQUENCE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mESCAPE_SEQUENCETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mESCAPE_SEQUENCE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mEXPONENT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mEXPONENTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mEXPONENT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mEXTENDS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mEXTENDSTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mEXTENDS();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mFALSE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mFALSETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mFALSE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mFINAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mFINALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mFINAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mFINALLY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mFINALLYTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mFINALLY();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mFLOAT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mFLOATTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mFLOAT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mFLOATING_POINT_LITERAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mFLOATING_POINT_LITERALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mFLOATING_POINT_LITERAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mFLOAT_TYPE_SUFFIX
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mFLOAT_TYPE_SUFFIXTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mFLOAT_TYPE_SUFFIX();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mFOR
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mFORTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mFOR();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mGREATER_OR_EQUAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mGREATER_OR_EQUALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mGREATER_OR_EQUAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mGREATER_THAN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mGREATER_THANTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mGREATER_THAN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mHEX_DIGIT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mHEX_DIGITTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mHEX_DIGIT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mHEX_LITERAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mHEX_LITERALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mHEX_LITERAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mIDENT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mIDENTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mIDENT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mIF
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mIFTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mIF();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mIMPLEMENTS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mIMPLEMENTSTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mIMPLEMENTS();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mIMPORT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mIMPORTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mIMPORT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mINC
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mINCTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mINC();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mINSTANCEOF
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mINSTANCEOFTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mINSTANCEOF();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mINT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mINTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mINT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mINTEGER_TYPE_SUFFIX
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mINTEGER_TYPE_SUFFIXTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mINTEGER_TYPE_SUFFIX();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mINTERFACE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mINTERFACETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mINTERFACE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mJAVA_ID_PART
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mJAVA_ID_PARTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mJAVA_ID_PART();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mJAVA_ID_START
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mJAVA_ID_STARTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mJAVA_ID_START();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLBRACK
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLBRACKTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLBRACK();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLCURLY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLCURLYTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLCURLY();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLESS_OR_EQUAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLESS_OR_EQUALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLESS_OR_EQUAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLESS_THAN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLESS_THANTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLESS_THAN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLINE_COMMENT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLINE_COMMENTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLINE_COMMENT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLOGICAL_AND
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLOGICAL_ANDTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLOGICAL_AND();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLOGICAL_NOT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLOGICAL_NOTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLOGICAL_NOT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLOGICAL_OR
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLOGICAL_ORTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLOGICAL_OR();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLONG
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLONGTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLONG();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mLPAREN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mLPARENTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mLPAREN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mMINUS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mMINUSTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mMINUS();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mMINUS_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mMINUS_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mMINUS_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mMOD
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mMODTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mMOD();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mMOD_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mMOD_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mMOD_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mNATIVE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mNATIVETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mNATIVE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mNEW
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mNEWTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mNEW();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mNOT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mNOTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mNOT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mNOT_EQUAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mNOT_EQUALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mNOT_EQUAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mNULL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mNULLTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mNULL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mOCTAL_ESCAPE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mOCTAL_ESCAPETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mOCTAL_ESCAPE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mOCTAL_LITERAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mOCTAL_LITERALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mOCTAL_LITERAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mOR
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mORTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mOR();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mOR_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mOR_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mOR_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mPACKAGE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mPACKAGETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mPACKAGE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mPLUS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mPLUSTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mPLUS();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mPLUS_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mPLUS_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mPLUS_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mPRIVATE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mPRIVATETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mPRIVATE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mPROTECTED
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mPROTECTEDTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mPROTECTED();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mPUBLIC
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mPUBLICTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mPUBLIC();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mQUESTION
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mQUESTIONTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mQUESTION();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mRBRACK
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mRBRACKTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mRBRACK();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mRCURLY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mRCURLYTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mRCURLY();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mRETURN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mRETURNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mRETURN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mRPAREN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mRPARENTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mRPAREN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSEMI
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSEMITest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSEMI();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSHIFT_LEFT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSHIFT_LEFTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSHIFT_LEFT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSHIFT_LEFT_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSHIFT_LEFT_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSHIFT_LEFT_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSHIFT_RIGHT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSHIFT_RIGHTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSHIFT_RIGHT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSHIFT_RIGHT_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSHIFT_RIGHT_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSHIFT_RIGHT_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSHORT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSHORTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSHORT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSTAR
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSTARTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSTAR();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSTAR_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSTAR_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSTAR_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSTATIC
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSTATICTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSTATIC();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSTRICTFP
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSTRICTFPTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSTRICTFP();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSTRING_LITERAL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSTRING_LITERALTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSTRING_LITERAL();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSUPER
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSUPERTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSUPER();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSWITCH
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSWITCHTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSWITCH();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mSYNCHRONIZED
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mSYNCHRONIZEDTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mSYNCHRONIZED();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mTHIS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mTHISTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mTHIS();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mTHROW
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mTHROWTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mTHROW();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mTHROWS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mTHROWSTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mTHROWS();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mTRANSIENT
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mTRANSIENTTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mTRANSIENT();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mTRUE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mTRUETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mTRUE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mTRY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mTRYTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mTRY();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mTokens
        ///</summary>
        [TestMethod()]
        public void mTokensTest()
        {
            JavaLexer target = new JavaLexer(); // TODO: Initialize to an appropriate value
            target.mTokens();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mUNICODE_ESCAPE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mUNICODE_ESCAPETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mUNICODE_ESCAPE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mVOID
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mVOIDTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mVOID();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mVOLATILE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mVOLATILETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mVOLATILE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mWHILE
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mWHILETest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mWHILE();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mWS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mWSTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mWS();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mXOR
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mXORTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mXOR();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for mXOR_ASSIGN
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void mXOR_ASSIGNTest()
        {
            JavaLexer_Accessor target = new JavaLexer_Accessor(); // TODO: Initialize to an appropriate value
            target.mXOR_ASSIGN();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GrammarFileName
        ///</summary>
        [TestMethod()]
        public void GrammarFileNameTest()
        {
            JavaLexer target = new JavaLexer(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GrammarFileName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PreserveWhitespacesAndComments
        ///</summary>
        [TestMethod()]
        public void PreserveWhitespacesAndCommentsTest()
        {
            JavaLexer target = new JavaLexer(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.PreserveWhitespacesAndComments = expected;
            actual = target.PreserveWhitespacesAndComments;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
