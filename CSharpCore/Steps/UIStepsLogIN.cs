namespace CSharpCore.Steps
{
    using System.Linq;
    using CSharpCore.Hooks;
    using CSharpCore.Pages;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.PageObjects;
    using TechTalk.SpecFlow;
    [Binding]
    public sealed class UiStepsLogin
    {
        private SeleniumContext seleniumContext;
        private LoginPage loginPage = new LoginPage();
        
        public UiStepsLogin(SeleniumContext seleniumContext)
        {
            ////save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
        }

        [Given("Click registration button")]
        public void ClickRegistrationButton()
        {
            PageFactory.InitElements(seleniumContext.WebDriver, loginPage);
            loginPage.Register.Click();
        }

        [When("Login via google")]
        public void Login()
        {
            PageFactory.InitElements(seleniumContext.WebDriver, loginPage);
            loginPage.GoogleButton.Click();
            ////switch to a new window
            Actions newTab = new Actions(seleniumContext.WebDriver);
            newTab 
                .KeyDown(Keys.Control)
                .KeyDown(Keys.Shift)
                .Click(loginPage.GoogleButton).KeyUp(Keys.Control).KeyUp(Keys.Shift)
                .Build()
                .Perform();
            seleniumContext.WebDriver.SwitchTo().Window(seleniumContext.WebDriver.WindowHandles.Last());
            ////login field
            loginPage.Login.SendKeys(loginPage.EmailButton + Keys.Enter);
            ////password field
            loginPage.Password.SendKeys(loginPage.PasswordButton + Keys.Enter);
        }
    }
}
