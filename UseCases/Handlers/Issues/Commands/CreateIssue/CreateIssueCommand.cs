using MediatR;

namespace UseCases.Handlers.Issues.Commands.CreateIssue
{
    public class CreateIssueCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int? ExecutorId { get; set; }
    }
}
