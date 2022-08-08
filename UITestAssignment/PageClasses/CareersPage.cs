using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITestAssignment.Helper;

namespace UITestAssignment.PageClasses
{
    public class CareersPage : PageBase
    {
        UIOperations uiOperations = new UIOperations(driver);
        #region Elements
        IWebElement PositionFrame = driver.FindElement(By.XPath(""));
        #endregion

        public CareersPage()
        {
        }

        #region PageMethods

        public override void WaitForPageToLoad()
        {
            uiOperations.WaitForElementToPresent("//section[@id='openings']");
        }

        public List<string> GetListOfOpenPositions()
        {
            IList<IWebElement> positionList = driver.FindElements(By.XPath("//span[@class='job']/a"));
            List<string> list = new List<string>();
            foreach (IWebElement posList in positionList)
            {
                list.Add(posList.Text);
            }
            return list;

        }

        public void ClickOnPosition(string positionName)
        {
            IWebElement position = driver.FindElement(By.XPath("//span[@class='job']/a[contains(.,'" + positionName + "')]"));
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
