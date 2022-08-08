using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace UITestAssignment.Helper
{
    public class UIOperations
    {
        public IWebDriver driver = null;
        private WebDriverWait explicitWait;


        public UIOperations(IWebDriver driver)
        {
            this.driver = driver;
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        public IWebElement WaitForElementToPresent(string xpath, string errorMessage = "")
        {
            IWebElement element = null;
            try
            {
                element = explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(xpath)));
            }
            catch { }
            if (!string.IsNullOrEmpty(errorMessage))
                if (element == null) 
                    ReportFailure(errorMessage, xpath);

            return element;
        }

        public void ReportFailure(string failureMesage, string screenshotFileName = "")
        {
            Assert.Fail(failureMesage);
        }

        public void NavigateTo(string navigateUri)
        {
            driver.Navigate().GoToUrl(navigateUri);
        }

        public void SwitchToFrame(IWebElement frameElement)
        {
            driver.SwitchTo().Frame(frameElement);
        }

        public void MouseHover(IWebElement element)
        {
            Actions mouseAction = new Actions(driver);
            mouseAction.MoveToElement(element, 1, 1).Build().Perform();
        }

        public void ScrollToViewElement(IWebElement webElement)
        {
            try
            {
                string elementId = webElement.GetAttribute("id");
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
            }
            catch (Exception ex)
            {
                ReportFailure("Exception occurred in ScrollToViewElement in : " + ex.Message, "ScrollToViewElementError");
            }
        }
    }
}
