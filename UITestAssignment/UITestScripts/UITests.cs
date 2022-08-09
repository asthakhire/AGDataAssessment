using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITestAssignment.BaseClass;
using UITestAssignment.PageClasses;
using UITestAssignment.Selenium;

namespace UITestAssignment.UITestScripts
{
    [TestClass]
    public class UITests : TestBase
    {
		private HomePage homePage;
		private CareersPage careersPage;

		[TestMethod]
		[TestProperty("Title", "AGData UI Test")]
		[TestProperty("ID", "101")]
		public void AGDataUITest()
		{
			homePage = new HomePage(_automationTool);
			careersPage = new CareersPage(_automationTool);
			try
			{
				report.StartTest("AGDataTest", "UI Test - Validate Open Position");
				report.LogInfo("AGData home page loads");
				homePage.WaitForPageToLoad();

				report.LogInfo("Open the careers page from Company tab");
				homePage.ClickCompanyCareersTab();
				careersPage.WaitForPageToLoad();

				careersPage.SwitchToFrame();

				report.LogInfo("Get list of all the open positions");
				List<string> lst = careersPage.GetListOfOpenPositions();

				report.LogInfo("Open the position of Manager");
				careersPage.ClickOnPosition(lst.Where(pos => pos.Contains("Customer Support Manager")).FirstOrDefault());

				report.LogInfo("Verify the selected position is opened");
				careersPage.VerifyOpenPositionLoaded();

			}
			catch(Exception e)
            {
				ReportError(e);
            }
		}
	}
}
