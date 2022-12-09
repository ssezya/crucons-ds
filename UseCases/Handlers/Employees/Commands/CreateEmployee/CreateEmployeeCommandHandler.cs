using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using MediatR;
using Infrastructure.Implementation.Identity.Models;
using Infrastructure.Interfaces.DataAccess;
using Entities.Models;
using UseCases.Exceptions;

namespace UseCases.Handlers.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly IApplicationDbContext _dbContext;

        public CreateEmployeeCommandHandler(UserManager<ApplicationIdentityUser> userManager, IApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationIdentityUser { UserName = request.UserName };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new BadRequestException(result.Errors.Select(s => s.Description).First()); // You need to generate a normal error message

            _dbContext.Employees.Add(new Employee
            {
                UserId = user.Id,
                FirstName = request.FirstName,
                LastName = request.LastName
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
