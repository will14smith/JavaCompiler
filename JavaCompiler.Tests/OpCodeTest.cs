using JavaCompiler.Compilation.ByteCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for OpCodeTest and is intended
    ///to contain all OpCodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OpCodeTest
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
        ///A test for OpCode Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void OpCodeConstructorTest()
        {
            OpCodeValues bc = new OpCodeValues(); // TODO: Initialize to an appropriate value
            NormalizedOpCodeValues normalizedValue = new NormalizedOpCodeValues(); // TODO: Initialize to an appropriate value
            int arg = 0; // TODO: Initialize to an appropriate value
            OpCodeMode reg = new OpCodeMode(); // TODO: Initialize to an appropriate value
            OpCodeModeWide wide = new OpCodeModeWide(); // TODO: Initialize to an appropriate value
            bool cannotThrow = false; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(bc, normalizedValue, arg, reg, wide, cannotThrow);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for OpCode Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void OpCodeConstructorTest1()
        {
            OpCodeValues bc = new OpCodeValues(); // TODO: Initialize to an appropriate value
            NormalizedOpCodeValues normalizedValue = new NormalizedOpCodeValues(); // TODO: Initialize to an appropriate value
            OpCodeMode reg = new OpCodeMode(); // TODO: Initialize to an appropriate value
            OpCodeModeWide wide = new OpCodeModeWide(); // TODO: Initialize to an appropriate value
            bool cannotThrow = false; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(bc, normalizedValue, reg, wide, cannotThrow);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for OpCode Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void OpCodeConstructorTest2()
        {
            OpCodeValues bc = new OpCodeValues(); // TODO: Initialize to an appropriate value
            OpCodeMode reg = new OpCodeMode(); // TODO: Initialize to an appropriate value
            OpCodeModeWide wide = new OpCodeModeWide(); // TODO: Initialize to an appropriate value
            bool cannotThrow = false; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(bc, reg, wide, cannotThrow);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CanThrowException
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CanThrowExceptionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(param0); // TODO: Initialize to an appropriate value
            NormalizedOpCodeValues bc = new NormalizedOpCodeValues(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanThrowException(bc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FlowControl
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void FlowControlTest()
        {
            NormalizedOpCodeValues bc = new NormalizedOpCodeValues(); // TODO: Initialize to an appropriate value
            OpCodeFlowControl_Accessor expected = null; // TODO: Initialize to an appropriate value
            OpCodeFlowControl_Accessor actual;
            actual = OpCode_Accessor.FlowControl(bc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetArg
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GetArgTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(param0); // TODO: Initialize to an appropriate value
            OpCode bc = null; // TODO: Initialize to an appropriate value
            int defaultArg = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetArg(bc, defaultArg);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsBranch
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void IsBranchTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(param0); // TODO: Initialize to an appropriate value
            NormalizedOpCodeValues bc = new NormalizedOpCodeValues(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsBranch(bc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Flags
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void FlagsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(param0); // TODO: Initialize to an appropriate value
            OpCodeFlags expected = new OpCodeFlags(); // TODO: Initialize to an appropriate value
            OpCodeFlags actual;
            target.Flags = expected;
            actual = target.Flags;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Mode
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ModeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(param0); // TODO: Initialize to an appropriate value
            OpCodeMode expected = new OpCodeMode(); // TODO: Initialize to an appropriate value
            OpCodeMode actual;
            target.Mode = expected;
            actual = target.Mode;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NormalizedValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void NormalizedValueTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(param0); // TODO: Initialize to an appropriate value
            NormalizedOpCodeValues expected = new NormalizedOpCodeValues(); // TODO: Initialize to an appropriate value
            NormalizedOpCodeValues actual;
            target.NormalizedValue = expected;
            actual = target.NormalizedValue;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Value
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ValueTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(param0); // TODO: Initialize to an appropriate value
            OpCodeValues expected = new OpCodeValues(); // TODO: Initialize to an appropriate value
            OpCodeValues actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WideMode
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WideModeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            OpCode_Accessor target = new OpCode_Accessor(param0); // TODO: Initialize to an appropriate value
            OpCodeModeWide expected = new OpCodeModeWide(); // TODO: Initialize to an appropriate value
            OpCodeModeWide actual;
            target.WideMode = expected;
            actual = target.WideMode;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
