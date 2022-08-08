using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace UITestAssignment.Selenium
{
    public class SeleniumEngine
    {
        public IWebDriver Start(string browser, string launchMode = "Normal")
        {
            try
            {
                IWebDriver webDriver = null;
                switch (browser.ToLower())
                {
                    case "firefox":
                        break;
                    case "chrome":
                        var chromeOptions = new ChromeOptions();
                        switch (launchMode)
                        {
                            case "InCognito":
                                chromeOptions.AddArgument("--incognito");
                                break;
                            case "Headless":
                                chromeOptions.AddArgument("--headless");
                                break;
                        }
                        webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
                        break;
                    case "edge":
                        break;
                }
                if (webDriver != null)
                {
                    webDriver.Manage().Window.Maximize();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                    return webDriver;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
