using MediatR;

namespace UseCases.Handlers.IssueNotes.Commands.CreateIssueNote
{
    public class CreateIssueNoteCommand : IRequest
    {
        public int IssueId { get; set; }
        public string Description { get; set; }
    }
}
