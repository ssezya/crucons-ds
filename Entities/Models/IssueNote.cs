using Entities.Base;

namespace Entities.Models
{
    public class IssueNote : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int WriterId { get; set; }
        public int IssueId { get; set; }

        public Employee Writer { get; set; }
        public Issue Issue { get; set; }
    }
}
