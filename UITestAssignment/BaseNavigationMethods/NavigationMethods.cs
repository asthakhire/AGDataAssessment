using UITestAssignment.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestAssignment.BaseNavigationMethods
{
    public class NavigationMethods
    {
		AutomationTool _automationTool;

		public NavigationMethods(AutomationTool automationTool)
        {
			_automationTool = automationTool;

		}
		public void ClearAllCookies()
		{
			_automationTool.WebDriver.Manage().Cookies.DeleteAllCookies();
		}
		public void Back()
		{
			_automationTool.WebDriver.Navigate().Back();
		}
		public void SwitchToNewTab()
		{
			var windowHandles = _automationTool.WebDriver.WindowHandles;
			while (windowHandles.Count <= 1)
			{
				windowHandles = _automationTool.WebDriver.WindowHandles;
			}
			_automationTool.WebDriver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
		}
		public void closecurrenttab()
		{
			var windowHandles = _automationTool.WebDriver.WindowHandles;
			while (windowHandles.Count <= 1)
			{
				windowHandles = _automationTool.WebDriver.WindowHandles;
			}
			_automationTool.WebDriver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
			_automationTool.WebDriver.Close();
			_automationTool.WebDriver.SwitchTo().Window(windowHandles[0]);
		}
		public void RefreshPage()
		{
			_automationTool.WebDriver.Navigate().Refresh();
		}
		public void SwitchToMainTab()
		{
			var windowHandles = _automationTool.WebDriver.WindowHandles;
			_automationTool.WebDriver.SwitchTo().Window(windowHandles[0]);
			//Framework.Report.Log(Framework.Report.GetLogStatus(true), "Swtiched to home Window.");
		}
		public void VerifyUrlContains(string valueToCheck)
		{
			_automationTool.WebDriver.Url.Contains(valueToCheck);
		}

		public void VerifyPageTitleContains(string valueToCheck)
		{
			_automationTool.WebDriver.Title.Contains(valueToCheck);
		}
	}
}
