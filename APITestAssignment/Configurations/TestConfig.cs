using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APITestAssignment.Configurations
{
    public static class TestConfig
    {
        public static string TestUri { get; set; }

        static TestConfig()
        {
            //TestUri = GetObjectData<string>(@"C:\Users\akhire\Source\Repos\AGDataAssessment\APITestAssignment\Configurations\TestConfig.json");
            TestUri = "https://jsonplaceholder.typicode.com";

        }

        public static T GetObjectData<T>(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

    }
}
