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
        UIOperations uiOperations;
        public HomePage(AutomationTool automationTool)
        {
            _automationTool = automationTool;
            uiOperations = new UIOperations();
        }

        #region Elements
        IWebElement CompanyTab => _automationTool.WebDriver.FindElement(By.XPath("//header[@id='masthead']//div/ul[@id='primary-menu']//li[contains(.,'Company')]"));
        IWebElement CareersOption => _automationTool.WebDriver.FindElement(By.XPath("//header[@id='masthead']//div/ul[@id='primary-menu']//li[contains(.,'Company')]//li[contains(.,'Careers')]"));
        IWebElement PageLoadElement => _automationTool.WebDriver.FindElement(By.XPath("//header[@id='masthead']//div/ul[@id='primary-menu']"));

        #endregion

        #region PageMethods
        public void WaitForPageToLoad()
        {
            uiOperations.WaitForElementToPresent("//header[@id='masthead']//div/ul[@id='primary-menu']",_automationTool.WebDriver);
        }

        public void ClickCompanyCareersTab()
        {
            uiOperations.MouseHover(CompanyTab, _automationTool.WebDriver);
            CareersOption.Click();
        }
        #endregion

        #region VerificationMethods
        #endregion

    }
}
