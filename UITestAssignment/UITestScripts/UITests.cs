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
				PageObjects pageObjects = new PageObjects();
				
				//homePage.WaitForPageToLoad();
				
				homePage.ClickCompanyCareersTab();
				//careersPage.WaitForPageToLoad();

				careersPage.SwitchToFrame();
				List<string> lst = careersPage.GetListOfOpenPositions();
				//
				careersPage.ClickOnPosition(lst.Where(pos => pos.Contains("Customer Support Manager")).FirstOrDefault());
				//
				careersPage.VerifyOpenPositionLoaded();

			}
			catch(Exception e)
            {
				ReportError(e);
            }
		}
	}
}
