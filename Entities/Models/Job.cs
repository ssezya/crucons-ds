using System;
using Entities.Base;

namespace Entities.Models
{
    public class Job : BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public string Description { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int ActionId { get; set; }
        public Status Action { get; set; }
    }
}
