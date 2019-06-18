namespace CSharpCore.Pages
{
    using Attributes;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    [DefaultUrl("")]
    [At("new/Home/Index")]
    public class TestPage : CorePage
    {
        [FindsBy(How = How.Id, Using = @"log-out-link")]
        private IWebElement logoutButton;
        [FindsBy(How = How.Id, Using = @"111")]
        private IWebElement title;

        public TestPage(OpenQA.Selenium.IWebDriver driver)
            : base(driver)
        {
        }

        public bool SubmitPasswordChange()
        {
            return logoutButton.Displayed;
        }

        public string GetTitle()
        {
            return title.Text;
        }
    }
}
