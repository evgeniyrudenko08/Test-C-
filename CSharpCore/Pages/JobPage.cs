namespace CSharpCore.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class JobPage
    {
        [FindsBy(How = How.Name, Using = @"search")]
        public IWebElement Search { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = @"Киев")]
        public IWebElement CityButton { get; set; }
    }
}
