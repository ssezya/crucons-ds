using Entities.Enums;

namespace UseCases.Handlers.Issues.Commands.UpdateIssue
{
    public class UpdateIssueDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int ReporterId { get; set; }
        public int? ExecutorId { get; set; }
        public IssueStatus StatusId { get; set; }
    }
}
