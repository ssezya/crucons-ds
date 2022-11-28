using System.Collections.Generic;

namespace Entities.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string ActionName { get; set; }

        public ICollection<Issue> Issues { get; private set; } = new HashSet<Issue>();
        public ICollection<Job> Jobs { get; private set; } = new HashSet<Job>();
    }
}
