using MediatR;
using Entities.Enums;

namespace UseCases.Handlers.Jobs.Commands.CreateJob
{
    public class CreateJobCommand : IRequest
    {
        public int IssueId { get; set; }
        public JobAction ActionId { get; set; }
        public string Description { get; set; }
    }
}
