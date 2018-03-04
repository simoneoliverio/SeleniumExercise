using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework;

namespace Tests
{
    [TestClass]
    public class UsersTests : BaseTest
    {
        [TestMethod]
        public void Can_Add_New_User()
        {
            LoginPage.LoginAs("admin@mail.com").WithPassword("abc123456").Login();

            UserPage.AddNewUser()
                .WithFirstName("Maria")
                .WithLastName("Rossi")
                .WithEmail("maria.rossi@email.it")
                .WithOffice("London")
                .WithGender(UserGender.Female)
                .WithBirthDay(new DateTime(2000, 2, 3))
                .WithNotes("Notes Maria Rossi")
                .Create();
        }
    }
}
