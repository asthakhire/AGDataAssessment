using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITestAssignment.Helpers;
using UITestAssignment.Selenium;

namespace UITestAssignment.PageClasses
{
    public class HomePage 
    {
        AutomationTool _automationTool;
        public HomePage(AutomationTool automationTool)
        {
            _automationTool = automationTool;
        }

        #region Elements
        IWebElement CompanyTab => _automationTool.WebDriver.FindElement(By.XPath("//header[@id='masthead']//div/ul[@id='primary-menu']//li[contains(.,'Company')]"));
        IWebElement CareersOption => _automationTool.WebDriver.FindElement(By.XPath("//header[@id='masthead']//div/ul[@id='primary-menu']//li[contains(.,'Company')]//li[contains(.,'Careers')]"));
        IWebElement PageLoadElement => _automationTool.WebDriver.FindElement(By.XPath("//header[@id='masthead']//div/ul[@id='primary-menu']"));

        #endregion

        #region PageMethods
        //public override void WaitForPageToLoad()
        //{
        //    //uiOperations.WaitForElementToPresent("//header[@id='masthead']//div/ul[@id='primary-menu']");
        //}

        public void ClickCompanyCareersTab()
        {
            //uiOperations.MouseHover(CompanyTab);
            CareersOption.Click();
        }
        #endregion

        #region VerificationMethods
        #endregion

    }
}
