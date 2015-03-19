using System.Collections.Generic;

namespace ScampApi.ViewModels
{
    public class GroupTemplateSummary
    {
        public GroupTemplateSummary()
        {
            Links = new List<Link>();
        }
        public string GroupId { get; set; }
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public List<Link> Links { get; set; }
    }
}
