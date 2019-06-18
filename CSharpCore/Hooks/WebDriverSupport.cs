namespace CSharpCore.Hooks
{
    using System;
    using System.Configuration;
    using BoDi;
    using TechTalk.SpecFlow;

    [Binding]
    public class WebDriverSupport
    {
        private static SeleniumContext seleniumContext;
        private readonly IObjectContainer objectContainer;

        public WebDriverSupport(IObjectContainer container)
        {
            this.objectContainer = container;
        }

        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {
            seleniumContext = new SeleniumContext();
        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            seleniumContext.WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseUrl"]);
            objectContainer.RegisterInstanceAs<SeleniumContext>(seleniumContext);
            seleniumContext.WebDriver.Manage().Window.Maximize();
            seleniumContext.WebDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromMilliseconds(10);
            seleniumContext.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            seleniumContext.WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);           
        }

        [AfterScenario(Order = 100)]
        public void AfterScenario()
        {
            try
            {
                if (seleniumContext.WebDriver != null)
                {
                    seleniumContext.WebDriver.Quit();
                    seleniumContext.WebDriver.Dispose();
                }
            }
            catch (Exception)
            {
                ////Skip any exceptions for now
            }
        }
    }
}