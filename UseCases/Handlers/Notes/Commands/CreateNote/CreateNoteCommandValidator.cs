using FluentValidation;

namespace UseCases.Handlers.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(p => p.IssueId)
                .NotEmpty();

            RuleFor(p => p.Description)
                .NotEmpty()
                .MaximumLength(2000);
        }
    }
}
