using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.Inheritance.Simple
{
    [TestClass]
    [DeploymentItem("Tests\\Inheritance\\Simple\\Lamp.java", "Tests\\Inheritance\\Simple")]
    [DeploymentItem("Tests\\Inheritance\\Simple\\AdjustableLamp.java", "Tests\\Inheritance\\Simple")]
    public class SimpleTest : BaseTest
    {
        [ClassInitialize]
        public void Lamp()
        {
            Compile("Tests\\Inheritance\\Simple\\Lamp.java");
            Compile("Tests\\Inheritance\\Simple\\AdjustableLamp.java");
        }
        
        [TestMethod]
        public void Simple1()
        {
            const string expected = "Hello";
            var actual = Test("Tests\\Inheritance\\Simple", "Simple1");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Simple2()
        {
            const string expected = "Hello";
            var actual = Test("Tests\\Inheritance\\Simple", "Simple2");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Simple3()
        {
            const string expected = "Hello";
            var actual = Test("Tests\\Inheritance\\Simple", "Simple3");

            Assert.AreEqual(expected, actual);
        }
    }
}
