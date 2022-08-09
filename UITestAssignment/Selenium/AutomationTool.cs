using UITestAssignment.Interface;
using UITestAssignment.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestAssignment.Selenium
{
    public class AutomationTool : IAutomationTool
    {
        public IWebDriver WebDriver = null;

        public void LaunchAutomationTool(string browser, string launchMode = "Normal")
        {
            var browserUtility = new BrowserUtility();
            WebDriver = browserUtility.Start(browser, launchMode);
        }
    }
}
