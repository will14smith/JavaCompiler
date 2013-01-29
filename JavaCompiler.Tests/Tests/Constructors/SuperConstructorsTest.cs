using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.Constructors
{
    [TestClass]
    public class SuperConstructorsTest : BaseTest
    {
        [TestMethod]
        [DeploymentItem("Tests\\Constructors\\Constructor.java", "Tests\\Constructors")]
        [DeploymentItem("Tests\\Constructors\\SuperNoConstructor.java", "Tests\\Constructors")]
        public void NoConstructor()
        {
            Compile("Tests\\Constructors\\Constructor.java");

            const string expected = "10";
            var actual = Test("Tests\\Constructors", "SuperNoConstructor");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\Constructors\\Constructor.java", "Tests\\Constructors")]
        [DeploymentItem("Tests\\Constructors\\SuperEmptyConstructor.java", "Tests\\Constructors")]
        public void EmptyConstructor()
        {
            Compile("Tests\\Constructors\\Constructor.java");

            const string expected = "10";
            var actual = Test("Tests\\Constructors", "SuperEmptyConstructor");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\Constructors\\Constructor.java", "Tests\\Constructors")]
        [DeploymentItem("Tests\\Constructors\\SuperConstructor.java", "Tests\\Constructors")]
        public void Constructor()
        {
            Compile("Tests\\Constructors\\Constructor.java");

            const string expected = "5";
            var actual = Test("Tests\\Constructors", "SuperConstructor");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\Constructors\\ParamConstructor.java", "Tests\\Constructors")]
        [DeploymentItem("Tests\\Constructors\\SuperParamConstructor.java", "Tests\\Constructors")]
        public void ParamConstructor()
        {
            Compile("Tests\\Constructors\\ParamConstructor.java");

            const string expected = "20";
            var actual = Test("Tests\\Constructors", "SuperParamConstructor");

            Assert.AreEqual(expected, actual);
        }
    }
}
