using System.Linq;
using FluentValidation;

namespace UseCases.Handlers.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100)
                .Must(name => !name.All(c => char.IsWhiteSpace(c)));
        }
    }
}
