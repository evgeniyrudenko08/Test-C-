namespace CSharpCore.Pages
{
    using System;
    using System.Configuration;
    using Attributes;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
    using url = Attributes.GetFullUrl;

    [DefaultUrl("")]
    [At("")]
    public class CorePage
    {
        public CorePage(IWebDriver driver)
        {
            BaseUrl = ConfigurationManager.AppSettings["baseUrl"];
            this.Driver = driver;
            int elementTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["webElementLoadingTimeout"]);
            Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(elementTimeout));
            PageFactory.InitElements(driver, this);
        }

        protected string BaseUrl { get; private set; }

        protected IWebDriver Driver { get; private set; }

        protected WebDriverWait Wait { get; private set; }

        public CorePage Open()
        {
            Driver.Navigate().GoToUrl(BaseUrl + this.GetFullUrl());
            return this;
        }

        public CorePage Open(string url)
        {
            Driver.Navigate().GoToUrl(url);
            return this;
        }

        public string GetFullUrl()
        {
            return url.GetUrl(this);
        }

        public bool IsCurrentPage()
        {
            string expectedKeyWord = string.Empty;

            foreach (AtAttribute keyWordAt in GetType().GetCustomAttributes(typeof(AtAttribute), true))
            {
                expectedKeyWord = keyWordAt.GetAt();
            }

            return Driver.Url.Contains(expectedKeyWord);
        }
    }
}