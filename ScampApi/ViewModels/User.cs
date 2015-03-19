using System;
using System.Collections.Generic;


namespace ScampApi.ViewModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<GroupSummary> Groups { get; internal set; }
        public IEnumerable<GroupResourceSummary> Resources { get; internal set; }
    }
}