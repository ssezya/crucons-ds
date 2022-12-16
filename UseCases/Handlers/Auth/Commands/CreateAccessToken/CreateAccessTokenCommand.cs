using MediatR;
using Utils.Identity;

namespace UseCases.Handlers.Auth.Commands.CreateAccessToken
{
    public class CreateAccessTokenCommand : IRequest<TokenResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
