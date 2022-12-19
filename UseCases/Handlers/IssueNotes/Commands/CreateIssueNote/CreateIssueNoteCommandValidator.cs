using FluentValidation;

namespace UseCases.Handlers.IssueNotes.Commands.CreateIssueNote
{
    public class CreateIssueNoteCommandValidator : AbstractValidator<CreateIssueNoteCommand>
    {
        public CreateIssueNoteCommandValidator()
        {
            RuleFor(p => p.IssueId)
                .NotEmpty();

            RuleFor(p => p.Description)
                .NotEmpty()
                .MaximumLength(2000);
        }
    }
}
