namespace CSharpCore.Hooks
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using TechTalk.SpecFlow;

    [Binding]
    public class SeleniumContext
    {
        public SeleniumContext()
        {
            ////create the selenium context
            WebDriver = new ChromeDriver();
        }

        public IWebDriver WebDriver { get; private set; }
    }    
}
