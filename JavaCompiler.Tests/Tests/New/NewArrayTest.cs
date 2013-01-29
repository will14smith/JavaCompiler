using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.New
{
    [TestClass]
    public class NewArrayTest : BaseTest
    {
        [TestMethod]
        [DeploymentItem("Tests\\New\\NewPrimativeArrayConst.java", "Tests\\New")]
        public void NewPrimativeArrayConst()
        {
            var expected = "[10, 0, 0, 0, 0, 0]";
            var actual = Test("Tests\\New", "NewPrimativeArrayConst");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\New\\NewPrimativeArrayExpression.java", "Tests\\New")]
        public void NewPrimativeArrayExpression()
        {
            var expected = "[10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]";
            var actual = Test("Tests\\New", "NewPrimativeArrayExpression");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\New\\NewPrimativeArrayMulti.java", "Tests\\New")]
        public void NewPrimativeArrayMulti()
        {
            var expected = "";
            var actual = Test("Tests\\New", "NewPrimativeArrayMulti");

            Assert.Inconclusive("Need output method");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("Tests\\New\\NewPrimativeArrayMultiJag.java", "Tests\\New")]
        public void NewPrimativeArrayMultiJag()
        {
            var expected = "";
            var actual = Test("Tests\\New", "NewPrimativeArrayMultiJag");

            Assert.Inconclusive("Need output method");

            Assert.AreEqual(expected, actual);
        }
    }
}
