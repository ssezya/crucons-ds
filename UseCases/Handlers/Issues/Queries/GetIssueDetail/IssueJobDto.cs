using System;

namespace UseCases.Handlers.Issues.Queries.GetIssueDetail
{
    public class IssueJobDto
    {
        public int JobId { get; set; }
        public string Description { get; set; }
        public string ActionName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
