using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Identity.Services;

namespace Infrastructure.Implementation.Identity.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IApplicationDbContext _dbContext;

        public CurrentUserService(IApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;

            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
        }

        public string UserId { get; }
        public bool IsAuthenticated { get; }

        public async Task<int> GetEmployeeIdByIdentityUser()
        {
            var employee = await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.UserId == UserId);
            if (employee == null)
                throw new Exception("Employee by UserId not found");

            return employee.EmployeeId;
        }
    }
}
