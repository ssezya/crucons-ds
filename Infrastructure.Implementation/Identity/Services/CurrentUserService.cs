using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Infrastructure.Interfaces.Identity.Services;
using Utils.Identity;

namespace Infrastructure.Implementation.Identity.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            EmployeeId = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue(ApplicationIdentityConstants.EmployeeIdClaimType));
            IsAuthenticated = UserId != null && EmployeeId != 0;
        }

        public string UserId { get; }
        public int EmployeeId { get; }
        public bool IsAuthenticated { get; }
    }
}
