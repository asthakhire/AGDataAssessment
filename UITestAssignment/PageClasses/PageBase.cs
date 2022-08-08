using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITestAssignment.PageClasses
{
    public abstract class PageBase
    {
        public abstract void WaitForPageToLoad();

        public static IWebDriver driver;
    }
}
