using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureProvisioningLibrary;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure;

namespace AzureProvisioningJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        // TODO 
        static void Main()
        {

            string storageCstr = GetConnectionString();

            var host = new JobHost(new JobHostConfiguration(storageCstr));

            //AzureProvisioningLibrary.WebJobController w = new WebJobController();
            //w.SubmitActionInQueue(1, ResourceAction.Start);

            
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }

        private static string GetConnectionString()
        {

            string rv = null;

            rv = System.Environment.GetEnvironmentVariable("APPSETTING_StorageConnectionString");

            if (string.IsNullOrEmpty(rv))
                rv = CloudConfigurationManager.GetSetting("StorageConnectionString");


            if (string.IsNullOrEmpty(rv))
                throw new ArgumentNullException("you're missing StorageConnectionString in either ENV or Config");


            return rv;
        }
    }
}
