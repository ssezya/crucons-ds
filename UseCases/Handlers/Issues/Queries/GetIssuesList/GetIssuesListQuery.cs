using MediatR;

namespace UseCases.Handlers.Issues.Queries.GetIssuesList
{
    public class GetIssuesListQuery : IRequest<IssuesListVm> { }
}
