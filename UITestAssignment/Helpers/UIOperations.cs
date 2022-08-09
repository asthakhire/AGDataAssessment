using APITestAssignment.Reporting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITestAssignment.Helpers
{
    public class UIOperations
    {
        private WebDriverWait explicitWait;
        private HtmlReport report;

        public void MouseHover(IWebElement element,IWebDriver driver)
        {
            Actions mouseAction = new Actions(driver);
            mouseAction.MoveToElement(element, 1, 1).Build().Perform();
        }

        public void WaitForElementToPresent(string xpath, IWebDriver driver)
        {
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement element = null;
            try
            {
                element = explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(xpath)));
            }
            catch(Exception e)
            {
                report.LogInfo("element not found");
            }

        }
    }
}
