using JavaCompiler.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for EndianBitConverterTest and is intended
    ///to contain all EndianBitConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EndianBitConverterTest
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
        ///A test for CheckByteArgument
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CheckByteArgumentTest()
        {
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            int bytesRequired = 0; // TODO: Initialize to an appropriate value
            EndianBitConverter_Accessor.CheckByteArgument(value, startIndex, bytesRequired);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        internal virtual EndianBitConverter_Accessor CreateEndianBitConverter_Accessor()
        {
            // TODO: Instantiate an appropriate concrete class.
            EndianBitConverter_Accessor target = null;
            return target;
        }

        /// <summary>
        ///A test for CheckedFromBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CheckedFromBytesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            EndianBitConverter_Accessor target = new EndianBitConverter_Accessor(param0); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            int bytesToConvert = 0; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.CheckedFromBytes(value, startIndex, bytesToConvert);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        internal virtual EndianBitConverter CreateEndianBitConverter()
        {
            // TODO: Instantiate an appropriate concrete class.
            EndianBitConverter target = null;
            return target;
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            bool value = false; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest1()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            char value = '\0'; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CopyBytesTest2()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            EndianBitConverter_Accessor target = new EndianBitConverter_Accessor(param0); // TODO: Initialize to an appropriate value
            long value = 0; // TODO: Initialize to an appropriate value
            int bytes = 0; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, bytes, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest3()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            uint value = 0; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest4()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            ulong value = 0; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest5()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            long value = 0; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest6()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            float value = 0F; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest7()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            ushort value = 0; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest8()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            double value = 0F; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest9()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            short value = 0; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest10()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            int value = 0; // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytes
        ///</summary>
        [TestMethod()]
        public void CopyBytesTest11()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            Decimal value = new Decimal(); // TODO: Initialize to an appropriate value
            byte[] buffer = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.CopyBytes(value, buffer, index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CopyBytesImpl
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void CopyBytesImplTest()
        {
            // Private Accessor for CopyBytesImpl is not found. Please rebuild the containing project or run the Publicize.exe manually.
            Assert.Inconclusive("Private Accessor for CopyBytesImpl is not found. Please rebuild the containing pr" +
                    "oject or run the Publicize.exe manually.");
        }

        /// <summary>
        ///A test for DoubleToInt64Bits
        ///</summary>
        [TestMethod()]
        public void DoubleToInt64BitsTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            double value = 0F; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.DoubleToInt64Bits(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FromBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void FromBytesTest()
        {
            // Private Accessor for FromBytes is not found. Please rebuild the containing project or run the Publicize.exe manually.
            Assert.Inconclusive("Private Accessor for FromBytes is not found. Please rebuild the containing projec" +
                    "t or run the Publicize.exe manually.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GetBytesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            EndianBitConverter_Accessor target = new EndianBitConverter_Accessor(param0); // TODO: Initialize to an appropriate value
            long value = 0; // TODO: Initialize to an appropriate value
            int bytes = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value, bytes);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest1()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            char value = '\0'; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest2()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            bool value = false; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest3()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            double value = 0F; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest4()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            long value = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest5()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            float value = 0F; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest6()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            short value = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest7()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            ulong value = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest8()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            int value = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest9()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            uint value = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest10()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            ushort value = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBytes
        ///</summary>
        [TestMethod()]
        public void GetBytesTest11()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            Decimal value = new Decimal(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.GetBytes(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Int32BitsToSingle
        ///</summary>
        [TestMethod()]
        public void Int32BitsToSingleTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            int value = 0; // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.Int32BitsToSingle(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Int64BitsToDouble
        ///</summary>
        [TestMethod()]
        public void Int64BitsToDoubleTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            long value = 0; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.Int64BitsToDouble(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsLittleEndian
        ///</summary>
        [TestMethod()]
        public void IsLittleEndianTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLittleEndian();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SingleToInt32Bits
        ///</summary>
        [TestMethod()]
        public void SingleToInt32BitsTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            float value = 0F; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.SingleToInt32Bits(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToBoolean
        ///</summary>
        [TestMethod()]
        public void ToBooleanTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ToBoolean(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToChar
        ///</summary>
        [TestMethod()]
        public void ToCharTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            char expected = '\0'; // TODO: Initialize to an appropriate value
            char actual;
            actual = target.ToChar(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDecimal
        ///</summary>
        [TestMethod()]
        public void ToDecimalTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            Decimal expected = new Decimal(); // TODO: Initialize to an appropriate value
            Decimal actual;
            actual = target.ToDecimal(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDouble
        ///</summary>
        [TestMethod()]
        public void ToDoubleTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.ToDouble(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToInt16
        ///</summary>
        [TestMethod()]
        public void ToInt16Test()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            short expected = 0; // TODO: Initialize to an appropriate value
            short actual;
            actual = target.ToInt16(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToInt32
        ///</summary>
        [TestMethod()]
        public void ToInt32Test()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.ToInt32(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToInt64
        ///</summary>
        [TestMethod()]
        public void ToInt64Test()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.ToInt64(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToSingle
        ///</summary>
        [TestMethod()]
        public void ToSingleTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.ToSingle(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            byte[] value = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = EndianBitConverter.ToString(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest1()
        {
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = EndianBitConverter.ToString(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest2()
        {
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            int length = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = EndianBitConverter.ToString(value, startIndex, length);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToUInt16
        ///</summary>
        [TestMethod()]
        public void ToUInt16Test()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            ushort expected = 0; // TODO: Initialize to an appropriate value
            ushort actual;
            actual = target.ToUInt16(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToUInt32
        ///</summary>
        [TestMethod()]
        public void ToUInt32Test()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            uint expected = 0; // TODO: Initialize to an appropriate value
            uint actual;
            actual = target.ToUInt32(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToUInt64
        ///</summary>
        [TestMethod()]
        public void ToUInt64Test()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            byte[] value = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            ulong expected = 0; // TODO: Initialize to an appropriate value
            ulong actual;
            actual = target.ToUInt64(value, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Big
        ///</summary>
        [TestMethod()]
        public void BigTest()
        {
            BigEndianBitConverter actual;
            actual = EndianBitConverter.Big;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Endianness
        ///</summary>
        [TestMethod()]
        public void EndiannessTest()
        {
            EndianBitConverter target = CreateEndianBitConverter(); // TODO: Initialize to an appropriate value
            Endianness actual;
            actual = target.Endianness;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Little
        ///</summary>
        [TestMethod()]
        public void LittleTest()
        {
            LittleEndianBitConverter actual;
            actual = EndianBitConverter.Little;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
