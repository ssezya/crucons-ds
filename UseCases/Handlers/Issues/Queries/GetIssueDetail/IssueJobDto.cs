using System;

namespace UseCases.Handlers.Issues.Queries.GetIssueDetail
{
    public class IssueJobDto
    {
        public int JobId { get; set; }
        public string Description { get; set; }
        public string ActionName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
