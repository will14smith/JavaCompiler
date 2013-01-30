using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.Boxing
{
    [TestClass]
    public class UnboxingTest : BaseTest
    {
        [TestMethod]
        [DeploymentItem("Tests\\Boxing\\UnboxAdd.java", "Tests\\Boxing")]
        public void UnboxAdd()
        {
            const string expected = "1 + 2 = 3";
            var actual = Test("Tests\\Boxing", "UnboxAdd");

            Assert.AreEqual(expected, actual);
        }
    }
}
