using MediatR;

namespace UseCases.Handlers.Issues.Commands.UpdateIssue
{
    public class UpdateIssueCommand : IRequest
    {
        public UpdateIssueCommand(int id, UpdateIssueDto dto)
        {
            Id = id;
            Dto = dto;
        }

        public int Id { get; set; }
        public UpdateIssueDto Dto { get; set; }
    }
}
