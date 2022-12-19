using MediatR;

namespace UseCases.Handlers.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest
    {
        public int IssueId { get; set; }
        public string Description { get; set; }
    }
}
