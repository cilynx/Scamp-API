using System;
using System.Collections.Generic;

namespace ScampApi.ViewModels
{
    public class UserSummary
    {
        public UserSummary()
        {
            Links = new List<Link>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }

        public List<Link> Links { get; set; }
    }
}