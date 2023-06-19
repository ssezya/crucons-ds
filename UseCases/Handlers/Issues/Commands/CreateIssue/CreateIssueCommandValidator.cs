using System.Linq;
using FluentValidation;

namespace UseCases.Handlers.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandValidator : AbstractValidator<CreateIssueCommand>
    {
        public CreateIssueCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100)
                .Must(title => !title.All(c => char.IsWhiteSpace(c)));

            RuleFor(p => p.Description)
                .MaximumLength(4000);

            RuleFor(p => p.ProjectId)
                .NotEmpty();
        }
    }
}
