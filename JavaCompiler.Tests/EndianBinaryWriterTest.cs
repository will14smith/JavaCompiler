using JavaCompiler.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for EndianBinaryWriterTest and is intended
    ///to contain all EndianBinaryWriterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EndianBinaryWriterTest
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
        ///A test for EndianBinaryWriter Constructor
        ///</summary>
        [TestMethod()]
        public void EndianBinaryWriterConstructorTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            Encoding encoding = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream, encoding);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for EndianBinaryWriter Constructor
        ///</summary>
        [TestMethod()]
        public void EndianBinaryWriterConstructorTest1()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CheckDisposed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CheckDisposedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter_Accessor target = new EndianBinaryWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            target.CheckDisposed();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [TestMethod()]
        public void CloseTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            target.Close();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            target.Dispose();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Flush
        ///</summary>
        [TestMethod()]
        public void FlushTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            target.Flush();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Seek
        ///</summary>
        [TestMethod()]
        public void SeekTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            int offset = 0; // TODO: Initialize to an appropriate value
            SeekOrigin origin = new SeekOrigin(); // TODO: Initialize to an appropriate value
            target.Seek(offset, origin);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest1()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            byte value = 0; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest2()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            sbyte value = 0; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest3()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int offset = 0; // TODO: Initialize to an appropriate value
            int count = 0; // TODO: Initialize to an appropriate value
            target.Write(value, offset, count);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest4()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            string value = string.Empty; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest5()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            float value = 0F; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest6()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            char value = '\0'; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest7()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            char[] value = null; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest8()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            int value = 0; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest9()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            long value = 0; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest10()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            bool value = false; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest11()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            short value = 0; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest12()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            ushort value = 0; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest13()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            Decimal value = new Decimal(); // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest14()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            double value = 0F; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest15()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            uint value = 0; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest16()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            ulong value = 0; // TODO: Initialize to an appropriate value
            target.Write(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Write7BitEncodedInt
        ///</summary>
        [TestMethod()]
        public void Write7BitEncodedIntTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            int value = 0; // TODO: Initialize to an appropriate value
            target.Write7BitEncodedInt(value);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WriteInternal
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void WriteInternalTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter_Accessor target = new EndianBinaryWriter_Accessor(param0); // TODO: Initialize to an appropriate value
            byte[] bytes = null; // TODO: Initialize to an appropriate value
            int length = 0; // TODO: Initialize to an appropriate value
            target.WriteInternal(bytes, length);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BaseStream
        ///</summary>
        [TestMethod()]
        public void BaseStreamTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            Stream actual;
            actual = target.BaseStream;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BitConverter
        ///</summary>
        [TestMethod()]
        public void BitConverterTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            EndianBitConverter actual;
            actual = target.BitConverter;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Encoding
        ///</summary>
        [TestMethod()]
        public void EncodingTest()
        {
            EndianBitConverter bitConverter = null; // TODO: Initialize to an appropriate value
            Stream stream = null; // TODO: Initialize to an appropriate value
            EndianBinaryWriter target = new EndianBinaryWriter(bitConverter, stream); // TODO: Initialize to an appropriate value
            Encoding actual;
            actual = target.Encoding;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
