////namespace CSharpCore.Hooks
////{
////    using System;
////    using System.IO;
////    using BoDi;
////    using NUnit.Framework;
////    using OpenQA.Selenium;
////    using OpenQA.Selenium.Chrome;
////    using TechTalk.SpecFlow;

////    ////[Binding]
////    public sealed class ScreenShotSupport
////    {
////        private static string testResultsFolder;

////        private static int scenarioId;

////        private readonly IObjectContainer objectContainer;

////        public ScreenShotSupport(IObjectContainer objectContainer)
////        {
////            this.objectContainer = objectContainer;
////        }

////        ////[BeforeTestRun]
////        public static void CreateReportFolder()
////        {
////            string testResults = @"./TestResults/" + System.DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss tt");
////            Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
////            testResultsFolder = Directory.CreateDirectory(testResults).FullName;
////        }

////        ////[AfterScenario("web", Order = 1)]
////        public void AfterScenario()
////        {
////            scenarioId = scenarioId.Equals(0) ? 1 : scenarioId++;
////            string scenarioid = scenarioId + "_" + ScenarioContext.Current.ScenarioInfo.Title;
////            IWebDriver driver = objectContainer.Resolve<IWebDriver>();
////                string state = ScenarioContext.Current.TestError != null ? "error" : "passed";
////                string testScreenshotPath = testResultsFolder + "/" + scenarioid;
////                Console.WriteLine("Scenario screenshot is available: " + SaveScreenshot(testScreenshotPath, driver, state));
////            ////catch (Exception)
////            ////{
////            ////    ////TODO: add description to log file
////            ////}
////        }

////        private string SaveScreenshot(string testScreenshotPath, IWebDriver driver, string state)
////        {
////            var screenshotDriver = driver as ITakesScreenshot;
////            Screenshot screenshot = screenshotDriver.GetScreenshot();
////            string screenshotPath = testScreenshotPath + "_" + state + ".png";
////            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
////            return screenshotPath;
////        }
////    }
////}