using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework;

namespace Tests
{
    [TestClass]
    public class LoginTests : BaseTest
    {
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            LoginPage.LoginAs("admin@mail.com").WithPassword("abc123").Login();

            Assert.IsTrue(UsersPage.IsAt, "Failed to login.");
        }
    }
}
