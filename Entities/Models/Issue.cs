using System.Collections.Generic;
using Entities.Base;
using Entities.Enums;

namespace Entities.Models
{
    public class Issue : AuditableEntity
    {
        public Issue()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int ReporterId { get; set; }
        public IssueStatus StatusId { get; set; }
        public int? ExecutorId { get; set; }

        public Project Project { get; set; }
        public Employee Reporter { get; set; }
        public Employee Executor { get; set; }

        public ICollection<Job> Jobs { get; private set; }
    }
}
