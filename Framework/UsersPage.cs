using OpenQA.Selenium;

namespace Framework
{
    public class UsersPage
    {
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
                var trs = Driver.Instance.FindElements(By.TagName("tr"));
                if (trs.Count >= 2)
                {
                    var tds = Driver.Instance.FindElements(By.TagName("td"));
                    if (tds.Count >= 3)
                    {
                        if (tds[2].Text.Contains("admin"))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public static void ViewAdmin()
        {
            var anchorViewAdmin = Driver.Instance.FindElements(By.ClassName("btn-default"))[1];
            anchorViewAdmin.Click();
        }
    }
}
