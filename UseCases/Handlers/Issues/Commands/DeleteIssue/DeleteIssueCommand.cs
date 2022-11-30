using MediatR;

namespace UseCases.Handlers.Issues.Commands.DeleteIssue
{
    public class DeleteIssueCommand : IRequest
    {
        public int Id { get; set; }
    }
}
