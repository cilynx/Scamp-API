using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure;
using System.Threading;
using AzureProvisioningLibrary;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Models;

namespace AzureProvisioningJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("processorqueue")] QueueMessage message, TextWriter log)
        {
            //TODO Get cert from DB and SubscritpionId
            const string cert = "{add certificate}";
            const string subscriptionId = "{add Subscription Id}";
            var resourceController  = new ResourceController(cert, subscriptionId);
            //TODO Get Connection string from DB

            if (message.Action == ResourceAction.Stop )
            {
                log.WriteLine("Stopping VM");
                resourceController.StartStopVirtualMachine("VSGAB", VirtualMachineAction.Start).RunSynchronously();
            }
            if (message.Action == ResourceAction.Stop)
            {
                log.WriteLine("Starting VM");
                resourceController.StartStopVirtualMachine("VSGAB", VirtualMachineAction.Stop).RunSynchronously();

            }
            if (message.Action == ResourceAction.Create )
            {
                log.WriteLine("Creating VM");
                var vmName = "gabrielc-" + (new Random()).Next(1, 1000);
                log.WriteLine("Creating Cloud Services");
                resourceController.CreateCloudService(vmName, LocationNames.NorthEurope).RunSynchronously();
                log.WriteLine("Creating Storage");
                resourceController.CreateStorageAccount(LocationNames.NorthEurope, vmName).RunSynchronously();
                log.WriteLine("Creating Virtual Machine");
                resourceController.CreateVirtualMachine(vmName, vmName, vmName, "gabrielc", "Enter.321", "Visual-Studio-2015-Ultimate", VirtualMachineRoleSize.Small).RunSynchronously();

            }
          

            log.WriteLine(message);
        }

    }

}
