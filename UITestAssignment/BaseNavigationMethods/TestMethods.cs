using UITestAssignment.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestAssignment.BaseNavigationMethods
{
    public class TestMethods
    {
        AutomationTool _automationTool;
        public TestMethods(AutomationTool automationTool)
        {
            _automationTool = automationTool;
        }
        public void NavigateToHomePage(string url)
        {
            _automationTool.WebDriver.Navigate().GoToUrl(url);
        }
    }
}
