namespace CSharpCore.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class LoginPage
    {
        public string EmailButton { get; } = "rev081091@gmail.com";

        public string PasswordButton { get; } = "***";

        [FindsBy(How = How.PartialLinkText, Using = @"Вход и регистрация")]
        public IWebElement Register { get; set; }
        [FindsBy(How = How.LinkText, Using = @"Google")]
        public IWebElement GoogleButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"#identifierId")]
        public IWebElement Login { get; set; }
        [FindsBy(How = How.CssSelector, Using = @"#password > div.aCsJod.oJeWuf > div > div.Xb9hP > input")]
        public IWebElement Password { get; set; }
    }
}
