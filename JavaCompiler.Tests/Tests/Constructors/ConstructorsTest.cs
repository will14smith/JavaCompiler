using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.Constructors
{
    [TestClass]
    public class ConstructorsTest : BaseTest
    {
        [TestMethod]
        [DeploymentItem("Tests\\Constructors\\NoConstructor.java", "Tests\\Constructors")]
        public void NoConstructor()
        {
            const string expected = "";
            var actual = Test("Tests\\Constructors", "NoConstructor");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\Constructors\\EmptyConstructor.java", "Tests\\Constructors")]
        public void EmptyConstructor()
        {
            const string expected = "";
            var actual = Test("Tests\\Constructors", "EmptyConstructor");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\Constructors\\Constructor.java", "Tests\\Constructors")]
        public void Constructor()
        {
            const string expected = "10";
            var actual = Test("Tests\\Constructors", "Constructor");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\Constructors\\ParamConstructor.java", "Tests\\Constructors")]
        public void ParamConstructor()
        {
            const string expected = "15";
            var actual = Test("Tests\\Constructors", "ParamConstructor");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DeploymentItem("Tests\\Constructors\\ParamConstructor2.java", "Tests\\Constructors")]
        public void ParamConstructor2()
        {
            const string expected = "11";
            var actual = Test("Tests\\Constructors", "ParamConstructor2");

            Assert.AreEqual(expected, actual);
        }
    }
}
