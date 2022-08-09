using UITestAssignment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestAssignment.Data.JSONData
{
    public class Environments
    {
        public string Environment { get; set; }
        public string AdminCheckOutURL { get; set; }


        public List<Data.JSONData.Environments> GetEnvironmentDetails()
        {
            List<Data.JSONData.Environments> allEnvironments = null;

            allEnvironments = JsonHelper
                .GetObjectData<AppEnvironment>(@"C:\Users\akhire\Source\Repos\AGDataAssessment\UITestAssignment\Data\JSONData\Environments.json").Environments;
            return allEnvironments;
        }

        public class AppEnvironment
        {
            public List<Environments> Environments { get; set; }
        }
    }

    
}
