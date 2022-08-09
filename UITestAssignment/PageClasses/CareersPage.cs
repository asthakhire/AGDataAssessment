using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITestAssignment.Helpers;
using UITestAssignment.Selenium;

namespace UITestAssignment.PageClasses
{
    public class CareersPage 
    {
        AutomationTool _automationTool;
        UIOperations uiOperations;

        public CareersPage(AutomationTool automationTool)
        {
            _automationTool = automationTool;
            uiOperations = new UIOperations();
        }
        #region Elements
        IWebElement PositionFrame => _automationTool.WebDriver.FindElement(By.XPath(""));
        #endregion

        #region PageMethods

        public void WaitForPageToLoad()
        {
            uiOperations.WaitForElementToPresent("//section[@id='openings']",_automationTool.WebDriver);
        }

        public List<string> GetListOfOpenPositions()
        {
            IList<IWebElement> positionList = _automationTool.WebDriver.FindElements(By.XPath("//span[@class='job']/a"));
            List<string> list = new List<string>();
            foreach (IWebElement posList in positionList)
            {
                list.Add(posList.Text);
            }
            return list;

        }

        public void SwitchToFrame()
        {
            _automationTool.WebDriver.SwitchTo().Frame("HBIFRAME");
        }

        public void ClickOnPosition(string positionName)
        {
            IWebElement position = _automationTool.WebDriver.FindElement(By.XPath("//span[@class='job']/a[contains(.,'" + positionName + "')]"));
            position.Click();
        }

        #endregion

        #region validation

        public void VerifyOpenPositionLoaded()
        {

        }
        #endregion
    }
}
