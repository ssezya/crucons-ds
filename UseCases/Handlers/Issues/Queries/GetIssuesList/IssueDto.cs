using System;

namespace UseCases.Handlers.Issues.Queries.GetIssuesList
{
    public class IssueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
