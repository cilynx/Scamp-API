using System.Collections.Generic;

namespace ScampApi.ViewModels
{
    public class GroupSummary
    {
        public GroupSummary()
        {
            Links = new List<Link>();
        }
        public int GroupId { get; set; }
        public string Name { get; set; }

        public List<Link> Links { get; set; }

    }
}
