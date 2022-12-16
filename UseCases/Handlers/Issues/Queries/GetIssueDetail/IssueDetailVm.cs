using System.Collections.Generic;

namespace UseCases.Handlers.Issues.Queries.GetIssueDetail
{
    public class IssueDetailVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public string ReporterName { get; set; }
        public string StatusName { get; set; }
        public string ExecutorName { get; set; }

        public ICollection<IssueJobDto> Jobs { get; set; }
    }
}
