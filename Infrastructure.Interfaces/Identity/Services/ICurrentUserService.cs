using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Identity.Services
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
        Task<int> GetEmployeeIdByIdentityUser();
    }
}
