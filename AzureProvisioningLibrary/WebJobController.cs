using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace AzureProvisioningLibrary
{
    public class WebJobController
    {
        IDictionary<string, string> _settings;

        public WebJobController(IDictionary<string, string> settings)
        {
            _settings = settings;   
        }

        public Guid SubmitActionInQueue(int resourceId, AzureProvisioningLibrary.ResourceAction  action)
        {
            var storageConnectionString = _settings["StorageConnectionString"];
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString); 


            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("processorqueue");


            queue.CreateIfNotExists();
            var actionId = Guid.NewGuid();

            var actionMessage    = new QueueMessage()
            {
                OperationGuid = actionId,
                Action  = action,
                ResourceId = resourceId
            };


            queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(actionMessage)));
            return actionId;
        }

        public void SubmitActionInQueue(int resourceId, string actionname)
        {
            var action= ResourceAction.Undefined;
            if (actionname.ToLowerInvariant() == "start")
            {
                action = ResourceAction.Start;
            }
            if (actionname.ToLowerInvariant() == "stop")
            {
                action = ResourceAction.Stop;
            }
            if (actionname.ToLowerInvariant() == "create")
            {
                action = ResourceAction.Create;
            }
            if (action == ResourceAction.Undefined) throw new Exception("Action no defined");

            this.SubmitActionInQueue(resourceId, action);

        }
    }
}
