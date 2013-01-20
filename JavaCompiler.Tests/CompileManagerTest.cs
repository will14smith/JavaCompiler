using JavaCompiler.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Reflection;
using System.Collections.Generic;
using JavaCompiler.Reflection.Enums;
using JavaCompiler.Utilities;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for CompileManagerTest and is intended
    ///to contain all CompileManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompileManagerTest
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
        ///A test for CompileManager Constructor
        ///</summary>
        [TestMethod()]
        public void CompileManagerConstructorTest()
        {
            CompileManager target = new CompileManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddAttribute
        ///</summary>
        [TestMethod()]
        public void AddAttributeTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            CompileAttribute attribute = null; // TODO: Initialize to an appropriate value
            target.AddAttribute(attribute);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddConstantClass
        ///</summary>
        [TestMethod()]
        public void AddConstantClassTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            Class c = null; // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            actual = target.AddConstantClass(c);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddConstantInteger
        ///</summary>
        [TestMethod()]
        public void AddConstantIntegerTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            int value = 0; // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            actual = target.AddConstantInteger(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddConstantUtf8
        ///</summary>
        [TestMethod()]
        public void AddConstantUtf8Test()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            string s = string.Empty; // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            actual = target.AddConstantUtf8(s);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddConstantUtf8Type
        ///</summary>
        [TestMethod()]
        public void AddConstantUtf8TypeTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            Class type = null; // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            actual = target.AddConstantUtf8Type(type);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddField
        ///</summary>
        [TestMethod()]
        public void AddFieldTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            CompileFieldInfo field = null; // TODO: Initialize to an appropriate value
            target.AddField(field);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddMethod
        ///</summary>
        [TestMethod()]
        public void AddMethodTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            CompileMethodInfo method = null; // TODO: Initialize to an appropriate value
            target.AddMethod(method);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProcessMethodDescriptor
        ///</summary>
        [TestMethod()]
        public void ProcessMethodDescriptorTest()
        {
            Method method = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = CompileManager.ProcessMethodDescriptor(method);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ProcessTypeName
        ///</summary>
        [TestMethod()]
        public void ProcessTypeNameTest()
        {
            Class type = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = CompileManager.ProcessTypeName(type);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SetInterfaces
        ///</summary>
        [TestMethod()]
        public void SetInterfacesTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            List<short> interfaces = null; // TODO: Initialize to an appropriate value
            target.SetInterfaces(interfaces);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetModifiers
        ///</summary>
        [TestMethod()]
        public void SetModifiersTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            Modifier modifiers = new Modifier(); // TODO: Initialize to an appropriate value
            target.SetModifiers(modifiers);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetSuperClass
        ///</summary>
        [TestMethod()]
        public void SetSuperClassTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            short superClass = 0; // TODO: Initialize to an appropriate value
            target.SetSuperClass(superClass);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetThisClass
        ///</summary>
        [TestMethod()]
        public void SetThisClassTest()
        {
            CompileManager target = new CompileManager(); // TODO: Initialize to an appropriate value
            short thisClass = 0; // TODO: Initialize to an appropriate value
            target.SetThisClass(thisClass);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WriteAttributeBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WriteAttributeBytesTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.WriteAttributeBytes(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WriteConstBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WriteConstBytesTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.WriteConstBytes(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WriteFieldBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WriteFieldBytesTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.WriteFieldBytes(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WriteInterfaceBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WriteInterfaceBytesTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.WriteInterfaceBytes(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WriteMethodBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WriteMethodBytesTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.WriteMethodBytes(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WriteModiferBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WriteModiferBytesTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            EndianBinaryWriter writer = null; // TODO: Initialize to an appropriate value
            target.WriteModiferBytes(writer);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Attributes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void AttributesTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            List<CompileAttribute> expected = null; // TODO: Initialize to an appropriate value
            List<CompileAttribute> actual;
            target.Attributes = expected;
            actual = target.Attributes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConstantPool
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ConstantPoolTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            List<CompileConstant> expected = null; // TODO: Initialize to an appropriate value
            List<CompileConstant> actual;
            target.ConstantPool = expected;
            actual = target.ConstantPool;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Fields
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void FieldsTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            List<CompileFieldInfo> expected = null; // TODO: Initialize to an appropriate value
            List<CompileFieldInfo> actual;
            target.Fields = expected;
            actual = target.Fields;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Interfaces
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void InterfacesTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            List<short> expected = null; // TODO: Initialize to an appropriate value
            List<short> actual;
            target.Interfaces = expected;
            actual = target.Interfaces;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Methods
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void MethodsTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            List<CompileMethodInfo> expected = null; // TODO: Initialize to an appropriate value
            List<CompileMethodInfo> actual;
            target.Methods = expected;
            actual = target.Methods;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Modifiers
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ModifiersTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            Modifier expected = new Modifier(); // TODO: Initialize to an appropriate value
            Modifier actual;
            target.Modifiers = expected;
            actual = target.Modifiers;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SuperClass
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void SuperClassTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            target.SuperClass = expected;
            actual = target.SuperClass;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ThisClass
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ThisClassTest()
        {
            CompileManager_Accessor target = new CompileManager_Accessor(); // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            target.ThisClass = expected;
            actual = target.ThisClass;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
