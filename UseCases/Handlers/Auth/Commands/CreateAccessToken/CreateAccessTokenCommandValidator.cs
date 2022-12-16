using FluentValidation;

namespace UseCases.Handlers.Auth.Commands.CreateAccessToken
{
    public class CreateAccessTokenCommandValidator : AbstractValidator<CreateAccessTokenCommand>
    {
        public CreateAccessTokenCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(p => p.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
