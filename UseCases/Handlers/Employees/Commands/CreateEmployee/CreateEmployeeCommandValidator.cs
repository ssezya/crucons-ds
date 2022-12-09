using System.Linq;
using FluentValidation;

namespace UseCases.Handlers.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30)
                .Must(userName => !userName.All(c => char.IsWhiteSpace(c)));

            RuleFor(p => p.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(p => p.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);
        }
    }
}
