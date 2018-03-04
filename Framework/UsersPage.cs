﻿using System.Collections.ObjectModel;
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
