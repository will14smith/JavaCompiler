using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaCompiler.Tests.Tests.New
{
    [TestClass]
    public class NewClassTest : BaseTest
    {
        [TestMethod]
        [DeploymentItem("Tests\\New\\NewClass.java", "Tests\\New")]
        public void NewClass()
        {
            var actual = Test("Tests\\New", "NewClass");

            Assert.IsNotNull(actual);

            int actualValue;
            int.TryParse(actual, out actualValue);

            Assert.IsNotNull(actualValue);
        }

        [TestMethod]
        [DeploymentItem("Tests\\New\\NewClassParams.java", "Tests\\New")]
        public void NewClassParams()
        {
            var actual = Test("Tests\\New", "NewClassParams");

            Assert.IsNotNull(actual);

            int actualValue;
            int.TryParse(actual, out actualValue);

            Assert.IsNotNull(actualValue);

            var actual2 = Run("Tests\\New", "NewClassParams");

            Assert.IsNotNull(actual2);

            int actualValue2;
            int.TryParse(actual, out actualValue2);

            Assert.AreEqual(actualValue, actualValue2);
        }
    }
}
