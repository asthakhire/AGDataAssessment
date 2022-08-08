using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UITestAssignment.Helper;

namespace UITestAssignment.PageClasses
{
    public class HomePage : PageBase
    {
        UIOperations uiOperations = new UIOperations(driver);
        #region Elements
        IWebElement CompanyTab = driver.FindElement(By.XPath("//header[@id='masthead']//div/ul[@id='primary-menu']//li[contains(.,'Company')]"));
        IWebElement CareersOption = driver.FindElement(By.XPath("//header[@id='masthead']//div/ul[@id='primary-menu']//li[contains(.,'Company')]//li[contains(.,'Careers')]"));

        #endregion

        public HomePage()
        { 
        }
        #region PageMethods
        public override void WaitForPageToLoad()
        {
            uiOperations.WaitForElementToPresent("//header[@id='masthead']//div/ul[@id='primary-menu']");
        }

        public void ClickCompanyCareersTab()
        {
            uiOperations.MouseHover(CompanyTab);
            CareersOption.Click();
        }
        #endregion

        #region VerificationMethods
        #endregion

    }
}
