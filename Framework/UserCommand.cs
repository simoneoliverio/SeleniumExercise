using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Framework
{
    public class UserCommand
    {
        private string firstName;
        private string lastName;
        private string email;
        private string office;
        private UserGender gender;
        private DateTime birthday;
        private string notes;

        private const string deleteButton = "Delete";
        private const string editButton = "Edit";

        public UserCommand WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public UserCommand WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public UserCommand WithEmail(string email)
        {
            this.email = email;
            return this;
        }

        public UserCommand WithOffice(string office)
        {
            this.office = office;
            return this;
        }

        public UserCommand WithGender(UserGender gender)
        {
            this.gender = gender;
            return this;
        }

        public UserCommand WithBirthDay(DateTime birthday)
        {
            this.birthday = birthday;
            return this;
        }

        public UserCommand WithNotes(string notes)
        {
            this.notes = notes;
            return this;
        }

        public void Create()
        {
            var buttonNew = Driver.Instance.FindElement(By.ClassName("btn-default"));
            buttonNew.Click();

            FillFields();

            var createButton = Driver.Instance.FindElement(By.ClassName("btn-primary"));
            createButton.Click();
        }

        public void Edit()
        {
            IWebElement buttonEdit = GetButtonByText(editButton);
            WaitClickable(editButton);
            buttonEdit.Click();

            FillFields();

            var saveButton = Driver.Instance.FindElement(By.ClassName("btn-primary"));
            saveButton.Click();
        }
        
        public void Delete()
        {
            IWebElement buttonDelete = GetButtonByText(deleteButton);
            WaitClickable(deleteButton);
            buttonDelete.Click();

            Driver.Instance.SwitchTo().Alert().Accept();
        }

        private IWebElement GetButtonByText(string text)
        {
            IWebElement row = Driver.Instance.FindElement(By.XPath($"//tr[td[contains(text(), '{email}')]]"));
            IReadOnlyCollection<IWebElement> buttons = row.FindElements(By.TagName("button"));
            foreach (IWebElement button in buttons)
            {
                if (button.Text == text)
                {
                    return button;
                }
            }
            throw new Exception($"Button '{text}' not found");
        }

        private void FillFields()
        {
            var firstName = Driver.Instance.FindElement(By.Id("first-name"));
            firstName.Clear();
            firstName.SendKeys(this.firstName);

            var lastName = Driver.Instance.FindElement(By.Id("last-name"));
            lastName.Clear();
            lastName.SendKeys(this.lastName);

            var email = Driver.Instance.FindElement(By.Id("email"));
            email.SendKeys(this.email);

            var office = Driver.Instance.FindElement(By.Id("office"));
            office.SendKeys(this.office);

            var genderValues = Driver.Instance.FindElements(By.Name("gender"));
            if (this.gender == UserGender.Male)
                genderValues[0].Click();
            else if (this.gender == UserGender.Female)
                genderValues[1].Click();

            var additionalPanel = Driver.Instance.FindElement(By.LinkText("Additional"));
            additionalPanel.Click();

            var birthday = Driver.Instance.FindElement(By.Id("birthday"));
            birthday.Clear();
            birthday.SendKeys(this.birthday.ToString("dd/MM/yyyy"));

            var notes = Driver.Instance.FindElement(By.Id("notes"));
            notes.Clear();
            notes.SendKeys(this.notes);
        }

        private void WaitClickable(string text)
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[contains(text(), '{text}')]")));
        }
    }
}
