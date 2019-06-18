namespace CSharpCore.Steps
{
    using System;
    using CSharpCore.Hooks;
    using CSharpCore.Pages;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class UiSteps 
    {
        private SeleniumContext seleniumContext;
        private JobPage jobPage = new JobPage();
        
        public UiSteps(SeleniumContext seleniumContext)
        {
            this.seleniumContext = seleniumContext;
        }

        [Given(@"I search by Java job")]
        public void WhenIOpenMainPage()
        {
            PageFactory.InitElements(seleniumContext.WebDriver, jobPage);
            jobPage.Search.SendKeys("Java2" + Keys.Enter); 
        }

        [When(@"I search job in Kiev")]
        public void SearchJob()
        {
            try
            {
                PageFactory.InitElements(seleniumContext.WebDriver, jobPage);
                jobPage.CityButton.Click();
            }
            catch (Exception)
            {
                throw new Exception("Exception appers");
            }
        }
    }
}
