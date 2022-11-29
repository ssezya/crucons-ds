using MediatR;

namespace UseCases.Handlers.Issues.Queries.GetIssueDetail
{
    public class GetIssueDetailQuery : IRequest<IssueDetailVm>
    {
        public int Id { get; set; }
    }
}
