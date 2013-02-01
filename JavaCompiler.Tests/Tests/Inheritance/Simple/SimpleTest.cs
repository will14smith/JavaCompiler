using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.Inheritance.Simple
{
    [TestClass]
    [DeploymentItem("Tests\\Inheritance\\Simple\\Lamp.java", "Tests\\Inheritance\\Simple")]
    [DeploymentItem("Tests\\Inheritance\\Simple\\AdjustableLamp.java", "Tests\\Inheritance\\Simple")]
    public class SimpleTest : BaseTest
    {
        [ClassInitialize]
        public static void Lamp(TestContext testContext)
        {
            Compile("Tests\\Inheritance\\Simple\\Lamp.java");
            Compile("Tests\\Inheritance\\Simple\\AdjustableLamp.java");
        }

        [TestMethod]
        [DeploymentItem("Tests\\Inheritance\\Simple\\Simple1.java", "Tests\\Inheritance\\Simple")]
        public void Simple1()
        {
            var expected = "AdjustableLamp(on, 1.0)" + Environment.NewLine +
                "AdjustableLamp(off, 0.9)";

            var actual = Test("Tests\\Inheritance\\Simple", "Simple1");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DeploymentItem("Tests\\Inheritance\\Simple\\Simple2.java", "Tests\\Inheritance\\Simple")]
        public void Simple2()
        {
            var expected = "Lamp(on)" + Environment.NewLine +
                "Lamp(off)" + Environment.NewLine +
                "AdjustableLamp(off, 1.0)" + Environment.NewLine +
                "AdjustableLamp(on, 0.9)" + Environment.NewLine +
                "AdjustableLamp(off, 1.0)" + Environment.NewLine +
                "AdjustableLamp(on, 1.0)";

            var actual = Test("Tests\\Inheritance\\Simple", "Simple2");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DeploymentItem("Tests\\Inheritance\\Simple\\Simple3.java", "Tests\\Inheritance\\Simple")]
        public void Simple3()
        {
            const string expected = "Hello";
            var actual = Test("Tests\\Inheritance\\Simple", "Simple3");

            Assert.AreEqual(expected, actual);
        }
    }
}
