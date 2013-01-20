using JavaCompiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace JavaCompiler.Tests
{
    
    
    /// <summary>
    ///This is a test class for JavaParserTest and is intended
    ///to contain all JavaParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JavaParserTest
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
        ///A test for JavaParser Constructor
        ///</summary>
        [TestMethod()]
        public void JavaParserConstructorTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            RecognizerSharedState state = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input, state);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for JavaParser Constructor
        ///</summary>
        [TestMethod()]
        public void JavaParserConstructorTest1()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for additiveExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void additiveExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.additiveExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for andExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void andExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.andExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotation
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotation();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationBody
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationBodyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationBody();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationDefaultValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationDefaultValueTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationDefaultValue();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationElementValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationElementValueTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationElementValue();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationElementValueArrayInitializer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationElementValueArrayInitializerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationElementValueArrayInitializer();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationElementValueExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationElementValueExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationElementValueExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationInit
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationInitTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationInit();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationInitializer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationInitializerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationInitializer();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationInitializers
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationInitializersTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationInitializers();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationScopeDeclarations
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationScopeDeclarationsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationScopeDeclarations();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for annotationTypeDeclaration
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void annotationTypeDeclarationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            CommonTree modifiers = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.annotationTypeDeclaration(modifiers);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for arguments
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void argumentsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.arguments();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for arrayDeclarator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void arrayDeclaratorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.arrayDeclarator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for arrayDeclaratorList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void arrayDeclaratorListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.arrayDeclaratorList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for arrayInitializer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void arrayInitializerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.arrayInitializer();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for assignmentExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void assignmentExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.assignmentExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for block
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void blockTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.block();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for blockStatement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void blockStatementTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.blockStatement();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for bound
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void boundTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.bound();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for catchClause
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void catchClauseTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.catchClause();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for catches
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void catchesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.catches();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for classBody
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void classBodyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.classBody();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for classExtendsClause
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void classExtendsClauseTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.classExtendsClause();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for classFieldDeclarator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void classFieldDeclaratorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.classFieldDeclarator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for classFieldDeclaratorList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void classFieldDeclaratorListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.classFieldDeclaratorList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for classScopeDeclarations
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void classScopeDeclarationsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.classScopeDeclarations();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for classTypeDeclaration
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void classTypeDeclarationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            CommonTree modifiers = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.classTypeDeclaration(modifiers);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for compilationUnit
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void compilationUnitTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.compilationUnit();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for conditionalExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void conditionalExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.conditionalExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for enumBody
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void enumBodyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.enumBody();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for enumClassScopeDeclarations
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void enumClassScopeDeclarationsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.enumClassScopeDeclarations();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for enumConstant
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void enumConstantTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.enumConstant();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for enumConstants
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void enumConstantsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.enumConstants();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for enumScopeDeclarations
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void enumScopeDeclarationsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.enumScopeDeclarations();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for enumTypeDeclaration
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void enumTypeDeclarationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            CommonTree modifiers = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.enumTypeDeclaration(modifiers);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for equalityExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void equalityExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.equalityExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for exclusiveOrExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void exclusiveOrExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.exclusiveOrExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for expression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void expressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.expression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for expressionList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void expressionListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.expressionList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for finallyClause
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void finallyClauseTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.finallyClause();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for forCondition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void forConditionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.forCondition();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for forInit
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void forInitTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.forInit();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for forUpdater
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void forUpdaterTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.forUpdater();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for formalParameterList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void formalParameterListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.formalParameterList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for formalParameterStandardDecl
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void formalParameterStandardDeclTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.formalParameterStandardDecl();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for formalParameterVarArgDecl
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void formalParameterVarArgDeclTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.formalParameterVarArgDecl();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for genericTypeArgument
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void genericTypeArgumentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.genericTypeArgument();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for genericTypeArgumentList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void genericTypeArgumentListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.genericTypeArgumentList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for genericTypeArgumentListSimplified
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void genericTypeArgumentListSimplifiedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.genericTypeArgumentListSimplified();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for genericTypeArgumentSimplified
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void genericTypeArgumentSimplifiedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.genericTypeArgumentSimplified();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for genericTypeListClosing
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void genericTypeListClosingTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.genericTypeListClosing();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for genericTypeParameter
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void genericTypeParameterTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.genericTypeParameter();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for genericTypeParameterList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void genericTypeParameterListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.genericTypeParameterList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for genericWildcardBoundType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void genericWildcardBoundTypeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.genericWildcardBoundType();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for implementsClause
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void implementsClauseTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.implementsClause();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for importDeclaration
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void importDeclarationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.importDeclaration();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for inclusiveOrExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void inclusiveOrExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.inclusiveOrExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for innerNewExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void innerNewExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.innerNewExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for instanceOfExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void instanceOfExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.instanceOfExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for interfaceBody
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void interfaceBodyTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.interfaceBody();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for interfaceExtendsClause
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void interfaceExtendsClauseTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.interfaceExtendsClause();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for interfaceFieldDeclarator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void interfaceFieldDeclaratorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.interfaceFieldDeclarator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for interfaceFieldDeclaratorList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void interfaceFieldDeclaratorListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.interfaceFieldDeclaratorList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for interfaceScopeDeclarations
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void interfaceScopeDeclarationsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.interfaceScopeDeclarations();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for interfaceTypeDeclaration
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void interfaceTypeDeclarationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            CommonTree modifiers = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.interfaceTypeDeclaration(modifiers);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for javaSource
        ///</summary>
        [TestMethod()]
        public void javaSourceTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.javaSource();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for literal
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void literalTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.literal();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for localModifier
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void localModifierTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.localModifier();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for localModifierList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void localModifierListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.localModifierList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for localVariableDeclaration
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void localVariableDeclarationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.localVariableDeclaration();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for logicalAndExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void logicalAndExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.logicalAndExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for logicalOrExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void logicalOrExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.logicalOrExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for modifier
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void modifierTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.modifier();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for modifierList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void modifierListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.modifierList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for multiplicativeExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void multiplicativeExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.multiplicativeExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for newArrayConstruction
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void newArrayConstructionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.newArrayConstruction();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for newExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void newExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.newExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for objectType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void objectTypeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.objectType();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for objectTypeSimplified
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void objectTypeSimplifiedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.objectTypeSimplified();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for packageDeclaration
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void packageDeclarationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.packageDeclaration();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for parenthesizedExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void parenthesizedExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.parenthesizedExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for postfixedExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void postfixedExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.postfixedExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for primaryExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void primaryExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.primaryExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for primitiveType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void primitiveTypeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.primitiveType();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for qualifiedIdentExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void qualifiedIdentExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.qualifiedIdentExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for qualifiedIdentList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void qualifiedIdentListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.qualifiedIdentList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for qualifiedIdentifier
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void qualifiedIdentifierTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.qualifiedIdentifier();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for qualifiedTypeIdent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void qualifiedTypeIdentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.qualifiedTypeIdent();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for qualifiedTypeIdentSimplified
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void qualifiedTypeIdentSimplifiedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.qualifiedTypeIdentSimplified();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for relationalExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void relationalExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.relationalExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for shiftExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void shiftExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.shiftExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for simpleType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void simpleTypeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.simpleType();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for statement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void statementTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.statement();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for switchBlockLabels
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void switchBlockLabelsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.switchBlockLabels();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for switchCaseLabel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void switchCaseLabelTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.switchCaseLabel();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for switchCaseLabels
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void switchCaseLabelsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.switchCaseLabels();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for switchDefaultLabel
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void switchDefaultLabelTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.switchDefaultLabel();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for synpred100_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred100_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred100_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred101_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred101_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred101_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred102_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred102_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred102_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred114_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred114_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred114_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred116_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred116_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred116_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred117_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred117_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred117_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred121_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred121_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred121_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred123_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred123_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred123_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred143_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred143_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred143_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred146_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred146_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred146_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred147_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred147_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred147_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred14_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred14_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred14_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred15_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred15_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred15_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred16_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred16_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred16_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred17_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred17_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred17_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred190_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred190_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred190_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred218_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred218_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred218_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred226_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred226_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred226_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred234_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred234_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred234_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred32_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred32_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred32_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred42_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred42_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred42_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred43_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred43_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred43_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred44_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred44_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred44_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred50_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred50_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred50_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred51_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred51_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred51_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred52_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred52_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred52_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred58_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred58_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred58_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred76_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred76_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred76_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred77_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred77_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred77_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred79_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred79_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred79_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred90_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred90_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred90_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred92_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred92_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred92_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred97_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred97_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred97_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for synpred99_Java_fragment
        ///</summary>
        [TestMethod()]
        public void synpred99_Java_fragmentTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            target.synpred99_Java_fragment();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for throwsClause
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void throwsClauseTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.throwsClause();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for type
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void typeTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.type();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for typeDeclaration
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void typeDeclarationTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.typeDeclaration();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for typeDecls
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void typeDeclsTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.typeDecls();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for typeIdent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void typeIdentTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.typeIdent();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for typeIdentSimplified
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void typeIdentSimplifiedTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.typeIdentSimplified();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for typeList
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void typeListTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.typeList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for unaryExpression
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void unaryExpressionTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.unaryExpression();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for unaryExpressionNotPlusMinus
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void unaryExpressionNotPlusMinusTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.unaryExpressionNotPlusMinus();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for variableDeclaratorId
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void variableDeclaratorIdTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.variableDeclaratorId();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for variableInitializer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("JavaCompiler.dll")]
        public void variableInitializerTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            JavaParser_Accessor target = new JavaParser_Accessor(param0); // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> expected = null; // TODO: Initialize to an appropriate value
            AstParserRuleReturnScope<CommonTree, IToken> actual;
            actual = target.variableInitializer();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GrammarFileName
        ///</summary>
        [TestMethod()]
        public void GrammarFileNameTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GrammarFileName;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TokenNames
        ///</summary>
        [TestMethod()]
        public void TokenNamesTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.TokenNames;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TreeAdaptor
        ///</summary>
        [TestMethod()]
        public void TreeAdaptorTest()
        {
            ITokenStream input = null; // TODO: Initialize to an appropriate value
            JavaParser target = new JavaParser(input); // TODO: Initialize to an appropriate value
            ITreeAdaptor expected = null; // TODO: Initialize to an appropriate value
            ITreeAdaptor actual;
            target.TreeAdaptor = expected;
            actual = target.TreeAdaptor;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
