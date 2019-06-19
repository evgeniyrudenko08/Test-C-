namespace TestApplication.UiTests.Support
{
    using System;
    using System.Drawing.Imaging;
    using System.IO;
    using CSharpCore.Hooks;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;

    [Binding]
    public class Screenshots
    {
        private SeleniumContext seleniumContext;

        public Screenshots(SeleniumContext seleniumContext)
        {
            ////save the context so you can use it in your tests
            this.seleniumContext = seleniumContext;
        }

        [AfterScenario(Order = 1)]
        public void OnError()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                // get and save a screenshot from a webdriver
                var takesScreenshot = seleniumContext.WebDriver as ITakesScreenshot;
                if (takesScreenshot != null)
                {
                    string screenshotFileName = string.Format(
                      string.Format(
                      "{0}_{1}_{2}.png",
                      FeatureContext.Current.FeatureInfo.Title,
                      ScenarioContext.Current.ScenarioInfo.Title,
                      DateTime.Now.ToString("s").Replace(":", string.Empty)));
                    var artifactDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "testresults");
                    string screenshotFilePath = System.IO.Path.Combine(artifactDirectory, screenshotFileName);
                    var screenshot = takesScreenshot.GetScreenshot();
                    screenshot.SaveAsFile(screenshotFilePath, ImageFormat.Png);
                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath)); 123
                }
            }
        }      
    }
}