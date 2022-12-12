using MediatR;

namespace UseCases.Handlers.Jobs.Commands.CreateJob
{
    public class CreateJobCommand : IRequest
    {
        public int IssueId { get; set; }
        public int ActionId { get; set; }
        public string Description { get; set; }
    }
}
