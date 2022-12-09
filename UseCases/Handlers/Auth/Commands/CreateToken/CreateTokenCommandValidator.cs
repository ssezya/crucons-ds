using FluentValidation;

namespace UseCases.Handlers.Auth.Commands.CreateToken
{
    public class CreateTokenCommandValidator : AbstractValidator<CreateTokenCommand>
    {
        public CreateTokenCommandValidator()
        {
            RuleFor(p => p.UserName).MinimumLength(3).MaximumLength(30).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(6).NotEmpty();
        }
    }
}
