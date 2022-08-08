using System;
using System.Collections.Generic;
using System.Text;

namespace APITestAssignment.Reporting
{
    public interface IReports
    {
        string StartReport();
        void LogInfo(string logReport);
        void EndReport();
    }
}
