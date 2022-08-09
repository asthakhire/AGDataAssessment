using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestAssignment.Interface
{
    public interface IAutomationTool
    {
        public void LaunchAutomationTool(string browser, string launchMode = "Normal");

    }
}
