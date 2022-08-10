using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestAssignment.Helpers
{
    public static class ResourceInitialize
    {
        public static string browser;
        public static string Env;
        public static IWebDriver webDriver;
        public static string AppUrl;

        public static void Initialize(TestContext testContext)
        {
            InitializeEnvironmentVariables(testContext);
        }

        public static void InitializeEnvironmentVariables(TestContext context)
        {
            browser = context.Properties["Browser"].ToString();
            Env = context.Properties["Environment"].ToString();

            Data.JSONData.Environments environments = new Data.JSONData.Environments();
            Data.JSONData.Environments environment = environments.GetEnvironmentDetails().FirstOrDefault(x => x.Environment == Env.ToString());

            if (environment != null)
            {
                ResourceInitialize.AppUrl = environment.AdminCheckOutURL;
            }

        }
    }
}
