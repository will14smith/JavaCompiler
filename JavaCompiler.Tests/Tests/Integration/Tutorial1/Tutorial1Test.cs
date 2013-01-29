using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.Integration.Tutorial1
{
    [TestClass]
    public class Tutorial1Test : BaseTest
    {
        [TestMethod]
        [DeploymentItem("Tests\\Integration\\Tutorial1\\Exercise1.java", "Tests\\Integration\\Tutorial1")]
        public void Exercise1()
        {
            const string expected = "13 40 20 10 5 16 8 4 2 1";
            var actual = Test("Tests\\Integration\\Tutorial1", "Exercise1", "13");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\Integration\\Tutorial1\\Exercise2.java", "Tests\\Integration\\Tutorial1")]
        public void Exercise2()
        {
            var expected = 
                "0 cubed is 0" + Environment.NewLine +
                "1 cubed is 1" + Environment.NewLine +
                "2 cubed is 8" + Environment.NewLine +
                "7 cubed is 343" + Environment.NewLine +
                "11 cubed is 1331" + Environment.NewLine +
                "101 cubed is 1030301" + Environment.NewLine +
                "111 cubed is 1367631" + Environment.NewLine +
                "1001 cubed is 1003003001";

            var actual = Test("Tests\\Integration\\Tutorial1", "Exercise2");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\Integration\\Tutorial1\\Exercise3.java", "Tests\\Integration\\Tutorial1")]
        public void Exercise3()
        {
            const string expected = "";
            var actual = Test("Tests\\Integration\\Tutorial1", "Exercise3");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\Integration\\Tutorial1\\Exercise4.java", "Tests\\Integration\\Tutorial1")]
        public void Exercise4()
        {
            const string expected = "";
            var actual = Test("Tests\\Integration\\Tutorial1", "Exercise4");

            Assert.AreEqual(expected, actual);
        }
    }
}
