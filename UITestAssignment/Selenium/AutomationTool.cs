using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITestAssignment.Selenium
{
    public class AutomationTool
    {
        public IWebDriver WebDriver = null;

        public void LaunchAutomationTool(string browser, string launchMode = "Normal")
        {
            var engine = new SeleniumEngine();
            WebDriver = engine.Start(browser, launchMode);
        }
    }
}
