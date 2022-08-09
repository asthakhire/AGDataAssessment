using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APITestAssignment.Reporting
{
    public class HtmlReport : IReports
    {
        private ExtentReports _extent;
        private ExtentTest _test;

        private string ReportFolderLocation { get; set; }

        public HtmlReport(string reportFolderLocation)
        {
            ReportFolderLocation = reportFolderLocation;
        }

        private void CreateReportFolder()
        {
            String reportFolderPath = ReportFolderLocation;
            var todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!Directory.Exists(reportFolderPath + "\\" + todaysdate))
            {
                Directory.CreateDirectory(reportFolderPath + "\\" + todaysdate);
            }
            ReportFolderLocation = reportFolderPath + "\\" + todaysdate;
        }

        private string CreateReportFile(string reportFolderPath)
        {
            string reportDateTime = string.Format("{0:ddMMMyyyy-HHmm}", DateTime.Now);
            string reportPath = reportFolderPath + "\\ExeReport" + reportDateTime + ".html";

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);

            htmlReporter.Config.ReportName = "Automation Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            return reportPath;
        }
        public string StartReport()
        {
            CreateReportFolder();
            string reportPath = CreateReportFile(ReportFolderLocation);
            return reportPath;
        }

        public void StartTest(string testCaseId, string testCaseTitle)
        {
            _test = _extent.CreateTest(testCaseId, testCaseTitle);
        }

        public void LogInfo(string logReport)
        {
            _test.Log(Status.Info, logReport);
        }

        public void EndReport()
        {
            _extent.Flush();
        }

    }
    public enum ReportStatus
    {
        Pass,
        Fail,
    }
}
