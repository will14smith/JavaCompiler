using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.Boxing
{
    [TestClass]
    public class BoxingTest : BaseTest
    {
        [TestMethod]
        [DeploymentItem("Tests\\Boxing\\Box.java", "Tests\\Boxing")]
        public void Box()
        {
            const string expected = "1";
            var actual = Test("Tests\\Boxing", "Box");

            Assert.AreEqual(expected, actual);
        }
    }
}
