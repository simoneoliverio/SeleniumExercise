using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();

            LoginPage.GoTo();
        }

        [TestCleanup]
        public void Clean()
        {
            Driver.Close();
        }
    }
}
