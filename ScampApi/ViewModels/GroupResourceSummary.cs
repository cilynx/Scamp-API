using System.Collections.Generic;

namespace ScampApi.ViewModels
{
    public class GroupResourceSummary
    {
        public GroupResourceSummary()
        {
            Links = new List<Link>();
        }
        public int GroupId { get; set; }
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public List<Link> Links { get; set; }

    }
}
