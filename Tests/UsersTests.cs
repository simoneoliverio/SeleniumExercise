using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework;

namespace Tests
{
    [TestClass]
    public class UsersTests : BaseTest
    {
        [TestMethod]
        public void Can_Add_Edit_Delete_User()
        {
            LoginPage.LoginAs("admin@mail.com").WithPassword("abc123").Login();
            AddNewUser();
            EditUser();
            DeleteUser();
        }

        private void AddNewUser()
        {
            UserPage.AddNewUser()
                .WithFirstName("Maria")
                .WithLastName("Rossi")
                .WithEmail("maria.rossi@email.it")
                .WithOffice("London")
                .WithGender(UserGender.Female)
                .WithBirthDay(new DateTime(2000, 2, 3))
                .WithNotes("Notes Maria Rossi")
                .Create();

            Assert.IsTrue(UsersPage.IsUserPresent("maria.rossi@email.it"));
        }

        private void EditUser()
        {
            UserPage.EditUser()
                .WithEmail("maria.rossi@email.it")
                .WithFirstName("Maria1")
                .WithLastName("Rossi1")
                .WithOffice("Tokio")
                .WithGender(UserGender.Female)
                .WithBirthDay(new DateTime(2000, 2, 4))
                .WithNotes("Update Maria Rossi")
                .Edit(8); // Index button Edit related to this user. TODO: Find a way to calculate index in the framework, starting from the user email

            Assert.IsTrue(UsersPage.IsUserPresent("maria.rossi@email.it", "Maria1", "Rossi1", "Tokio"));
        }

        private void DeleteUser()
        {
            UserPage.DeleteUser()
                .WithEmail("maria.rossi@email.it")
                .Delete(9); // Index button Delete related to this user. TODO: Find a way to calculate index in the framework, starting from the user email

            Assert.IsFalse(UsersPage.IsUserPresent("maria.rossi@email.it"));
        }
    }
}
