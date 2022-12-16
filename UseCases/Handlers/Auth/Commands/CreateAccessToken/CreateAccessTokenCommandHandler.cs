using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Utils.Identity;
using Infrastructure.Implementation.Identity.Models;
using Infrastructure.Interfaces.Identity.Services;
using Infrastructure.Interfaces.DataAccess;
using Entities.Models;
using UseCases.Exceptions;

namespace UseCases.Handlers.Auth.Commands.CreateAccessToken
{
    public class CreateAccessTokenCommandHandler : IRequestHandler<CreateAccessTokenCommand, TokenResponse>
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly ITokenService<TokenRequest, TokenResponse> _tokenService;
        private readonly IApplicationDbContext _dbContext;

        public CreateAccessTokenCommandHandler(UserManager<ApplicationIdentityUser> userManager, ITokenService<TokenRequest, TokenResponse> tokenService, IApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _dbContext = dbContext;
        }

        public async Task<TokenResponse> Handle(CreateAccessTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationIdentityUser), request.UserName);

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
                throw new BadRequestException("User password not valid.");

            var employee = await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.UserId == user.Id);
            if (employee == null)
                throw new NotFoundException(nameof(Employee), user.Id);

            return _tokenService.CreateToken(new TokenRequest
            {
                UserId = user.Id,
                UserName = user.UserName,
                EmployeeId = employee.Id
            });
        }
    }
}
