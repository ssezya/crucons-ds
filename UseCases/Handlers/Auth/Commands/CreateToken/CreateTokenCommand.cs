using MediatR;
using Utils.Identity;

namespace UseCases.Handlers.Auth.Commands.CreateToken
{
    public class CreateTokenCommand : IRequest<TokenResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
