using JavaCompiler.Translators.Methods.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JavaCompiler.Reflection;
using System.Collections.Generic;
using System.Collections;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for MethodTreeNodeTest and is intended
    ///to contain all MethodTreeNodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MethodTreeNodeTest
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
        ///A test for Add
        ///</summary>
        public void AddTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            T item = default(T); // TODO: Initialize to an appropriate value
            target.Add(item);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        internal virtual MethodTreeNode<T> CreateMethodTreeNode<T>()
            where T : MethodTreeNode
        {
            // TODO: Instantiate an appropriate concrete class.
            MethodTreeNode<T> target = null;
            return target;
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call AddTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        public void ClearTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call ClearTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        public void ContainsTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            T item = default(T); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call ContainsTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for CopyTo
        ///</summary>
        public void CopyToTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            T[] array = null; // TODO: Initialize to an appropriate value
            int arrayIndex = 0; // TODO: Initialize to an appropriate value
            target.CopyTo(array, arrayIndex);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void CopyToTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call CopyToTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        public void GetEnumeratorTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            IEnumerator<T> expected = null; // TODO: Initialize to an appropriate value
            IEnumerator<T> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GetEnumeratorTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for IndexOf
        ///</summary>
        public void IndexOfTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            T item = default(T); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.IndexOf(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call IndexOfTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        public void InsertTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            T item = default(T); // TODO: Initialize to an appropriate value
            target.Insert(index, item);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void InsertTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call InsertTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        public void RemoveTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            T item = default(T); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Remove(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call RemoveTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for RemoveAt
        ///</summary>
        public void RemoveAtTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.RemoveAt(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call RemoveAtTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for System.Collections.IEnumerable.GetEnumerator
        ///</summary>
        public void GetEnumeratorTest1Helper<T>()
            where T : MethodTreeNode
        {
            IEnumerable target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void GetEnumeratorTest1()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GetEnumeratorTest1Helper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for ValidateType
        ///</summary>
        public void ValidateTypeTest1Helper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void ValidateTypeTest1()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call ValidateTypeTest1Helper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        public void CountTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Count;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CountTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call CountTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for IsReadOnly
        ///</summary>
        public void IsReadOnlyTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsReadOnly;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void IsReadOnlyTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call IsReadOnlyTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        public void ItemTestHelper<T>()
            where T : MethodTreeNode
        {
            MethodTreeNode<T> target = CreateMethodTreeNode<T>(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            T expected = default(T); // TODO: Initialize to an appropriate value
            T actual;
            target[index] = expected;
            actual = target[index];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ItemTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call ItemTestHelper<T>() with appropriate type parameters.");
        }

        internal virtual MethodTreeNode CreateMethodTreeNode()
        {
            // TODO: Instantiate an appropriate concrete class.
            MethodTreeNode target = null;
            return target;
        }

        /// <summary>
        ///A test for ValidateType
        ///</summary>
        [TestMethod()]
        public void ValidateTypeTest()
        {
            MethodTreeNode target = CreateMethodTreeNode(); // TODO: Initialize to an appropriate value
            target.ValidateType();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ReturnType
        ///</summary>
        [TestMethod()]
        public void ReturnTypeTest()
        {
            MethodTreeNode target = CreateMethodTreeNode(); // TODO: Initialize to an appropriate value
            Class expected = null; // TODO: Initialize to an appropriate value
            Class actual;
            target.ReturnType = expected;
            actual = target.ReturnType;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
