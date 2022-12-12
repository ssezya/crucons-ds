namespace Infrastructure.Interfaces.Identity.Services
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        int EmployeeId { get; }
        bool IsAuthenticated { get; }
    }
}
