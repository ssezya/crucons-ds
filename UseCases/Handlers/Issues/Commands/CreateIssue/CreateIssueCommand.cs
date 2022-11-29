using MediatR;

namespace UseCases.Handlers.Issues.Commands.CreateIssue
{
    public class CreateIssueCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
