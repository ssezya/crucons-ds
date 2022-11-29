using System.Collections.Generic;

namespace UseCases.Handlers.Issues.Queries.GetIssuesList
{
    public class IssuesListVm
    {
        public ICollection<IssueDto> Issues { get; set; }
    }
}
