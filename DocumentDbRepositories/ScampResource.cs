using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDbRepositories
{
    public class ScampResource
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Name { get; set; }
		public string AzureResourceID { get; set; }
		public string SubscriptionID { get; set; }
		public string ResourceType { get; set; }
		public string State { get; set; }
		public List<ScampUser> Owners { get; set; }
	}
}
