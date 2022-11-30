using FluentValidation;

namespace UseCases.Handlers.Issues.Commands.UpdateIssue
{
    class UpdateIssueCommandValidator : AbstractValidator<UpdateIssueDto>
    {
        public UpdateIssueCommandValidator()
        {
            RuleFor(p => p.Name).MinimumLength(3).MaximumLength(100).NotEmpty();
            RuleFor(p => p.StatusId).NotEmpty();
        }
    }
}
