using APITestAssignment.Configurations;
using APITestAssignment.Reporting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITestAssignment.APIScripts
{
    [TestClass]
    public class TestBase
    {
        public static HtmlReport report;
        public TestContext TestContext { get; set; }
        public static string TestUri { get; set; }

        [TestInitialize]
        public void TestSetUp()
        {
            TestUri = "https://jsonplaceholder.typicode.com";
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            var status = TestContext.CurrentTestOutcome;
            switch (status)
            {
                case UnitTestOutcome.Failed:
                    Assert.IsTrue(false, "failed");
                    break;
                case UnitTestOutcome.Inconclusive:
                    Assert.IsTrue(false, "inconclusive");
                    break;
                case UnitTestOutcome.NotRunnable:
                    Assert.IsTrue(false, "NotRunnable");
                    break;
                default:
                    Assert.IsTrue(true, "passed");
                    break;
            }
        }

        public void ReportError(Exception e)
        {
            if (e != null)
            {
                report.LogInfo(e.Message);
                Assert.Fail();
            }
        }
    }
}
