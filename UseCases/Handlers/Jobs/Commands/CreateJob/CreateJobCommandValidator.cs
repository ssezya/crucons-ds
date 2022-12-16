using FluentValidation;

namespace UseCases.Handlers.Jobs.Commands.CreateJob
{
    public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidator()
        {
            RuleFor(p => p.IssueId).NotEmpty();

            RuleFor(p => p.ActionId)
                .NotEmpty()
                .IsInEnum();

            RuleFor(p => p.Description).NotEmpty();
        }
    }
}
