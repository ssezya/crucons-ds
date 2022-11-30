using FluentValidation;

namespace UseCases.Handlers.Issues.Commands.UpdateIssue
{
    public class UpdateIssueCommandValidator : AbstractValidator<UpdateIssueCommand>
    {
        public UpdateIssueCommandValidator()
        {
            RuleFor(p => p.Dto).NotNull().SetValidator(new UpdateIssueDtoValidator());
        }
    }

    public class UpdateIssueDtoValidator : AbstractValidator<UpdateIssueDto>
    {
        public UpdateIssueDtoValidator()
        {
            RuleFor(p => p.Name).MinimumLength(3).MaximumLength(100).NotEmpty();
            RuleFor(p => p.StatusId).NotEmpty();
        }
    }
}
