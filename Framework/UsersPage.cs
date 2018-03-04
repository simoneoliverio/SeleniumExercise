using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Framework
{
    public class UsersPage
    {
        const int columnsCount = 5;
        
        public static bool IsAt
        {
            get
            {
                var h1 = Driver.Instance.FindElement(By.TagName("h1"));
                if (h1 != null)
                {
                    return h1.Text == "Users";
                }
                return false;
            }
        }

        public static bool IsPresentAdmin
        {
            get
            {
                return IsUserPresent("admin");
            }
        }

        public static bool IsUserPresent(string email)
        {
            var trs = Driver.Instance.FindElements(By.TagName("tr"));
            if (trs.Count >= 2)
            {
                var tds = Driver.Instance.FindElements(By.TagName("td"));
                if (tds.Count >= 3)
                {
                    if (IsPresentEmail(email, tds))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsUserPresent(string email, string firstName, string lastName, string office)
        {
            var trs = Driver.Instance.FindElements(By.TagName("tr"));
            if (trs.Count >= 2)
            {
                var tds = Driver.Instance.FindElements(By.TagName("td"));
                if (tds.Count >= 3)
                {
                    if (IsPresentUser(email, firstName, lastName, office, tds))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsPresentUser(string email, string firstName, string lastName, string office, ReadOnlyCollection<IWebElement> tds)
        {
            for (int i = 0; i < tds.Count; i += columnsCount)
            {
                if (
                        tds[i].Text.Equals(firstName) &&
                        tds[i + 1].Text.Equals(lastName) &&
                        tds[i + 2].Text.Equals(email) &&
                        tds[i + 3].Text.Equals(office)
                    )
                {
                    return true;
                }
            }
            return false;
        }

        public static void ViewAdmin()
        {
            var anchorViewAdmin = Driver.Instance.FindElements(By.ClassName("btn-default"))[1];
            anchorViewAdmin.Click();
        }

        private static bool IsPresentEmail(string email, ReadOnlyCollection<IWebElement> tds)
        {
            for (int i = 2; i < tds.Count; i += columnsCount)
            {
                if (tds[i].Text.Contains(email))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
