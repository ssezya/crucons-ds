using System;
using System.Collections.Generic;
using Entities.Base;

namespace Entities.Models
{
    public class Task : BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public ICollection<Job> Jobs { get; private set; } = new HashSet<Job>();
    }
}
