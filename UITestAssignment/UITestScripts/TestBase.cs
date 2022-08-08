using APITestAssignment.Reporting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITestAssignment.Helper;
using UITestAssignment.Selenium;

namespace UITestAssignment
{
    public class TestBase
    {
        public static HtmlReport report;
        public TestContext TestContext { get; set; }
        public AutomationTool AutomationTool;
        public IWebDriver driver;

        [TestInitialize]
        public void InitializeTest()
        {
            AutomationTool = new AutomationTool();
            AutomationTool.LaunchAutomationTool("Chrome");
            driver = AutomationTool.WebDriver;
            UIOperations operations = new UIOperations(driver);
            operations.driver = AutomationTool.WebDriver;
            try
            {
                operations.NavigateTo("https://www.agdata.com/");
            }
            catch (Exception e)
            {
                ReportError(e);
            }

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
