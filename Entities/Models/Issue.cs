using System.Collections.Generic;
using Entities.Base;

namespace Entities.Models
{
    public class Issue : AuditableEntity
    {
        public int IssueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }

        public Employee Creator { get; set; }
        public Employee LastModificator { get; set; }
        public Status Status { get; set; }
        public ICollection<Job> Jobs { get; private set; } = new HashSet<Job>();
    }
}
