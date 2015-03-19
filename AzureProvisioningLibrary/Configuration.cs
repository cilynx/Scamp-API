using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureProvisioningLibrary
{
    public static class ProvisioningLibraryConfiguration
    {
        public static string GetStorageConnectionString()
        {
            throw new NotImplementedException();
            return "DefaultEndpointsProtocol=https;AccountName=[AccountName];AccountKey=[AccountKey]";
        }

        public static string GetStorageSubscriptionCertificate()
        {
            //This is temporary unitll we get from DB
            throw new NotImplementedException();
            return "{add certificate}";
        }
        public static string GetStorageSubscriptionId()
        {
            //This is temporary unitll we get from DB
            throw new NotImplementedException();
            return "{add Subscription Id}";
        }
    }
}
