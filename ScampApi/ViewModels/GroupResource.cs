﻿using System.Collections.Generic;

namespace ScampApi.ViewModels
{
    public class GroupResource
    {
        public int GroupId { get; set; }
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserSummary> Users { get; set; }
    }
}
