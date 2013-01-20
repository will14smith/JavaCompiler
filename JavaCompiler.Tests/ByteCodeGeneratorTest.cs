using JavaCompiler.Compilation.ByteCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Compilation;
using JavaCompiler.Reflection;

namespace JavaCompiler.Tests
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
            ByteCodeGenerator target = new ByteCodeGenerator(manager);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for DefineLabel
        ///</summary>
        [TestMethod()]
        public void DefineLabelTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            Label expected = new Label(); // TODO: Initialize to an appropriate value
            Label actual;
            actual = target.DefineLabel();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DefineVariable
        ///</summary>
        [TestMethod()]
        public void DefineVariableTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Class type = null; // TODO: Initialize to an appropriate value
            Variable expected = null; // TODO: Initialize to an appropriate value
            Variable actual;
            actual = target.DefineVariable(name, type);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Emit
        ///</summary>
        [TestMethod()]
        public void EmitTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            target.Emit(opcode);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Emit
        ///</summary>
        [TestMethod()]
        public void EmitTest1()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            byte b1 = 0; // TODO: Initialize to an appropriate value
            byte b2 = 0; // TODO: Initialize to an appropriate value
            target.Emit(opcode, b1, b2);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Emit
        ///</summary>
        [TestMethod()]
        public void EmitTest2()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            byte b = 0; // TODO: Initialize to an appropriate value
            target.Emit(opcode, b);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Emit
        ///</summary>
        [TestMethod()]
        public void EmitTest3()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            short s = 0; // TODO: Initialize to an appropriate value
            byte b1 = 0; // TODO: Initialize to an appropriate value
            byte b2 = 0; // TODO: Initialize to an appropriate value
            target.Emit(opcode, s, b1, b2);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Emit
        ///</summary>
        [TestMethod()]
        public void EmitTest4()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            Label l = new Label(); // TODO: Initialize to an appropriate value
            target.Emit(opcode, l);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Emit
        ///</summary>
        [TestMethod()]
        public void EmitTest5()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            short s = 0; // TODO: Initialize to an appropriate value
            target.Emit(opcode, s);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Emit
        ///</summary>
        [TestMethod()]
        public void EmitTest6()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            short s = 0; // TODO: Initialize to an appropriate value
            byte b = 0; // TODO: Initialize to an appropriate value
            target.Emit(opcode, s, b);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EmitWide
        ///</summary>
        [TestMethod()]
        public void EmitWideTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            short s1 = 0; // TODO: Initialize to an appropriate value
            short s2 = 0; // TODO: Initialize to an appropriate value
            target.EmitWide(opcode, s1, s2);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EmitWide
        ///</summary>
        [TestMethod()]
        public void EmitWideTest1()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            short s = 0; // TODO: Initialize to an appropriate value
            target.EmitWide(opcode, s);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnlargeArray
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void EnlargeArrayTest()
        {
            int[] incoming = null; // TODO: Initialize to an appropriate value
            int[] expected = null; // TODO: Initialize to an appropriate value
            int[] actual;
            actual = ByteCodeGenerator_Accessor.EnlargeArray(incoming);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnlargeArray
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void EnlargeArrayTest1()
        {
            byte[] incoming = null; // TODO: Initialize to an appropriate value
            int requiredSize = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = ByteCodeGenerator_Accessor.EnlargeArray(incoming, requiredSize);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnlargeArray
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void EnlargeArrayTest2()
        {
            byte[] incoming = null; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = ByteCodeGenerator_Accessor.EnlargeArray(incoming);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnsureCapacity
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void EnsureCapacityTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator_Accessor target = new ByteCodeGenerator_Accessor(param0); // TODO: Initialize to an appropriate value
            int size = 0; // TODO: Initialize to an appropriate value
            target.EnsureCapacity(size);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for FindFreeVariableIndex
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void FindFreeVariableIndexTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator_Accessor target = new ByteCodeGenerator_Accessor(param0); // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            actual = target.FindFreeVariableIndex();
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
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
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
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Variable expected = null; // TODO: Initialize to an appropriate value
            Variable actual;
            actual = target.GetVariable(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InternalEmit
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void InternalEmitTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator_Accessor target = new ByteCodeGenerator_Accessor(param0); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            target.InternalEmit(opcode);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MarkLabel
        ///</summary>
        [TestMethod()]
        public void MarkLabelTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            Label loc = new Label(); // TODO: Initialize to an appropriate value
            target.MarkLabel(loc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PopVariables
        ///</summary>
        [TestMethod()]
        public void PopVariablesTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            target.PopVariables();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for PushVariables
        ///</summary>
        [TestMethod()]
        public void PushVariablesTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            target.PushVariables();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UndefineVariable
        ///</summary>
        [TestMethod()]
        public void UndefineVariableTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
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
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
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
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            target.UndefineVariable(name);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateStackSize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void UpdateStackSizeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator_Accessor target = new ByteCodeGenerator_Accessor(param0); // TODO: Initialize to an appropriate value
            OpCode opcode = null; // TODO: Initialize to an appropriate value
            int stackchange = 0; // TODO: Initialize to an appropriate value
            target.UpdateStackSize(opcode, stackchange);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Manager
        ///</summary>
        [TestMethod()]
        public void ManagerTest()
        {
            CompileManager manager = null; // TODO: Initialize to an appropriate value
            ByteCodeGenerator target = new ByteCodeGenerator(manager); // TODO: Initialize to an appropriate value
            CompileManager expected = null; // TODO: Initialize to an appropriate value
            CompileManager actual;
            target.Manager = expected;
            actual = target.Manager;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
