﻿using JavaCompiler.Translators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr.Runtime.Tree;
using JavaCompiler.Reflection.Enums;
using System.Collections.Generic;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for LocalModifierListTranslatorTest and is intended
    ///to contain all LocalModifierListTranslatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LocalModifierListTranslatorTest
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
        ///A test for LocalModifierListTranslator Constructor
        ///</summary>
        [TestMethod()]
        public void LocalModifierListTranslatorConstructorTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            LocalModifierListTranslator target = new LocalModifierListTranslator(node);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ConvertNode
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void ConvertNodeTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            LocalModifier expected = null; // TODO: Initialize to an appropriate value
            LocalModifier actual;
            actual = LocalModifierListTranslator_Accessor.ConvertNode(node);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Walk
        ///</summary>
        [TestMethod()]
        public void WalkTest()
        {
            ITree node = null; // TODO: Initialize to an appropriate value
            LocalModifierListTranslator target = new LocalModifierListTranslator(node); // TODO: Initialize to an appropriate value
            IEnumerable<LocalModifier> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<LocalModifier> actual;
            actual = target.Walk();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
