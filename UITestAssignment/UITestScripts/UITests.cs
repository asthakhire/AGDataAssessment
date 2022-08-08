using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UITestAssignment.PageClasses;

namespace UITestAssignment.UITestScripts
{
    [TestClass]
    public class UITests : TestBase
    {
		private HomePage homePage;
		private CareersPage careersPage;

		public UITests()
		{
			homePage = new HomePage();
			careersPage = new CareersPage();
		}

		[TestMethod]
		[TestProperty("Title", "AGData UI Test")]
		[TestProperty("ID", "101")]
		public void AGDataUITest()
		{
			try
			{
				PageObjects pageObjects = new PageObjects();
				//
				homePage.WaitForPageToLoad();
				//
				homePage.ClickCompanyCareersTab();
				careersPage.WaitForPageToLoad();

				//
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


			//Reporting.Log(Status.Info, "AGData UI test started");
			////Navigate to application
			//seleniumCommon.NavigateTo(Config.ApplicationUri);

			//IWebElement pageContents = seleniumCommon.WaitForElementToPresent(homePage.PageContent, $"After navigating {Config.ApplicationUri.ToString()} page contents are not availble");
			//Assert.IsNotNull(pageContents, "Page contents not found");

			//testCommon.NavigateToMenu(MainMenu.Company, SubMenu.Careers);

			//string currentAppUrl = chromeDriver.Url;
			//Assert.AreEqual(Path.Combine(Config.ApplicationUri.ToString(), "company/careers/"), currentAppUrl, "Application URL is not found as expected for Careers page");

			////Get all jobs from the page to the list
			////Switch control to iframe
			//IWebElement frameControl = seleniumCommon.WaitForElementToPresent(careersPage.OpenPositionsFrame, "iFrame containg list of open position is not found");
			//seleniumCommon.SwitchToFrame(frameControl);

			//IReadOnlyCollection<IWebElement> jobsCollection = seleniumCommon.WaitForElementsToPresent(careersPage.OpenPositionItem, "Jobs from Careers page are not found");
			//Assert.IsTrue(jobsCollection.Count != 0, "Open position items are not found from Careers page");

			//List<string> jobTitles = new List<string>();
			//Reporting.Log(Status.Info, $"Refer below list for {jobsCollection.Count} - open positions at AGData");
			//foreach (var jobItem in jobsCollection)
			//{
			//	string title = jobItem.Text;
			//	jobTitles.Add(title);
			//	Reporting.Log(Status.Info, title);
			//}
			//Reporting.Log(Status.Info, "List ends here!");

			////get second position containg Manager in job title
			//var jobTitleWithManager = from job in jobTitles where job.IndexOf("Manager", StringComparison.InvariantCultureIgnoreCase) >= 0 select job;
			//string requiredJobTitle = jobTitleWithManager.ElementAt(1);

			////Now get the control and perform a click operation on that
			//IWebElement requiredOpenPosition = seleniumCommon.WaitForElementToPresent(careersPage.OpenPositionWithRequiredTitle.Replace("%1", requiredJobTitle), $"Open position with title {requiredJobTitle} not found");
			//seleniumCommon.ScrollToViewElement(requiredOpenPosition);
			//requiredOpenPosition.Submit();

			//Reporting.Log(Status.Pass, "Done with last step from the test");
			//chromeDriver.Quit();
		}
	}
}
