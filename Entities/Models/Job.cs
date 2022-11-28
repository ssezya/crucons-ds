using Entities.Base;

namespace Entities.Models
{
    public class Job : AuditableEntity
    {
        public int JobId { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public int ActionId { get; set; }

        public Issue Issue { get; set; }
        public Status Action { get; set; }
    }
}
