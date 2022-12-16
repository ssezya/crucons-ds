using Entities.Base;
using Entities.Enums;

namespace Entities.Models
{
    public class Job : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ExecutorId { get; set; }
        public int IssueId { get; set; }
        public JobAction ActionId { get; set; }

        public Employee Executor { get; set; }
        public Issue Issue { get; set; }
    }
}
