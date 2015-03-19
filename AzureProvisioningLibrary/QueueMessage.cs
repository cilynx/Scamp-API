using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureProvisioningLibrary
{
    public class QueueMessage
    {
        public Guid OperationGuid { get; set; }
        public int ResourceId { get; set; }
        public ResourceAction Action { get; set; }
    }
}
