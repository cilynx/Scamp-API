using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDbRepositories
{
    public class ScampSubscription
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string AzureSubscriptionID { get; set; }
		public string AzureAdminUser { get; set; }
		public string AzureAdminPassword { get; set; }
		public string AzureManagementThumbnail { get; set; }
	}
}
