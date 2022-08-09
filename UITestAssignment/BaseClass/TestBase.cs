using UITestAssignment.BaseNavigationMethods;
using UITestAssignment.Helpers;
using UITestAssignment.Selenium;
using UITestAssignment.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using APITestAssignment.Reporting;
using System;
using System.IO;

namespace UITestAssignment.BaseClass
{
    [TestClass]
    public abstract class TestBase
    {
        public static HtmlReport report;

        public TestContext context { get; set; }
        public string browser;
        public AutomationTool _automationTool { get; set; }
        //public IWebDriver driver;

        [AssemblyInitialize]
        public static void AssemblySetup(TestContext _context)
        {
            ResourceInitialize.Initialize(_context);
            report = new HtmlReport(Directory.GetCurrentDirectory());
        }
        [AssemblyCleanup]
        public static void TearDown()
        {
            //Console.WriteLine("Test");
        }
        [TestInitialize]
        public void TestSetup()
        {
            report.StartReport();
            _automationTool = new AutomationTool();
            _automationTool.LaunchAutomationTool(ResourceInitialize.browser);
            var bmNavigationMethods = new NavigationMethods(_automationTool);
            bmNavigationMethods.ClearAllCookies();
            //var loginPage = new LoginPage(_automationTool);
            var testMethods = new TestMethods(_automationTool);
            try
            {
                testMethods.NavigateToHomePage(ResourceInitialize.AppUrl);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            _automationTool.WebDriver.Close();
            report.EndReport();
        }

        public void ReportError(Exception e)
        {
            if (e != null)
            {
                report.LogInfo(e.Message);
                Assert.Fail();
            }
        }
    }
}