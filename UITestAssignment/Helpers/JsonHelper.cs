using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestAssignment.Helpers
{
    public static class JsonHelper
    {
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
