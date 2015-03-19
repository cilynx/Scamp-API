using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDbRepositories
{
    public class ScampResourceGroup
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Name { get; set; }
		public List<ScampUser> Admins { get; set; }
		public List<ScampUser> Members { get; set; }
		public List<ScampResource> Resources { get; set; }
	}
}
