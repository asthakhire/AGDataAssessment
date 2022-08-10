using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using APITestAssignment.Configurations;

namespace APITestAssignment.Data.JSONData
{
    public class Environments
    {
        public string Environment { get; set; }
        public string AdminCheckOutURL { get; set; }


        public List<Data.JSONData.Environments> GetEnvironmentDetails()
        {
            string ApplicationFileLocation = Directory.GetCurrentDirectory();
            List<Data.JSONData.Environments> allEnvironments = null;
            allEnvironments = TestConfig
                .GetObjectData<AppEnvironment>(ApplicationFileLocation + "\\Data\\JSONData\\Environments.json").Environments;
            return allEnvironments;
        } 

        public class AppEnvironment
        {
            public List<Environments> Environments { get; set; }
        }
    }

    
}
