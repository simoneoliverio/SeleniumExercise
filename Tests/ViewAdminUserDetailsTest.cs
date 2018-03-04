using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework;

namespace Tests
{
    [TestClass]
    public class ViewAdminUserDetailsTest : BaseTest
    {
        [TestMethod]
        public void Can_View_Admin_User()
        {
            LoginPage.LoginAs("admin@mail.com").WithPassword("abc123").Login();

            Assert.IsTrue(UsersPage.IsPresentAdmin);

            UsersPage.ViewAdmin();
            Assert.IsTrue(UserPage.IsAdmin);
        }
    }
}
