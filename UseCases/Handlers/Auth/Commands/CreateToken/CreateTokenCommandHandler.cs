using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MediatR;
using Utils.Identity;
using Infrastructure.Implementation.Identity.Models;
using Infrastructure.Interfaces.Identity.Services;
using UseCases.Exceptions;

namespace UseCases.Handlers.Auth.Commands.CreateToken
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, TokenResponse>
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly ITokenService<ApplicationIdentityUser, TokenResponse> _tokenService;

        public CreateTokenCommandHandler(UserManager<ApplicationIdentityUser> userManager, ITokenService<ApplicationIdentityUser, TokenResponse> tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<TokenResponse> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationIdentityUser), request.UserName);

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (isPasswordValid)
                throw new BadRequestException("User password not valid");

            return _tokenService.CreateToken(user);
        }
    }
}
