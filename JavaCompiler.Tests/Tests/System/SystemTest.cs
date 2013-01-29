using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.System
{
    [TestClass]
    public class SystemTest : BaseTest
    {
        [TestMethod]
        [DeploymentItem("Tests\\System\\PrintLine.java", "Tests\\System")]
        public void PrintLine()
        {
            const string expected = "Hello";
            var actual = Test("Tests\\System", "PrintLine");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\System\\PrintLineArgs.java", "Tests\\System")]
        public void PrintLineArgs()
        {
            const string expected = "Hello World";
            var actual = Test("Tests\\System", "PrintLineArgs", expected);

            Assert.AreEqual(expected, actual);
        }
    }
}
