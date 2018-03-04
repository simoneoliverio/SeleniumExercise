using System;
using OpenQA.Selenium;

namespace Framework
{
    public class UserPage
    {
        public static bool IsAdmin
        {
            get
            {
                var emailDd = Driver.Instance.FindElements(By.TagName("dd"))[0];
                if (emailDd.Text.Contains("admin"))
                {
                    return true;
                }
                return false;
            }
        }

        public static UserCommand AddNewUser()
        {
            return new UserCommand();
        }
    }
}
