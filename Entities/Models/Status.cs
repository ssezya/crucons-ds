using System.Collections.Generic;
using Entities.Base;

namespace Entities.Models
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }

        public string ActionName { get; set; }

        public ICollection<Task> Tasks { get; private set; } = new HashSet<Task>();

        public ICollection<Job> Jobs { get; private set; } = new HashSet<Job>();
    }
}
