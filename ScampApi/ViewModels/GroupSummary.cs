using System.Collections.Generic;

namespace ScampApi.ViewModels
{
    public class GroupSummary
    {
        public string GroupId { get; set; }
        public GroupSummary()
        {
            Links = new List<Link>();
        }
        public string Name { get; set; }

        public List<Link> Links { get; set; }

    }
}
