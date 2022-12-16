using FluentValidation;

namespace UseCases.Handlers.Issues.Commands.UpdateIssue
{
    public class UpdateIssueCommandValidator : AbstractValidator<UpdateIssueCommand>
    {
        public UpdateIssueCommandValidator()
        {
            RuleFor(p => p.Dto)
                .NotNull()
                .SetValidator(new UpdateIssueDtoValidator());
        }
    }

    public class UpdateIssueDtoValidator : AbstractValidator<UpdateIssueDto>
    {
        public UpdateIssueDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(p => p.Description)
                .MaximumLength(4000);

            RuleFor(p => p.ProjectId)
                .NotEmpty();

            RuleFor(p => p.ReporterId)
                .NotEmpty();

            RuleFor(p => p.StatusId)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
